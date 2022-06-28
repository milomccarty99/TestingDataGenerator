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

        public SchedulingInfo ScheduleFinishMergeSort(SchedulingInfo sched)
        {
            if (sched.length <= 1) //base case 
                return sched;

            // recursive case
            int leftLength = sched.length / 2;
            int rightLength = sched.length - leftLength;
            SchedulingInfo left = new SchedulingInfo(leftLength);
            SchedulingInfo right = new SchedulingInfo(rightLength);
            int leftCount = 0, rightCount = 0, schedCount = 0;
            for (int i = 0; i < leftLength; i++)
            {
                left.s[i] = sched.s[schedCount];
                left.f[i] = sched.f[schedCount];
                left.inc[i] = sched.inc[schedCount];
                schedCount++;
            }
            for(int j = 0; j < rightLength; j++)
            {
                right.s[j] = sched.s[schedCount];
                right.f[j] = sched.f[schedCount];
                right.inc[j] = sched.inc[schedCount];
                schedCount++;
            }
            left = ScheduleFinishMergeSort(left);
            right = ScheduleFinishMergeSort(right);

            return Merge(left, right);

        }

        SchedulingInfo Merge(SchedulingInfo left, SchedulingInfo right)
        {
            SchedulingInfo result = new SchedulingInfo(left.length + right.length);
            int leftCount = 0, rightCount = 0;
            for(int i = 0; i < result.length; i++)
            {
                if(leftCount < left.length && rightCount < right.length)
                {
                    if (left.f[leftCount] <= right.f[rightCount])
                    {
                        //transfter elements of left at leftCount
                        result.f[i] = left.f[leftCount];
                        result.s[i] = left.s[leftCount];
                        result.inc[i] = left.inc[leftCount];
                        leftCount++;
                    }
                    else
                    {
                        result.f[i] = right.f[rightCount];
                        result.s[i] = right.s[rightCount];
                        result.inc[i] = right.inc[rightCount];
                        rightCount++;
                    }
                }
                else if (leftCount < left.length)
                {
                    result.f[i] = left.f[leftCount];
                    result.s[i] = left.s[leftCount];
                    result.inc[i] = left.inc[leftCount];
                    leftCount++;
                }
                else if (rightCount < right.length)
                {
                    result.f[i] = right.f[rightCount];
                    result.s[i] = right.s[rightCount];
                    result.inc[i] = right.inc[rightCount];
                    rightCount++;
                }
            }

            return result;
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
