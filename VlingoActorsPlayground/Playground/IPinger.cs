using Vlingo.Actors;

namespace Playground
{
    public interface IPinger : IStoppable
    {
        void Ping(IPonger ponger);
    }
}