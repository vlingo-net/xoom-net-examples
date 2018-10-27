using System;

namespace Vlingo.Actors.Examples.PingPong
{
    public interface IPonger : IStoppable
    {
        void Pong(IPinger pinger);
    }
}
