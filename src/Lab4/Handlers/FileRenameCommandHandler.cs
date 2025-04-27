using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class FileRenameCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["file", "rename", _, _])
        {
            return new FileRenameCommand(args[2], args[3]);
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}