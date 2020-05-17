using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server //  создаю экземпляр класса сервер
    {
        private String host;
        private Socket sSocket; //  Cocket помогает устанавливать соединение между клиентом
        private const int port = 8034;
        public Server()
        {
          try 
          { 
            Console.WriteLine("Получение локального адреса сервера"); // нужно узать на каком адресе сервера будет функционировать
            host = Dns.GetHostName();
            Console.WriteLine("имя хоста: {0} ", host);
            sSocket = new Socket(SocketType.Stream, ProtocolType.Tcp); //  тип сокета и  тип протокола, на базе которого будет осуществлять обмен данными
                                                                       // транспортный уровень -ProtocolType.Tcp общаемся с конкр приложением, указывая адрес и порт, ошибочных передач не будет, тсп это контролирует
            
            foreach (var addr in Dns.GetHostEntry(host).AddressList)
            {
                try
                {
                    sSocket.Bind( // bind-  с англ привязать делаем привязку сокета к нек конечночной точке эндпоинт
                                  new IPEndPoint(addr, port)
                                 );
                    Console.WriteLine("Сокет связан с : {0}:{1} ", addr, port);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не удалост связать с: {0}:{1}", addr, port); // может возникнуть ошибка, порт может быть уже запущен? и если попытаться запустить дважды....
                }
            }
            // начинаем прослушивать порт?
            sSocket.Listen(10); // 10 секунд - максимальная длина очереди при подкл к серверу. Сервер не успеет обслужить всех пост. клиентов одновременно. 1 принял, остальные в очередь, сервер ждет коиентов
        
            Console.WriteLine(" прослушивание началось...");
            while (true) // принимаем соединение отклиентов
            {
                    Console.WriteLine("Ожиданеие нового подключения...");
                Socket cSocket = sSocket.Accept(); // сокет который позволит нам общаться с клиентом
                    Console.WriteLine(" Соединение с клиентом установлено");
            }
          }
        catch (Exception e) 
            {
                Console.WriteLine("ЧТо-то пошло не так..." );
            }
    
           Console.ReadKey();
        }
    }
}