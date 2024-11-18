using Akka.Actor;

namespace MyDoThis;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("######### Win Tail ############");
        var actorSystem = ActorSystem.Create("WinTailActorSystem");

        var consoleWriterActor = actorSystem.ActorOf(Props.Create(() =>new ConsoleWriteActor()));

        var consoleReaderActor = actorSystem.ActorOf(Props.Create(() => new ConsoleReaderActor(consoleWriterActor)));

        consoleReaderActor.Tell("start");
        actorSystem.WhenTerminated.Wait();
        Console.WriteLine("####### End #############");
    }
}
