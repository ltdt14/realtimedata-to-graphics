using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DataSender
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/speedhub")
            //.WithConsoleLogger()
            .Build();

            Connect(connection);

            connection.On<string>("ReceiveSpeed", (speed) =>
            {
                Console.WriteLine("Speed is " + speed);
            });

            int Speed = 50;
            Random rnd = new Random();
            while(true)
            {
                Speed += rnd.Next(-2,3);
                if(Speed < 0)
                {
                    Speed = 0;
                }
                Send(connection, Speed.ToString());
                System.Threading.Thread.Sleep(150);
            }


            Console.ReadLine();
            DisposeAsync(connection);
        }

        public static async Task DisposeAsync(HubConnection connection)
        {
            await connection.DisposeAsync();
        }

        static async Task Connect(HubConnection connection)
        {
            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Send(HubConnection connection, string speed)
        {
            Console.WriteLine("Sent message");
            try
            {
                await connection.InvokeAsync("SendSpeed",
                    speed);
                Console.WriteLine("Success");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
