using System;
using System.Net.Http;

namespace WebApplication2.Models
{
    public interface IClient
    {
        void DoWork();
    }
    public interface ILogger
    {
        void Log(string log);
    }

    public class Client : IClient
    {
        private readonly ILogger logger;
        private readonly HttpClient httpClient;

        public Client(ILogger logger, HttpClient httpClient)
        {
            this.logger = logger;
            this.httpClient = httpClient;
        }

        public void DoWork()
        {
            this.logger.Log("from Client");
        }
    }

    public class Logger : ILogger
    {
        private readonly int id;

        public Logger(int id)
        {
            this.id = id;
        }

        public void Log(string log)
        {
            Console.WriteLine($"Logger id: {id}. => {log}");
        }
    }
}
