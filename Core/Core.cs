using Prism.Events;

namespace Core;

public static class Regions
{
    public const string LEFT_REGION = "LeftRegion";
    public const string RIGHT_REGION = "RightRegion";
}

public class MessageSentEvent : PubSubEvent<string>
{
}