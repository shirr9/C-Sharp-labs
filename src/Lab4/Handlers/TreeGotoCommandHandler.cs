using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeGotoCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["tree", "goto", _])
        {
            return new TreeGotoCommand(args[2]);
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}