// Copyright (c) 2012-2020 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System;

namespace Vlingo.Actors.Examples.PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = World.Start("playground");

            var pinger = world.ActorFor<IPinger>(
                () => new PingerActor());

            var ponger = world.ActorFor<IPonger>(
                () => new PongerActor());

            pinger.Ping(ponger);

            Console.WriteLine("Press any key to end the world...");
            Console.ReadKey();

            world.Terminate();
        }
    }
}
