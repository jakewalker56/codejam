using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace _2013_CodeJame_Prelims
{
    class Problem3
    {
        StreamReader sr;
        StreamWriter sw;
        public Problem3(string infile, string outfile)
        {
            sr = new StreamReader(infile);
            sw = new StreamWriter(outfile);
        }
        public bool isPalendrome(BigInteger num)
        {
            string str = num.ToString();
            //Console.WriteLine(String.Format("parsing string {0}", str));
            int iter = str.Length / 2;
            int length = str.Length;
            for (int i = 0; i < iter; i++)
            {
                if (str[i] != str[length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public void Execute()
        {
            //Algorithm: take square root of lower bound, square root of upper bound
                           //for each integer in this set, if it is a palendrome
                                //square it, and if square is palindrome, increment success counter

            //problem: the limits go up to 10 ^ 14 and 10^100... square root of 10^100 is 10^50, which doesn't represent in a standard int 32 or int 64 
                //use BigInteger.  Double should go up to 1.7*10^308, but I'm a bit worried about precision...

            //Dear Google:
                //I implemented this and ran it on your big input #1, and I ran over my 8 minute time limit (I was on pace for about 40 minutes, so I was substantially over)
                //But seriously guys, you're going to give us a perf problem disguised as an algorithm problem, and then give us only one chance to get it right?  There's no way
                //to test a perf problem without a large dataset.  You should have at least given us a big data set to play with.  C'mon guys.

                //obviously the right answer is to precompute all fair and square values from 1-10^14, then just check if the values are in the given range.  But that's only obvious
                //after you realize it's a perf problem....

            //precompute array
            int successCount = 0;
            for (BigInteger i = 1; i < BigInteger.Pow(10, 50) + 1; i++)
            {
                if (isPalendrome(i))
                {
                    if (isPalendrome(i * i))
                    {
                        Console.WriteLine(String.Format("{0}", i));
                        sw.WriteLine(String.Format("{0}", i));
                        successCount++;
                    }
                }
            }
            Console.WriteLine(String.Format("Found {0} fair and square"), successCount);
            /*
            int NumCases = int.Parse(sr.ReadLine());
            for (int k = 0; k < NumCases; k++)
            {
                string sizeLine = sr.ReadLine();
                //Console.WriteLine(String.Format("read line as size values: {0}", sizeLine));
                double lowerSquaredBound = double.Parse(sizeLine.Split(' ')[0]);
                double upperSquaredBound = double.Parse(sizeLine.Split(' ')[1]);
                BigInteger successCount = 0;

                //we should round the lower bound up (e.g if lower bound is 2, sqrt(2) gives 1.4..., and we should NOT include 1)
                BigInteger lowerBound = (BigInteger)Math.Ceiling(Math.Sqrt(lowerSquaredBound));

                //we should round the upper bound down (e.g if uppper bound is 8, sqrt(8) gives 2.7..., and we should NOT include 3)
                BigInteger upperBound = (BigInteger)Math.Floor(Math.Sqrt(upperSquaredBound));
             
                //make sure it's inclusive of upper bound
                for (BigInteger i = lowerBound; i < upperBound + 1; i++)
                {
                    if (isPalendrome(i))
                    {
                        if (isPalendrome(i * i))
                        {
                            successCount++;
                        }
                    }
                }
                

                sw.WriteLine(String.Format("Case #{0}: {1}", k + 1, successCount));
            }*/


            sw.Close();
            sr.Close();
        }
    }
}
