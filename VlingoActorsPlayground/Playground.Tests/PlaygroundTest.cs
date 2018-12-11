using Vlingo.Actors;
using Vlingo.Actors.TestKit;
using Xunit;

namespace Playground.Tests
{
    public class PlaygroundTest
    {
        [Fact]
        public void TestPlayPingPong()
        {
            var world = World.Start("playground");
            var until = TestUntil.Happenings(1);

            var pinger = world.ActorFor<IPinger>(
                Definition.Has<PingerActor>(Definition.Parameters(until)));

            var ponger = world.ActorFor<IPonger>(
                Definition.Has<PongerActor>(
                    Definition.NoParameters));

            pinger.Ping(ponger);
            until.Completes();
            world.Terminate();
        }
    }
}