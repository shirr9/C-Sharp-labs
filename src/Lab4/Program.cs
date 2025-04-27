using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var localFileSystemFactory = new LocalFileSystemFactory();
        IEnumerable<IFileSystemFactory> fileSystemFactories = new List<IFileSystemFactory> { localFileSystemFactory };
        var consolePrinterFactory = new ConsolePrinterFactory();
        IEnumerable<IPrinterFactory> printerFactories = new List<IPrinterFactory> { consolePrinterFactory };

        var system = new ProgramSystem(fileSystemFactories, printerFactories);

        while (true)
        {
            Console.Write("^.^ ");
            string? inputCommand = Console.ReadLine();
            if (inputCommand == null)
            {
                break;
            }

            string[] commandArgs = inputCommand.Split(' ');

            if (Equals(commandArgs[0], "exit"))
            {
                break;
            }

            ICommand? command = new ConnectCommandHandler()
                .SetNext(new DisconnectCommandHandler())
                .SetNext(new FileCopyCommandHandler())
                .SetNext(new FileDeleteCommandHandler())
                .SetNext(new FileMoveCommandHandler())
                .SetNext(new FileRenameCommandHandler())
                .SetNext(new FileShowCommandHandler())
                .SetNext(new TreeGotoCommandHandler())
                .SetNext(new TreeListCommandHandler())
                .Handle(commandArgs);

            if (command == null)
            {
                Console.WriteLine("Invalid command");
            }
            else
            {
                command.Execute(system);
            }
        }
    }
}