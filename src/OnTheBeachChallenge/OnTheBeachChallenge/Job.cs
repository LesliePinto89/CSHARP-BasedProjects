using System;
using System.Collections.Generic;
using System.Text;

namespace OnTheBeachChallenge
{
    /// <summary>
    /// In the specification, a job is defined by a name and this class represents both a potential
    /// dependee and it's dependor. While adding both values as char in the JobAssignment class
    /// issues names to complete the challenge, it's not best standard (i.e. Single responsibility), 
    /// and is not scalable to add future hypothetical support, e.g. adding a job's payload, date, etc.
    /// </summary>
    public class Job
    {
        private readonly char jobName;

        public Job(char aJob)
        {
            this.jobName = aJob;
        }
        public char Name
        {
            get { return this.jobName; }
        }
    }
}
