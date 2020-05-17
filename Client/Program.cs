using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Старт работы клиента...");
            var sHost = "user-ПК";
            String usHost; // адрес нашего хоста
            Console.WriteLine("Введите адрес сервера или нажмите Enter для использования стандартного: ");
            usHost = Console.ReadLine();
            if (usHost.Length > 0) sHost = usHost;
            new Client(sHost); // создаю экземпляр класса клиент
            Console.ReadKey();
            

        }
    }
}
