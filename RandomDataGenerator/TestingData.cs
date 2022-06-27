using System;
using System.Collections.Generic;
using System.Text;

namespace RandomDataGenerator
{
    class TestingData
    {
        int highRange;
        int lowRange;
        int length;
        Random rand;
        public TestingData(Random random)
        {
            this.rand = random; 
            
        }

        //outputs two correlated arrays S and F as SchedulingInfo for scheduling problem
        public SchedulingInfo GenerateRandomSchedule(int n, int cNum)
        {
            SchedulingInfo sched = new SchedulingInfo(cNum);
            
            for(int i = 0; i < cNum; i++)
            {
                int classStart = rand.Next(n- 1);
                int classFinish = rand.Next(classStart+ 1, n);
                sched.s[i] = classStart;
                sched.f[i] = classFinish;
            }
            return sched;
        }
        // matrix of values for sample data to text file
        //integer array of values between high and low.
        //double array of values between high and low.
        //float array of values between high and low.

        SchedulingInfo ScheduleFinishMergeSort(SchedulingInfo sched)
        {
            return sched;
        }
}


    class SchedulingInfo
    {
        public int[] s;
        public int[] f;
        public bool[] inc;
        public int length;
        public SchedulingInfo(int len)
        {
            this.length = len;
            s = new int[len];
            f = new int[len];
            inc = new bool[len];
        }
        public SchedulingInfo GetSubSection(int start, int end)
        {
            SchedulingInfo result = new SchedulingInfo(end - start);
            for(int i = start; i < end; i++)
            {
                result.s[i - start] = this.s[i];
                result.f[i - start] = this.f[i];
                result.inc[i - start] = this.inc[i];
            }
            return result;
        }

        public void Swap(int first, int second)
        {
            int ste = this.s[first];
            int fte = this.f[first];
            bool incte = this.inc[first];
            this.s[first] = this.s[second];
            this.f[first] = this.f[second];
            this.inc[first] = this.inc[second];
            this.s[second] = ste;
            this.f[second] = fte;
            this.inc[second] = incte;
        }
    }
}
