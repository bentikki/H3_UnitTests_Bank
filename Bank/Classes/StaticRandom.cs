using System;
using System.Threading;

namespace Bank.Classes
{
    public static class StaticRandom
    {
        private static int seed = Environment.TickCount;

        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand()
        {
            return random.Value.Next();
        }

        public static int Rand(int start, int end)
        {
            return random.Value.Next(start, end);
        }

        public static int Rand(int max)
        {
            return random.Value.Next(max);
        }
    }
}