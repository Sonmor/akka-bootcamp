﻿using System;
﻿using Akka.Actor;

namespace WinTail
{
    #region Program
    class Program
    {
        public static ActorSystem MyActorSystem;

        static void Main(string[] args)
        {
            // initialize MyActorSystem
            // YOU NEED TO FILL IN HEREs
            MyActorSystem = ActorSystem.Create("MyActorSystem");

            PrintInstructions();

            // time to make your first actors!
            //YOU NEED TO FILL IN HERE
            // make consoleWriterActor using these props: Props.Create(() => new ConsoleWriterActor())
            var consoleWriterActorProps = Props.Create(() => new ConsoleWriterActor());
            var consoleWriterActor = MyActorSystem.ActorOf(consoleWriterActorProps);
            // make consoleReaderActor using these props: Props.Create(() => new ConsoleReaderActor(consoleWriterActor))
            var consoleReaderActorProps = Props.Create(() => new ConsoleReaderActor(consoleWriterActor));
            var consoleReaderActor = MyActorSystem.ActorOf(consoleReaderActorProps);
            // tell console reader to begin
            //YOU NEED TO FILL IN HERE
            consoleReaderActor.Tell("start");

            // blocks the main thread from exiting until the actor system is shut down
            MyActorSystem.WhenTerminated.Wait();
        }
        
        private static void PrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.Write("Some lines will appear as");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" red ");
            Console.ResetColor();
            Console.Write(" and others will appear as");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" green! ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }
    }
    #endregion
}
