using DbUp;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Fennorad.DbUp
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("Chat");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Connection String not specified");
                Console.ResetColor();

                return -1;
            }

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithExecutionTimeout(TimeSpan.FromMinutes(3))
                    .LogToConsole()
                    .Build();

            if (!upgrader.TryConnect(out var message))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                return -1;
            }

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            return 0;
        }
    }
}