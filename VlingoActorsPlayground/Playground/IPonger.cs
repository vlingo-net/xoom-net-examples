using Vlingo.Actors;

namespace Playground
{
    public interface IPonger : IStoppable
    {
        void Pong(IPinger pinger);
    }
}