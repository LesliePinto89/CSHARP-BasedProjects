using NUnit.Framework;
using OnTheBeachChallenge;
using System.Collections.Generic;

namespace OnTheBeachTests
{
    public class Tests
    {
        private string testSample;
        private string testSampleTwo;
        private string testSampleThree;

        [TestCase]
        public void ChecKEmptySequence()
        {
            testSample = @"";
            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure().Contains("Empty"));

        }

        public void OneJobSequence()
        {
            //A unit test to check for single job is valid, whether it
            //has a dependancy or not
            testSample = @"a=>";
            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>") };
            JobAssignment.ReplaceJobs(testJobsAssigned);
            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "a");

            testSample = @"e=>a";
            testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('e'), "=>",new Job('a')) };
            JobAssignment.ReplaceJobs(testJobsAssigned);
            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "ae");
        }

        public void CheckForDependancy()
        {
            //A unit test to check if a given job has a dependancy,
            //to place it in a list before the dependee and move on.

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>") };

            JobAssignment.ReplaceJobs(testJobsAssigned);
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "acb");
        }

        [Test]
        public void JobDependsOnSelf()
        {
            //A unit test of to check if a current job has self-dependancy.
            //Scenerios: First, next or last job has self-dependancy
            testSample = @"a=>a";
            Assert.IsTrue(new JobQueue().HasDependancy(testSample).Contains("a"));
        }

        [Test]
        public void CreateJobAssignment()
        {   //A unit test to check that the job assignments can create be created
            //from the user input string
            testSample = "a=>b";
            testSampleTwo = "a=>";

            // The "" string is when a new job is created and the method returns the
            // next job creation string as an empty string
            Assert.IsTrue(new JobQueue().HasDependancy(testSample) == "");
            Assert.IsTrue(new JobQueue().HasDependancy(testSample) == "");
        }

        [Test]
        public void JobsBreakdownSuccess()
        {   //A unit test to check that the jobs assignments have been broken down into
            //partially prioritized sequence

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>",new Job('f')),
                new JobAssignment(new Job('d'), "=>",new Job('a')),
                new JobAssignment(new Job('e'), "=>",new Job('b')),
                new JobAssignment(new Job('f'), "=>")
            };
            JobAssignment.ReplaceJobs(testJobsAssigned);
            Assert.IsTrue(new JobQueue().BreakdownJobs() == "Nearly Done");

            List<JobAssignment> nonAlphabeticalJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('f'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>",new Job('d')),
                new JobAssignment(new Job('d'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('a')),
                new JobAssignment(new Job('e'), "=>",new Job('f'))
            };
            JobAssignment.ReplaceJobs(nonAlphabeticalJobsAssigned);
            Assert.IsTrue(new JobQueue().BreakdownJobs() == "Nearly Done");
        }

        [Test]
        public void CheckCircularDependancy()
        {   //A unit test to check that the job assignments can create be created
            //from the user input string

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>",new Job('f')),
                new JobAssignment(new Job('d'), "=>",new Job('a')),
                new JobAssignment(new Job('e'), "=>"),
                new JobAssignment(new Job('f'), "=>",new Job('b'))
            };
            JobAssignment.ReplaceJobs(testJobsAssigned);
            Assert.IsTrue(new JobQueue().BreakdownJobs().Contains("circular"));

            //Another jobs queue the has circular dependancy, and is also
            //non alphabetical order on linear user input
            List<JobAssignment> testTwoJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>"),
                new JobAssignment(new Job('c'), "=>",new Job('e')),
                new JobAssignment(new Job('e'), "=>",new Job('d')),
                new JobAssignment(new Job('d'), "=>",new Job('c')),
                new JobAssignment(new Job('f'), "=>",new Job('b'))
            };
            JobAssignment.ReplaceJobs(testTwoJobsAssigned);
            Assert.IsTrue(new JobQueue().BreakdownJobs().Contains("circular"));
        }
    }
}