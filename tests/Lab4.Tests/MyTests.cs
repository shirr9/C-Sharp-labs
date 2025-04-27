using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Xunit;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Commands.ICommand;

namespace Lab4.Tests;

public class MyTests
{
    [Fact]
    public void TryConnectCommandParse()
    {
        string connectCommand = "connect Address -m Mode";
        string[] commandArgs = connectCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is ConnectCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryDisconnectCommandParse()
    {
        string disconnectCommand = "disconnect";
        string[] commandArgs = disconnectCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is DisconnectCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryCopyCommandParse()
    {
        string stringCommand = "file copy SourcePath DestinationPath";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is FileCopyCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryDeleteCommandParse()
    {
        string stringCommand = "file delete Path";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is FileDeleteCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryMoveCommandParse()
    {
        string stringCommand = "file move SourcePath DestinationPath";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is FileMoveCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryRenameCommandParse()
    {
        string stringCommand = "file rename Path Name";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is FileRenameCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryShowCommandParse()
    {
        string stringCommand = "file show Path -m Mode";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is FileShowCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryGoToCommandParse()
    {
        string stringCommand = "tree goto Path";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is TreeGotoCommand;
        Assert.True(res);
    }

    [Fact]
    public void TryTreeListCommandParse()
    {
        string stringCommand = "tree list";
        string[] commandArgs = stringCommand.Split(' ');

        ICommand? command = new ConnectCommandHandler()
            .SetNext(new DisconnectCommandHandler())
            .SetNext(new FileCopyCommandHandler())
            .SetNext(new FileDeleteCommandHandler())
            .SetNext(new FileMoveCommandHandler())
            .SetNext(new FileRenameCommandHandler())
            .SetNext(new FileShowCommandHandler())
            .SetNext(new TreeGotoCommandHandler())
            .SetNext(new TreeListCommandHandler())
            .Handle(commandArgs);
        bool res = command is TreeListCommand;
        Assert.True(res);
    }
}