using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC_Client
{
    public class Program
    {
        private readonly static RPCClient _rpcClient = new ();

        public static async Task Main(string[] args)
        {
            Console.WriteLine("RPC Client успешно запущен!");
            Console.WriteLine("Введи число и нажмите Enter для отправки на сервер:");

            do
            {
                string n = Console.ReadLine() ?? "";
                Console.WriteLine("Работаем с числом {0}", n);

                string response = await _rpcClient
                    .CallAsync(n)
                    .ConfigureAwait(false);
                Console.WriteLine("Получили результат: {0}", response);
            } 
            while (true);
        }
    }
}
