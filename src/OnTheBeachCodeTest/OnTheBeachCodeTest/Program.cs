using System;
using System.Collections.Generic;

namespace OnTheBeachCodeTest
{
    class Program
    {
        public static void runJobs(string jobProcesses)
        {
            JobQueue startJob = new JobQueue(jobProcesses);
            string intialStatus = startJob.AssignJobStructure();
            if (intialStatus == "Passed")
            {
                string nextStageStatus = startJob.BreakdownJobs();
                if (nextStageStatus == "Nearly Done")
                {
                    string completeSequence = startJob.PrioritiseJobs();
                    Console.WriteLine($"The final sequence is: {completeSequence}");
                }
                else
                {  //status is either conflict error message or return empty sequence
                    Console.WriteLine(nextStageStatus);
                }
            }
            //Empty sequence returned here
            else {
                Console.WriteLine(intialStatus);
            }
            startJob.ResetJobProcessing();
        }
            

            static void Main(string[] args)
        {

            //Given you’re passed an empty string (no jobs), the result should be an empty sequence.
             string jobType = @"";
             runJobs(jobType);

            //The result should be a sequence consisting of a single job a.
             jobType = @"a=>";
             runJobs(jobType);

            jobType = new string (@"a=>b");
              runJobs(jobType);

              //The result should be a sequence that positions c before b, containing all three jobs abc.
              jobType = new string(@"a=>
                                     b=>c
                                     c=>");
              runJobs(jobType);

            //The result should be an error stating that jobs can’t depend on themselves.
            //Stops at the first instance of a conflict, weather its the first, last, or a job in between.
            jobType = new string(@"a=>
                                   b=>
                                   c=>c");
              runJobs(jobType);

              //The result should be a sequence that positions f before c, c before b, 
              //b before e and a before d containing all six jobs abcdef.
              jobType = new string(@"a=>
                                    b=>c
                                     c=>f
                                     d=>a
                                     e=>b
                                     f=>");
              runJobs(jobType);

              //The result should be an error stating that jobs can’t have circular dependencies.
              jobType = new string(@"a=>
                                      b=>c
                                      c=>f
                                      d=>a
                                      e=>
                                      f=>b");
              //"System works by checking for existing entries in the sequence when both are encounter in
              //a new job pairing dependacy" 
              runJobs(jobType);

              //EXTRA job processes for more functionality////

              //Non alphabetical input
              jobType = new string(@"a=>
                                     f=>c
                                     c=>d
                                     d=>
                                     b=>a
                                     e=>f");
              runJobs(jobType);

              //Mixed input check for circular dependancy
              jobType = new string(@"a=>
                                     b=>
                                     c=>e
                                     e=>d
                                     d=>c
                                     f=>b");
              runJobs(jobType);
        }
       
    }
}
