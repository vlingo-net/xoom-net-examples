using System;

namespace Vlingo.Actors.Examples.PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.Start("playground");

            var pinger = world.ActorFor<IPinger>(
                Definition.Has<PingerActor>(
                    Definition.NoParameters));

            var ponger = world.ActorFor<IPonger>(
                Definition.Has<PongerActor>(
                    Definition.NoParameters));

            pinger.Ping(ponger);

            Console.WriteLine("Press any key to end the world...");
            Console.ReadKey();

            world.Terminate();
        }
    }
}
