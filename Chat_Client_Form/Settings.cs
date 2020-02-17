using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Chat_Client_Form
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != " " && textBox2.Text != "" && textBox2.Text != " ") // проверям заполнены ли поля ИП и Порт
            {
                try
                {
                    DirectoryInfo data = new DirectoryInfo("Client_info"); // создаем папку в которой будет храниться текстовый документ с данными
                    data.Create();

                    var sw = new StreamWriter(@"Client_info/data_info.txt"); // Открываем поток записи даных в файл ( текстовый документ)
                    sw.WriteLine(textBox1.Text + ":" + textBox2.Text);  // запись даных с поля ИП + ":" + поле ПОРТ
                    sw.Close(); // закрываем поток
                    this.Hide(); // сворачиваем форму
                    Application.Restart(); // перезагружаем програму, для инициализации новых настрек (ИП, ПОРТ)
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Выводим сообщение об ошибке в случае исключения
                }
            }
        }
    }
}
