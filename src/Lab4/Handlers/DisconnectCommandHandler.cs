using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class DisconnectCommandHandler : CommandHandler
{
    public override ICommand? Handle(string[] args)
    {
        if (args is ["disconnect"])
        {
            return new DisconnectCommand();
        }

        if (NextHandler != null)
        {
            return NextHandler.Handle(args);
        }

        return null;
    }
}