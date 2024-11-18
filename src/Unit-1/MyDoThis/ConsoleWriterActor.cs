using Akka.Actor;

namespace MyDoThis;

public class ConsoleWriteActor : UntypedActor
{
    protected override void OnReceive(object message)
    {
        string msg = message as string;
        switch(msg)
        {
            case "end":
                Console.WriteLine("Bue, bue...");
            break;
            default:
                Console.Write(msg);
                break;
        }

    }
}