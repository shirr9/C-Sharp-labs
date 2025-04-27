using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileDeleteCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["file", "delete", _])
        {
            return new FileDeleteCommand(args[2]);
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}