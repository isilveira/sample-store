namespace Store.Presentations.CommandConsole.Interfaces
{
    interface ICommand
    {
        string Name { get; }
        string CommandLine { get; }
        void Run(out bool exit);
    }
}
