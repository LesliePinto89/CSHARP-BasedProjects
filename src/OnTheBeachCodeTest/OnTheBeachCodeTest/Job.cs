using System;
using System.Collections.Generic;
using System.Text;

namespace OnTheBeachCodeTest
{
    class Job
    {
        private  char job;
        private  string jobOperator;
        private  char dependancy;
        private static List<Job> jobList = new List<Job>();

        public Job()
        {
        }
        public Job(char aJob, string aJobOperator, char aDependancy)
        {
            this.job = aJob;
            this.jobOperator = aJobOperator;
            this.dependancy = aDependancy;
            AddJob();

        }

        public Job(char aJob, string aJobOperator)
        {
            this.job = aJob;
            this.jobOperator = aJobOperator;
            AddJob();
        }

        public void AddJob()
        {
            jobList.Add(this);
        }

        public static List<Job> getJobs()
        {
            return jobList;
        }

        public char Name
        {
            get { return this.job; }
            set { job = value; }

        }
      
        public string Operator { get { return this.jobOperator; } }
        public char DependancyName { get { return this.dependancy; } }

        public override string ToString()
        {
            if (dependancy == 0)
            {
                return new string($"{job}{jobOperator}");
            }
            else
            {
                return new string($"{job}{jobOperator}{dependancy}");
            }
        }
    }
}
