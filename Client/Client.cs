using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        private String serverHost; // адрес сервера
        private Socket cSocket; // сокет со стороны клиента
        private int port = 8034;
        public Client(String serverHost)
        {
            try
            {
                this.serverHost = serverHost;
                Console.WriteLine("Подключение к {0}, this.serverHost");
                cSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                // вместо Bind связывания исп. коннэкт:
                cSocket.Connect(this.serverHost, port);
            }
            catch 
            {
                Console.WriteLine("что-то пошло не так...:(");
            }
        }
    }
}
