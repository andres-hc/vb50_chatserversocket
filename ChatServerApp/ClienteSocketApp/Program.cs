using ClienteSocketApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iniciando conexion a servidor {0} en el puerto {1}", ip, puerto);
            ClienteSocket clienteSocket = new ClienteSocket(puerto, ip);

            if (clienteSocket.Conectar())
            {
                //Protocolo de comunicacion
                string mensaje = "";

                while(mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("Ingrese mensaje:");
                    mensaje = Console.ReadLine().Trim();
                    clienteSocket.Escribir(mensaje);
                    if(mensaje.ToLower() != "chao")
                    {
                        mensaje = clienteSocket.Leer();
                        Console.WriteLine("S:{0}", mensaje);
                    }
                }
                clienteSocket.Desconectar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error al conectar al servidor");
            }
        }
    }
}
