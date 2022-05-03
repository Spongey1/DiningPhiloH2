using System;

namespace DiningPhilo
{
    class Program
    {
        static void Main(string[] args)
        {
            Threads threads = new Threads();
            threads.ThreadWork();
        }
    }
}
