using System;

namespace Vlingo.Actors.Examples.PingPong
{
    public interface IPinger : IStoppable
    {
        void Ping(IPonger ponger);
    }
}
