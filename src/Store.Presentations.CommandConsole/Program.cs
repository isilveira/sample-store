using Store.Presentations.CommandConsole.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Store.Presentations.CommandConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = typeof(Program).GetTypeInfo().Assembly;

            var commandInterface = typeof(ICommand);

            var commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && commandInterface.IsAssignableFrom(type))
                .Select(type => (ICommand)Activator.CreateInstance(type))
                .ToList();

            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Store - Command Console");
                Console.WriteLine("----");
                Console.Write("cmd: ");
                var command = Console.ReadLine();

                commands
                    .Where(c => c.CommandLine.ToLower().Equals(command.ToLower()))
                    .SingleOrDefault().Run(out exit);
            } while (!exit);
        }
    }
}
