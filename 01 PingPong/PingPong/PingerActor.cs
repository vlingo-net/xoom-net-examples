// Copyright (c) 2012-2020 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Actors.TestKit;

namespace Vlingo.Actors.Examples.PingPong
{
    public class PingerActor : Actor, IPinger
    {
        private readonly TestUntil _until;
        private int _count;
        private readonly IPinger _self;

        public PingerActor() : this(null)
        {
        }

        public PingerActor(TestUntil until)
        {
            _until = until;
            _count = 0;
            _self = SelfAs<IPinger>();
        }

        public void Ping(IPonger ponger)
        {
            if(++_count >= 10)
            {
                _self.Stop();
                ponger.Stop();
                Logger.Debug("Enough ping/pong. Stopped now.");
            }
            else
            {
                Logger.Debug($"Ping to ponger with count {_count}");
                ponger.Pong(_self);
            }
        }

        protected override void AfterStop()
        {
            Logger.Debug($"Pinger {Address} just stopped!");
            _until?.Happened();
            base.AfterStop();
        }
    }
}
