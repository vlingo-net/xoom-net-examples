// Copyright © 2012-2020 VLINGO LABS. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using Vlingo.Actors;
using Vlingo.Actors.Examples.PingPong;
using Vlingo.Actors.TestKit;
using Xunit;

namespace PingPong.Tests
{
    public class PlaygroundTest
    {
        [Fact]
        public void TestPlayPingPong()
        {
            var world = World.StartWithDefaults("playground");
            var until = TestUntil.Happenings(1);
            var pinger = world.ActorFor<IPinger>(() => new PingerActor(until));
            var ponger = world.ActorFor<IPonger>(() => new PongerActor());

            pinger.Ping(ponger);

            until.Completes();

            world.Terminate();
        }
    }
}