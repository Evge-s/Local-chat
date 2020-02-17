using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Chat_Client_Form
{
    public partial class Form1 : Form  
    {
        static private Socket Client; //
        private IPAddress ip = null;  // параметры класса формы 
        private int port = 0;         //
        private Thread th;            //

        public Form1()
        {
            InitializeComponent();
            TextBox.Enabled = false; // задаем значение "отключено" по умолчанию для полей вывода
            SendBox.Enabled = false; // и ввода текста

            try // обработка исключений (например в случае обрыва соединения) невозможность выполнить строку являеться исключением
            {
                var sr = new StreamReader(@"Client_info/data_info.txt"); // запуск потока для чтения с файла (txt* документ)
                string buff = sr.ReadToEnd(); // запись содержимого с файла в буфер
                sr.Close(); // закрываем поток

                string[] connect_info = buff.Split(':'); // парсим файл с помощью функции "Split" которая разделяет строку на части находя заданое значение - ":" (заносим части в массив строк "connect_info")
                ip = IPAddress.Parse(connect_info[0]); // парсим 0й элемент массива (1ю строку) переводя с помощью функции "IPAddress" в формат ИП адресса для инициаализации значения поля "ip" класса Form1
                port = int.Parse(connect_info[1]); // парсим 1й элемент массива (2ю строку) переводя в инт, для инициализации значения поля "port" класса Form1

                Show_Setting.ForeColor = Color.Green; // цвет поля с отображением настроек
                Show_Setting.Text = "\n IP сервера: " + connect_info[0] + "\n Порт сервера: " + connect_info[1]; // отображение строк массива (настройки ИП и порта)

            }
            catch (Exception ex) // обработка исключений; если в блоке "try" возникло исключение, то сработает блок "catch"
            {
                Show_Setting.ForeColor = Color.Red; // цвет поля с отображением настроек
                Show_Setting.Text = "Настроойки\nне найдены!"; 
                Settings form = new Settings();  // инициализация формы классом "Settings"
                form.Show();    // вызов формы "Settings"
            }

        }
        private void SendBox_Click(object sender, EventArgs e) // Отправить
        {           
            SendMessage(NickBox.Text + ": " + TextBox.Text + ";;;5"); // отправляем строку текста с поля никнейма + поле для ввода сообщений и обозначение для завершения строки 
            TextBox.Clear(); // чистим поле для ввода теста
        }
        void SendMessage(string message)  // отправка сообщения
        {
            if (message != " " && message != "") // если сообщение не пустое
            {
                byte[] buffer = new byte[1024];   // создаем буфер
                buffer = Encoding.UTF8.GetBytes(message); // получаем байт код сообщения
                Client.Send(buffer); // отправляем на сервер
            }
        }
        void ReceiveMessage() // функция приема даных 
        {
            byte[] buffer = new byte[1024]; // буфер для приема сообщений от сервера
            for (int i = 0; i < buffer.Length; i++) 
            {
                buffer[i] = 0; // чистим буфер заполняя "0" 
            }
            for (; ; ) // безконечный цикл 
            {
                try
                {
                    Client.Receive(buffer); // принимаем даные от сервера, записав их в "buffer"
                    string message = Encoding.UTF8.GetString(buffer); // декодируем сообщение с "buffer" заннося полученый текст в строку "message"
                    int count = message.IndexOf(";;;5"); // инициализируем размер сообщения начало и конец строки с помощью функции IndexOF которая будет задавать конец сообщения когда найдет последователость ";;;5" в строке
                    if (count == -1) // если IndexOF не сработал, игнорируеем сообщение.
                    {
                        continue;
                    }
                    string Clear_Message = ""; // создаем буфер для отображения сообщения в чате
                    for (int i = 0; i < count; i++)
                    {
                        Clear_Message += message[i]; // заносим в него уже отформаттированый текст (декодированый, с задаными параметрами начала и конца строки)
                    }
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = 0; // чистим буфер приема сообщений с сервера
                    }
                    this.Invoke((MethodInvoker)delegate() // ф-ция "this" нужна для возможности получения доступа для потока к элементу формы (окно отображения сообщений) 
                    {
                        ChatBox.AppendText(Clear_Message); // выводим в чат буфер с отформатированым текстом с помщью фунции "AppendText"
                    });
                }
                catch (Exception ex) { }
            }
        }
        private void EnterBox_Click(object sender, EventArgs e) // Вход в чат
        {
            if (NickBox.Text != " " && NickBox.Text != "") // прверка заполнения поля с никнеймом
            {   // если поле заполнено 
                SendBox.Enabled = true; // активируем поле для ввода текста
                TextBox.Enabled = true; // активируем поле для чтения сообщений
                Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // ицилиализация даных о клиенте при подключении к серверу
                if (ip != null) // если даные инициализированы 
                {
                    Client.Connect(ip, port); // подключение к серверу
                    th = new Thread(delegate () { ReceiveMessage(); }); // поток для приема данных с сервера
                    th.Start(); // запуск потока
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) // вызов формы "Настройки"
        {
            Settings form = new Settings();
            form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // Выход из програмы
        {
            if (th != null)
            {
                th.Abort(); // завершение потока при закрытии ппрограмы
            }
            if (Client != null)
            {
                Client.Close(); // закрытие сокета и освобожение всех связаных с ним ресурсов 
            }
            Application.Exit();
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) // Вызов срабатывания нажатия на кнопку "Отправить" при нажатии "Enter" в окне для ввода текста
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendBox_Click(SendBox, null);
            }
        }

        private void ChatBox_TextChanged(object sender, EventArgs e) // Автоматическая прокрутка скроллбара в окне чата
        {
            ChatBox.SelectionStart = ChatBox.Text.Length;
            ChatBox.ScrollToCaret();
        }
    }
}
