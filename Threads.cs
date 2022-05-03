using System;
using System.Threading;
namespace DiningPhilo
{
    public class Threads
    {
        object _lock = new object();

        public void ThreadWork()
        {
            Thread t1 = new Thread(Take);
            Thread t2 = new Thread(Take);
            Thread t3 = new Thread(Take);
            Thread t4 = new Thread(Take);
            Thread t5 = new Thread(Take);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Name = "0";
            t2.Name = "1";
            t3.Name = "2";
            t4.Name = "3";
            t5.Name = "4";

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
        }

        public void Take()
        {
            while (true)
            {
                int currentThread = Convert.ToInt16(Thread.CurrentThread.Name);
                if (Forks.forks[currentThread] == false && Forks.forks[Forks.AllowedForks[currentThread]] == false)
                {
                    if (Monitor.TryEnter(_lock))
                    {
                        try
                        {
                            Forks.forks[currentThread] = true;
                            Forks.forks[Forks.AllowedForks[currentThread]] = true;

                            Eat(currentThread);

                            Forks.forks[currentThread] = false;
                            Forks.forks[Forks.AllowedForks[currentThread]] = false;

                            Monitor.Exit(_lock);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Philosopher {0} is waiting", currentThread);
                        Thread.Sleep(1000); // For debugging
                    }
                }
            }
        }
        private void Eat(int currentThread)
        {
            Random rnd = new Random();

            Console.WriteLine("Philosopher {0} is eating", currentThread);
            Thread.Sleep(rnd.Next(500, 2000));
            Console.WriteLine("Philosopher {0} is done eating", currentThread);
        }
    }
}