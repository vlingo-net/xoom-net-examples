// Copyright (c) 2012-2019 Vaughn Vernon. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System;
using Vlingo.Actors.TestKit;

namespace Vlingo.Actors.Examples.PingPong
{
    public class PingerActor : Actor, IPinger
    {
        private int count;
        private readonly TestUntil _until;

        public PingerActor(TestUntil until)
        {
            count = 0;
            _until = until;
        }

        public void Ping(IPonger ponger)
        {
            if (++count >= 10)
            {
                this.Stop();
                ponger.Stop();
            }
            else
            {
                Console.WriteLine($"Pinger {this.Address} - Doing Ping...");
                ponger.Pong(this);
            }
        }

        protected override void AfterStop()
        {
            Console.WriteLine("Pinger " + this.Address + " just stopped!");
            _until.Happened();
        }
    }
}
