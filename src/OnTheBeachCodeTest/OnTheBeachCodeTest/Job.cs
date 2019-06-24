using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnTheBeachCodeTest
{
    class Job
    {
        private readonly List<string> jobAssignments;
        private string orderJob;
        public Job(string aJob) {
           jobAssignments = new List<string>();
            AssignJobStructure(aJob);
        }

        public void AssignJobStructure(string aJob)
        {
                string temp = "";
                for (int i = 0; i <= aJob.Length; i++)
                {
                //End job assignment to list
                if (i == aJob.Length){
                        jobAssignments.Add(temp);
                        temp = "";
                        break;
                    }

                //Add each job and its dependancy if applicable within job strucuture
                else if (Char.IsLetter(aJob[i]))
                    { temp += aJob[i];}

                //Signifies no dependancy so go to next job
                else if (aJob[i] == '\r')
                    {jobAssignments.Add(temp);
                    temp = "";

                    //Removes white space as part of vertabim string arguement input
                    if (aJob.Contains(' '))
                    { aJob = aJob.Replace(" ", String.Empty); }
                }
                    //Add job dependancy operator =>
                    else if (aJob[i] == '=')
                    {temp += aJob[i];
                     temp += aJob[++i];}
                }
                prioriseJobs(jobAssignments);
        }

        public void prioriseJobs(List<string> jobAssignments)
        {
            List<string> _orderList = new List<string>();
            if (jobAssignments[0] == "") { orderJob = "No jobs so this is an empty sequence"; }
            else { 
                for (int i = 0; i < jobAssignments.Count; i++)
                {
                    string current = jobAssignments[i];
                    char begin = current.First();
                    char end = current[current.Length - 1];
                    if (Char.IsLetter(end))
                    {
                        var result = current.Select(x => x == begin ? end : (x == end ? begin : x)).ToArray();
                        _orderList.Add(new String(result));
                    }
                    else
                    {
                        _orderList.Add(current);
                    }
                }
            orderJob = string.Join(",", _orderList.ToArray());
            orderJob = orderJob.Replace(",", "\r\n");
        }
        }

        public string getOrderJobs() {
            return orderJob;
        }
  
    }
}
