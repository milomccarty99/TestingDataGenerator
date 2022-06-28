using System;
using System.IO;
namespace RandomDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            TestingData td = new TestingData(new Random());
            SchedulingInfo testSchedule = td.GenerateRandomSchedule(50, 30);
            VisualizeSchedule(testSchedule);
            testSchedule = td.ScheduleFinishMergeSort(testSchedule);
            testSchedule.inc[0] = true;
            int recentFin = testSchedule.f[0];
            for(int i = 0; i< testSchedule.length; i++)
            {
                if(testSchedule.s[i]> recentFin)
                {
                    recentFin = testSchedule.f[i];
                    testSchedule.inc[i] = true;
                }
            }
            VisualizeSchedule(testSchedule);
        }


        static void VisualizeSchedule(SchedulingInfo sched)
        {
            for(int i = 0; i < sched.length; i ++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            for(int i = 0; i < sched.length; i++)
            {
                if (sched.inc[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                for (int p = 0; p < sched.s[i]; p++)
                {
                    Console.Write(" "); // blank space character
                }
                Console.Write("[");
                for(int p = sched.s[i]; p < sched.f[i]; p++)
                {
                    Console.Write("=");
                }
                Console.Write("]");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void SwapFirstTwoInTestSchedule(SchedulingInfo testSchedule)
        {
            testSchedule.Swap(0, 1);
        }
    }
}
