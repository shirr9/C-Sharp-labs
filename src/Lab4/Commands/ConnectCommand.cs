using Itmo.ObjectOrientedProgramming.Lab4.Systems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;

    private readonly string _mode;

    public ConnectCommand(string address, string mode)
    {
        _address = address;
        _mode = mode;
    }

    public void Execute(IProgramSystem programSystem)
    {
        programSystem.ConnectSystem(_address, _mode);
    }
}