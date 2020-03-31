// Copyright (c) 2012-2020 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System;

namespace Vlingo.Actors.Examples.PingPong
{
    public class PingerActor : Actor, IPinger
    {
        private int _count;
        private readonly IPinger _self;

        public PingerActor()
        {
            _count = 0;
            _self = SelfAs<IPinger>();
        }

        public void Ping(IPonger ponger)
        {
            if(++_count >= 10)
            {
                _self.Stop();
                ponger.Stop();
                Console.WriteLine("Enough ping/pong. Stopped now.");
            }
            else
            {
                Console.WriteLine($"Ping to ponger with count {_count}");
                ponger.Pong(_self);
            }
        }
    }
}
