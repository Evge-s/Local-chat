#pragma comment(lib, "Ws2_32.lib") 
#include <WinSock2.h> 
#include <iostream>
#include <WS2tcpip.h> 
using namespace std;

SOCKET Connect;		// Сокет принимающий подключаемых клиентов
SOCKET* Connections; //  Массив сокетов для сохранения информации о подключеных клиентах
SOCKET Listen; // сокет для прослушки
int ClientCount = 0;


void Send_Mssg_Client(int ID) // функция для ретрансляции сообщений клиент - сервер / сервер - клиенты 
{
	char* buff = new char[1024]; // буфер для сообщений
	for (;; Sleep(75))  // безконечный цикл 
	{
		memset(buff, 0, sizeof(buff)); // чистим буфер (заполняем нулями)
		if (recv(Connections[ID], buff, 1024, NULL)) // записываем полученое от клиента сообщение в буфер
		{
			cout << buff << endl; // выводим даное сообщение на сервер
			for (int i = 0; i <= ClientCount; i++)	
			{
				send(Connections[i], buff, strlen(buff), NULL);	// отправляем сообщениее всем клиентам в массиве 
			}
		}		
	}
	delete[] buff;		// чистим буфер
}
//***********************************************************************

int main() {
	setlocale(LC_ALL, "russian");

	WSADATA data;
	WORD version = MAKEWORD(2, 2);	// версия сокетов
	int res = WSAStartup(version, &data); // результат инициализации сокетов

	if (res != 0) {	 // проверка открытия сокета
		cout << "Socket create error!" << endl;
		return 0;
	}

	struct addrinfo hints;		// структуры для работы с сокетами (инициализация, инфо о хосте)
	struct addrinfo* result;

	Connections = (SOCKET*)calloc(64, sizeof(SOCKET)); // инициализируем и выделяем память под сокет к которому будет подключаться клиент

	ZeroMemory(&hints, sizeof(hints)); // очистка структуры для последующей инициализации

	hints.ai_family = AF_INET;  // указываем на тип адрессов с которыми сможет взаимодействовать сокет (IPv4)
	hints.ai_flags = AI_PASSIVE; // задает изначалный адрес хоста (локальной машины)
	hints.ai_socktype = SOCK_STREAM; // указываем тип сокета для работы с входящими соединениями
	hints.ai_protocol = IPPROTO_TCP; // определяем транспортный протокол

	getaddrinfo("127.192.0.1", "1111", &hints, &result); // передаем даные о сокете на сервер (ИП-адресс и Порт)

	Listen = socket(result->ai_family, result->ai_socktype, result->ai_protocol); // инициализируем сокет 
	bind(Listen, result->ai_addr, result->ai_addrlen); // привязыаем сокет к даным о порте и ИП
	listen(Listen, SOMAXCONN); // запуск прослушки сокета для подключения с максимально возможним количеством клиентов

	freeaddrinfo(result); // чистим данные после запуска сервера

	cout << "Server up" << endl; // выводим при запуске сервера
	char m_connect[] = "Client connect...\n;;;5"; // выводим при подключении клиентов (";;;5" определение конца строки)
	for (;; Sleep(75)) { // безконечный цикл

		if (Connect = accept(Listen, NULL, NULL)) { // ожидание подключения клиента
			cout << "Client connect" << endl; // выводим при подключении клиентов
			Connections[ClientCount] = Connect; // заносим информацию о клиенте в массив клиентов
			send(Connections[ClientCount], m_connect, strlen(m_connect), NULL); // отправляем клиенту сообщение о подключении к серверу
			ClientCount++; // увеличиваем размер массива клиентов
			CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)Send_Mssg_Client, (LPVOID)(ClientCount - 1), NULL, NULL); // запуск потока обмена даными клиент-сервер
		}
	}
	return 0;
}