namespace Vlingo.Actors.Examples.PingPong
{
    public class PingerActor : Actor, IPinger
    {
        private int count;
        private readonly IPinger self;

        public PingerActor()
        {
            count = 0;
            self = SelfAs<IPinger>();
        }

        public void Ping(IPonger ponger)
        {
            if(++count >= 10)
            {
                self.Stop();
                ponger.Stop();
                System.Console.WriteLine("Enough ping/pong. Stopped now.");
            }
            else
            {
                ponger.Pong(self);
            }
        }
    }
}
