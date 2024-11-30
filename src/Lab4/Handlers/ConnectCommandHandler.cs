using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class ConnectCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["connect", _, "-m", _])
        {
            return new ConnectCommand(args[1], args[3]);
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}