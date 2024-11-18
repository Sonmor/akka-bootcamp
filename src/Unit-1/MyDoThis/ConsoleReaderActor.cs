using System;
using Akka.Actor;

namespace MyDoThis;

public class ConsoleReaderActor : UntypedActor
{
    private readonly IActorRef _writer;

    public ConsoleReaderActor(IActorRef writer)
    {
        _writer = writer;
    }
    protected override void OnReceive(object message)
    {
        string msg = message as string;
            switch(msg)
            {
                case "start":
                _writer.Tell("Please input your name: ");
                var name = Console.ReadLine();
                _writer.Tell($"Your name is {name}\n");
                _writer.Tell("Continue? (y/n)\n");
                var answer = Console.ReadLine();
                Self.Tell(answer == "y" ? "start": "end");
                break;
                case "end":
                    _writer.Tell("end");
                    Context.System.Terminate();
                    break;
            }
    }
}
