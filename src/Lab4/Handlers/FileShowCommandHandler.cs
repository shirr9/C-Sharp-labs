using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileShowCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["file", "show", _, "-m", _])
        {
            return new FileShowCommand(args[2], args[4]);
        }

        if (args is ["file", "show", _])
        {
            return new FileShowCommand(args[2], "console");
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}