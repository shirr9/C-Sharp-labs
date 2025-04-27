using Itmo.ObjectOrientedProgramming.Lab3.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message : IMessage
{
    private Message(string heading, string body, int importance)
    {
        Heading = heading;
        Body = body;
        Importance = importance;
        Id = Guid.NewGuid();
    }

    public bool Equals(IMessage? other)
    {
        return other != null && Id == other.Id && Heading == other.Heading && Body == other.Body
               && Importance == other.Importance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((IMessage)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    // Builder
    public static IHeadingBuilder Builder => new MessageBuilder();

    private class MessageBuilder : IMessageBuilder, IHeadingBuilder, IBodyBuilder, IImportanceBuilder
    {
        private string _heading = string.Empty;

        private string _body = string.Empty;

        private int _importance;

        public IBodyBuilder WithHeading(string heading)
        {
            _heading = heading;
            return this;
        }

        public IImportanceBuilder WithBody(string body)
        {
            _body = body;
            return this;
        }

        public IMessageBuilder WithImportance(int importance)
        {
            _importance = importance;
            return this;
        }

        public Message Build()
        {
            return new Message(_heading, _body, _importance);
        }
    }

    public string Heading { get; }

    public string Body { get; }

    public int Importance { get; }

    public Guid Id { get; }
}