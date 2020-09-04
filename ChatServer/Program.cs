using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var chatService = new ChatServiceImpl();
            var host = new ServiceHost(chatService);

            host.Open();

            Console.WriteLine("El servidor esta corriendo exitosamente");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();

            host.Close();
        }
    }
}
