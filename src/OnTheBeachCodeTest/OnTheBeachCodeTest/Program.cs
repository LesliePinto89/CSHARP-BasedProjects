using System;
using System.Collections.Generic;

namespace OnTheBeachCodeTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //Empty det
            Job _emptyJobs = new Job(" ");


            Job _startJob = new Job(@"a =>
                                       b =>c
                                       b =>");

            

            Console.WriteLine(new string(_startJob.getOrderJobs()));






        }
    }
}
