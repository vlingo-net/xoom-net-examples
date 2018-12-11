using Vlingo.Actors;
using Vlingo.Actors.TestKit;

namespace Playground
{
    public class PingerActor : Actor, IPinger
    {
        private readonly IPinger _self;
        private readonly TestUntil _until;
        private int _count;


        public PingerActor(TestUntil until)
        {
            _count = 0;
            _self = SelfAs<IPinger>();
            _until = until;
        }

        public void Ping(IPonger ponger)
        {
            ++_count;
            Logger.Log("ping " + _count);
            if (_count >= 10)
            {
                _self.Stop();
                ponger.Stop();
            }
            else
            {
                ponger.Pong(_self);
            }
        }


        protected override void AfterStop()
        {
            Logger.Log("" +
                       "Pinger" +
                       $"  {Address} just stopped!");
            _until.Happened();
            base.AfterStop();
        }
    }
}