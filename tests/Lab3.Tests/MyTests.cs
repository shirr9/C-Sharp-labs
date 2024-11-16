using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.External.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MyTests
{
    [Fact]
    public void TryReceiveMessage()
    {
        var user = new User();
        Message message = Message.Builder
            .WithHeading("Heading")
            .WithBody("body")
            .WithImportance(5)
            .Build();
        user.ReceiveMessage(message);
        bool res = user.IsMessageRead(message);
        Assert.False(res);
    }

    [Fact]
    public void TryReadMessage()
    {
        var user = new User();
        Message message = Message.Builder
            .WithHeading("Heading")
            .WithBody("body")
            .WithImportance(5)
            .Build();
        user.ReceiveMessage(message);
        bool res = user.TryReadMessage(message);
        Assert.True(res);
    }

    [Fact]
    public void TryReadAlreadyReadMessage()
    {
        var user = new User();
        Message message = Message.Builder
            .WithHeading("Heading")
            .WithBody("body")
            .WithImportance(5)
            .Build();
        user.ReceiveMessage(message);
        user.TryReadMessage(message);
        bool res = user.TryReadMessage(message);
        Assert.False(res);
    }

    [Fact]
    public void TrySendMessageInsufficientLevelImportance()
    {
        var mockDestination = new Mock<IDestination>();
        var mockMessage = new Mock<IMessage>();
        mockMessage.Setup(m => m.Importance).Returns(5);

        var filter = new FilterMessagesDecorator(mockDestination.Object, 10);

        filter.ReceiveMessage(mockMessage.Object);
        mockDestination.Verify(d => d.ReceiveMessage(It.IsAny<IMessage>()), Times.Never, "Message with low importance should not reach the destination.");
    }

    [Fact]
    public void TryLoggingUserDestination()
    {
        var mockLogger = new Mock<ILogger>();
        var mockDestination = new Mock<IDestination>();
        var mockMessage = new Mock<IMessage>();

        var testMessageId = Guid.NewGuid();
        mockMessage.Setup(m => m.Id).Returns(testMessageId);

        var loggingDecorator = new LoggingMessagesDecorator(mockDestination.Object, mockLogger.Object);

        loggingDecorator.ReceiveMessage(mockMessage.Object);

        mockLogger.Verify(
            logger => logger.Log(It.Is<string>(msg => msg == testMessageId.ToString())),
            Times.Once,
            "Logger should log the message ID when it is received.");

        mockDestination.Verify(
            destination => destination.ReceiveMessage(mockMessage.Object),
            Times.Once,
            "Message should be passed to the next destination.");
    }

    [Fact]
    public void TrySendMessageMessenger()
    {
        var mockMessage = new Mock<IMessage>();
        mockMessage.Setup(m => m.Heading).Returns("Test Heading");

        var messenger = new Messenger();

        using var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        messenger.AcceptMessage(mockMessage.Object);

        string expectedOutput = "Messenger: Test Heading\r\n";
        Assert.Equal(expectedOutput, consoleOutput.ToString());
    }

    [Fact]
    public void TryFilterUserDestination()
    {
        var user = new User();
        Message message = Message.Builder
            .WithHeading("Heading")
            .WithBody("body")
            .WithImportance(5)
            .Build();

        var userDestination1 = new UserDestination(user);
        var userDestination2 = new UserDestination(user);

        var filter = new FilterMessagesDecorator(userDestination1, 10);

        filter.ReceiveMessage(message);

        bool res1 = user.IsMessageReceived(message);

        userDestination2.ReceiveMessage(message);

        bool res2 = user.IsMessageReceived(message);

        bool res = !res1 && res2;

        Assert.True(res);
    }
}