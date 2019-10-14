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
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.Start("playground");
            var until = TestUntil.Happenings(1);

            var pinger = world.ActorFor<IPinger>(
                Definition.Has<PingerActor>(
                    Definition.Parameters(until)));

            var ponger = world.ActorFor<IPonger>(
                Definition.Has<PongerActor>(
                    Definition.Parameters(until)));

            pinger.Ping(ponger);

            until.Completes();

            world.Terminate();

            Console.WriteLine("Press any key to end the world...");
            Console.ReadKey();
        }
    }
}
