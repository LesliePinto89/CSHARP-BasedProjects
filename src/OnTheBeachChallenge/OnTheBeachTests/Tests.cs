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
        [TestCase]
        public void OneJobSequence()
        {
            //A integration test to check no dependancy input
            //of a single assignments is broken into a final sequence
            testSample = @"a =>";

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>")};
            JobAssignment.ReplaceJobs(testJobsAssigned);

            List<char> brokenDownJobs = new List<char> {
           'a'};
            JobQueue.SetOrderJobs(brokenDownJobs);

            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "a");
        }
        [TestCase]
        public void MultipleJobsNoOrder()
        {
            //A integration test to check no dependancy input
            //of multiple assignments are broken into a final sequence
            testSample = @"a => 
                           b => 
                           c =>";

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>"),
                new JobAssignment(new Job('c'), "=>") };
            JobAssignment.ReplaceJobs(testJobsAssigned);

            List<char> brokenDownJobs = new List<char> {
           'a','b','c'};
            JobQueue.SetOrderJobs(brokenDownJobs);

            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "abc");
        }
        [TestCase]
        public void CheckForDependancy()
        {
            //A integration test to check if a given job has a dependancy,
            //to place it in a list before the dependee and move on.
            testSample = @"a => 
                           b => c 
                           c =>";

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>") };
            JobAssignment.ReplaceJobs(testJobsAssigned);

            List<char> brokenDownJobs = new List<char> {
           'a','c','b'};

            JobQueue.SetOrderJobs(brokenDownJobs);
            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "acb");
        }



        [Test]
        public void JobDependsOnSelf()
        {
            //A unit test of to check if a current job has self-dependancy.
            //Scenerios: First, next or last job has self-dependancy
            testSample = @"a=>a";
            Assert.IsTrue(new JobQueue().HasDependancy(testSample).Contains("can't depend on itself"));
        }

        [Test]
        public void JobsBreakdownSuccess()
        {   //An intregration test to check that the jobs assignments have been broken down into
            //partially prioritized sequence
            testSample = @"a => 
                           b => c 
                           c => f
                           d => a
                           e => b
                           f =>" ;

            List<JobAssignment> testJobsAssigned = new List<JobAssignment> {
                new JobAssignment(new Job('a'), "=>"),
                new JobAssignment(new Job('b'), "=>",new Job('c')),
                new JobAssignment(new Job('c'), "=>",new Job('f')),
                new JobAssignment(new Job('d'), "=>",new Job('a')),
                new JobAssignment(new Job('e'), "=>",new Job('b')),
                new JobAssignment(new Job('f'), "=>")
            };
            JobAssignment.ReplaceJobs(testJobsAssigned);

            List<char> brokenDownJobs = new List<char> {
           'a','c','b','f','d','e'};

            JobQueue.SetOrderJobs(brokenDownJobs);

            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "fcbead");

            //Assert.IsTrue(new JobQueue().BreakdownJobs() == "Nearly Done");
            /////////////////////////////////////////////////////////////////
            //Circular dependancy is decteced while breaking down the input into
            //non fully prioritised jobs, so passing in a complete list to test
            //without checking a defined dependancy schema is misread as a Circular dependancy
            //and fails test.
        }
        [Test]
        public void NonChronologicalJobsBreakdownSuccess()
        {   //Similar to JobsBreakdownSuccess() but uses non alphabetically ordered,
            //custom depedancy job schema. Program is designed to follow instructions
            //in job scheme.
            testSample = @"a => 
                           f => c 
                           c => d
                           d => 
                           b => a
                           e => f";

            List<JobAssignment> nonAlphabeticalJobsAssigned = new List<JobAssignment> {
             new JobAssignment(new Job('a'), "=>"),
             new JobAssignment(new Job('f'), "=>",new Job('c')),
             new JobAssignment(new Job('c'), "=>",new Job('d')),
             new JobAssignment(new Job('d'), "=>"),
             new JobAssignment(new Job('b'), "=>",new Job('a')),
             new JobAssignment(new Job('e'), "=>",new Job('f')) };
            JobAssignment.ReplaceJobs(nonAlphabeticalJobsAssigned);

            List<char> brokenDownJobs = new List<char> {
           'a','c','f','d','b','e'};

            JobQueue.SetOrderJobs(brokenDownJobs);

            Assert.IsTrue(new JobQueue(testSample).AssignJobStructure() == "Passed");
            Assert.IsTrue(new JobQueue().PrioritiseJobs() == "dcfeab");
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
