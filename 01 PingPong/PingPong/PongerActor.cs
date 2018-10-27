namespace Vlingo.Actors.Examples.PingPong
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
            pinger.Ping(self);
        }
    }
}
