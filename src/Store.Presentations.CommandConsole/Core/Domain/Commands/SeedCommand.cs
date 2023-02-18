using ModelWrapper.Extensions.GetModels;
using Store.Core.Application.Default.Samples.Queries.GetSamplesByFilter;
using Store.Presentations.CommandConsole.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Store.Presentations.CommandConsole.Commands
{
    public class SeedCommand : ICommand
    {
        public SeedCommand()
        {
            Name = "Seed";
            CommandLine = "seed";
        }

        public string Name { get; private set; }

        public string CommandLine { get; private set; }

        public void Run(out bool exit)
        {
            Console.Clear();

            var request = new GetSamplesByFilterQuery();
            var cancellationToken = new CancellationToken();
            var mediator = CommandConsoleContext.GetMediator();

            var response = mediator.Send(request, cancellationToken);

            Task.WaitAll(response);

            var samples = response.GetAwaiter().GetResult()
                .GetModels()
                .ToList();

            samples.ForEach(sample => Console.WriteLine($"Sample - Id: {sample.Id}; Description: {sample.Description};"));
            Console.WriteLine($"{samples.Count} registers.");
            
            exit = false;
        }
    }
}
