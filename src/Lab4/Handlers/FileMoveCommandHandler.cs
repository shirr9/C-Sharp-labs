using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileMoveCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["file", "move", _, _])
        {
            return new FileMoveCommand(args[2], args[3]);
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}