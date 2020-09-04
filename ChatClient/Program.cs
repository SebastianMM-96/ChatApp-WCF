﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using ChatInterfaces;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channelFactory = new DuplexChannelFactory<IChatService>(new ChatClientImpl(), "ChatServiceEndpoint");
            var server = channelFactory.CreateChannel();

            server.Login(Environment.UserName);

            Console.WriteLine("Usuarios actuales:");
            foreach (var user in server.LoggedInUsers)
                Console.WriteLine(user.UserName);

            Console.WriteLine();
            Console.WriteLine("Ingrese el texto y presione <Enter> para enviar el mensaje.");
            Console.WriteLine("Presione el comando '<quit>' para desconectarse y salir del chat.");

            string message = Console.ReadLine();
            while (message != "<quit>")
            {
                message = message.Trim();
                if (!string.IsNullOrEmpty(message))
                    server.SendMessage(message);
                message = Console.ReadLine();
            }

            server.Logout();

            channelFactory.Close();
        }
    }

    class ChatClientImpl : IChatClient
    {
        #region Implementation of IChatClient

        public void ReceiveMessage(string userName, string message)
        {
            Console.WriteLine("{0}: {1}", userName, message);
        }

        #endregion
    }
}
