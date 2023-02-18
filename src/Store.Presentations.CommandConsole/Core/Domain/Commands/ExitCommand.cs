using Store.Presentations.CommandConsole.Interfaces;

namespace Store.Presentations.CommandConsole.Commands
{
    public class ExitCommand : ICommand
    {
        public ExitCommand()
        {
            Name = "Exit";
            CommandLine = "exit";
        }

        public string Name { get; private set; }

        public string CommandLine { get; private set; }

        public void Run(out bool exit)
        {
            exit = true;
        }
    }
}
