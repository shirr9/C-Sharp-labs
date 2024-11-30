using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class TreeListCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["tree", "list", "-d", _])
        {
            return new TreeListCommand(int.Parse(args[3]));
        }

        if (args is ["tree", "list"])
        {
            return new TreeListCommand();
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}