using System;
using System.Collections.Generic;
using System.Text;

namespace OnTheBeachChallenge
{
    public class JobAssignment
    {
        private readonly Job dependee;
        private readonly string jobOperator;
        private readonly Job dependor;
        private static List<JobAssignment> jobList = new List<JobAssignment>();

        

        public JobAssignment()
        {
        }
      
        public JobAssignment(Job aDependeeJob, string aJobOperator, Job aDependorJob)
        {
            this.dependee = aDependeeJob;
            this.jobOperator = aJobOperator;
            this.dependor = aDependorJob;
            AddJob();
        }

        public JobAssignment(Job aDependeeJob, string aJobOperator)
        {
            this.dependee = aDependeeJob;
            this.jobOperator = aJobOperator;
            AddJob();
        }

        public void AddJob()
        {
            jobList.Add(this);
        }

        public static List<JobAssignment> getJobs()
        {
            return jobList;
        }

        public static void ReplaceJobs(List<JobAssignment> inputList)
        {
            jobList = inputList;
        }
        

        public Job Dependee
        {
            get { return this.dependee; } 
        }

        public string Operator { get { return this.jobOperator; } }

        public Job Dependor
        {
            get { return this.dependor; }
        }

        public override string ToString()
        {
            if (dependor.Name == 0)
            {
                return new string($"{dependee.Name}{jobOperator}");
            }
            else
            {
                return new string($"{dependee.Name}{jobOperator}{dependor.Name}");
            }
        }
    }
}
