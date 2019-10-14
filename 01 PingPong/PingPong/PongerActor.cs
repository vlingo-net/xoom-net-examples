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
    public class PongerActor : Actor, IPonger
    {
        private readonly TestUntil _until;
        private readonly IPonger self;

        public PongerActor(TestUntil until)
        {
            _until = until;
            self = SelfAs<IPonger>();
        }

        public void Pong(IPinger pinger)
        {
            Console.WriteLine($"Ponger {this.Address} - Doing Pong...");
            pinger.Ping(self);
            _until.Happened();
        }

        protected override void AfterStop()
        {
            Console.WriteLine($"Ponger {this.Address} just stopped!");
            _until.Happened();
        }
    }
}
