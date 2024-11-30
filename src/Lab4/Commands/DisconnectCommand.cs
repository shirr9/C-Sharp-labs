using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IProgramSystem programSystem)
    {
        programSystem.DisconnectSystem();
    }
}