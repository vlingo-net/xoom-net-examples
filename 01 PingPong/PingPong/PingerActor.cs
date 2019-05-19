// Copyright (c) 2012-2019 Vaughn Vernon. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

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
