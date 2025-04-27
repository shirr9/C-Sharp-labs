using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class CommandHandler
{
    protected CommandHandler? NextHandler { get; private set; }

    public CommandHandler SetNext(CommandHandler nextHandler)
    {
        if (NextHandler == null)
        {
            NextHandler = nextHandler;
        }
        else
        {
            NextHandler.SetNext(nextHandler);
        }

        return this;
    }

    public abstract ICommand? Handle(string[] args);
}