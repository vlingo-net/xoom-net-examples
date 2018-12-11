using Vlingo.Actors;

namespace Playground
{
    public class PongerActor : Actor, IPonger
    {
        private readonly IPonger self;

        public PongerActor()
        {
            self = SelfAs<IPonger>();
        }

        public void Pong(IPinger pinger)
        {
            Logger.Log("pong");
            pinger.Ping(self);
        }
    }
}