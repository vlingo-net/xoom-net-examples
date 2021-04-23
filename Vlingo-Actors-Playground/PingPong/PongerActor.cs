// Copyright (c) 2012-2021 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System;

namespace Vlingo.Xoom.Actors.Examples.PingPong
{
    public class PongerActor : Actor, IPonger
    {
        private readonly IPonger _self;

        public PongerActor() => _self = SelfAs<IPonger>();

        public void Pong(IPinger pinger)
        {
            Console.WriteLine($"Ponging back to pinger...");
            pinger.Ping(_self);
        }
    }
}
