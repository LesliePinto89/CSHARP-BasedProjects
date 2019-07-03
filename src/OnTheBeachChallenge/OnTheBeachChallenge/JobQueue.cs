using System;
using System.Collections.Generic;

namespace OnTheBeachChallenge
{
    /// <summary>
    /// //This class handles the processing of the given user jobs input into
    /// its priortity position sequence.  
    /// </summary>
    public class JobQueue
    {
        private string jobProcesses;
        //private readonly List<string> jobAssignments;
        private List<JobAssignment> allJobs = JobAssignment.getJobs();
        private List<char> orderedJobs = new List<char>(); //Non-readonly as will be later sorted 

        public JobQueue()
        {
        }

        public JobQueue(string currentJobProcesses)
        {
            this.jobProcesses = currentJobProcesses;
        }
        /// <summary>
        /// Checks if job depends on itself, and if yes return error. If no, add three part job Does one of three action: if jobs depends on itself, stop sequence generation and return error message
        /// Added a unit test via NUnit</summary>
        /// <param name="jobString"></param>
        /// <returns></returns>
        public string HasDependancy(string jobString)
        {
            //Checks is current job's dependancy is it's own dependee 
            if (jobString[0] == jobString[jobString.Length - 1])
            {
                return jobString[0].ToString();
            }
            else if (Char.IsLetter(jobString[jobString.Length - 1]))
            {   //Create dependancy job from string input
                new JobAssignment(new Job(jobString[0]), String.Concat(jobString[1], jobString[2]), new Job(jobString[3])); 
            }
            else
            {   //Create single dependee job from string input
                new JobAssignment(new Job(jobString[0]), String.Concat(jobString[1], jobString[2]));
            }
            return "";
        }
       
        public string ReportConflict(string jobConstruct)
        {
            string conflict = $"Error: Job ID '{jobConstruct}' can’t depend on itself.";
            return conflict;
        }
        /// <summary>
        /// Construct a job assignment through each next line user input
        /// and adds them to a list for further manipulation
        /// Includes unit test via NUnit
        /// </summary>
        /// <param name="unitTestSample">The parameter used from the NUnit
        /// arguement to be added as a job assignemnt to a list</param>
        /// <returns>a string the indicates the status of the job/jobs assignment</returns>
        public string AssignJobStructure()
        {
            string jobConstruct = "";
            int whiteSpaceCounter = -1;
      
            for (int i = 0; i <= jobProcesses.Length; i++)
            {
                //When string contains no jobs, this sequence variable in empty
                if (jobProcesses == "")
                {
                    return $"Empty Sequence: {jobProcesses}";
                }

                else if (i == jobProcesses.Length)
                {  //End job assignment and add to job list
                    jobConstruct = HasDependancy(jobConstruct);
                    if (jobConstruct != "")
                    {
                        //Needed when conflict is at the end index 
                         string error = ReportConflict(jobConstruct);
                         return error; 
                    }
                    break;
                }
                //Add each job and its dependancy if applicable within job strucuture
                else if (Char.IsLetter(jobProcesses[i]))
                {
                    jobConstruct += jobProcesses[i];
                }

                //Add support for first white space to skip as code removes all white spaces
                //later. After the first job assignment after '\r', this method is never used again
                else if (jobProcesses[i] == ' ')
                {   //Each time a white space is encountered the index is increased, but this affects the latter jobs
                    //being read, so when each job assignment finishes (i.e. the \r character), record the number of  
                    //white space read, and decrease the string index by that amount. 
                    whiteSpaceCounter++;
                    continue;
                }

                else if (jobProcesses[i] == '\r')  //Signifies no dependancy so go to next job
                {
                    jobConstruct = HasDependancy(jobConstruct);
                    if (jobConstruct != "")
                    {
                        //Needed when conflict is any index but the last one 
                            string error = ReportConflict(jobConstruct);
                            return error;
                    }
                    if (jobProcesses.Contains(' '))  //Removes white space as part of vertabim string arguement input
                    {
                        jobProcesses = jobProcesses.Replace(" ", String.Empty);
                            i -= whiteSpaceCounter; //Needed only one time  
                    }
                    
                }
                else if (jobProcesses[i] == '=') //Add job dependancy operator =>
                {
                    jobConstruct += string.Concat(jobProcesses[i], jobProcesses[++i]);
                }
                else if (jobProcesses[i] == '\n')
                {
                    //No jobs left, used for single job with / without dependancy
                    if (jobProcesses.Length == i + 1)
                    {
                        break;
                    }
                }
            }
            return "Passed";
        }
        /// <summary>
        /// Following their order of dependancy from top to bottom, add each job
        /// to another list, and skips jobs based on stored jobs encountered.
        /// </summary>
        /// <returns>a string that indicates the status of all job assignments allocated
        /// to the list</returns>
        public string BreakdownJobs()
        {
            for (int i = 0; i < allJobs.Count; i++)
            {
                if (allJobs[i].Dependor != null)
                {// + From this position, if dependee and depender is in ordered list, 
                 //    circular dependency would trigger, so return values in error message
                    if (orderedJobs.Contains(allJobs[i].Dependor.Name) && orderedJobs.Contains(allJobs[i].Dependee.Name))
                    {
                        return new string($"Error: Jobs cant have circular dependancies. Last trace in user input that confirms " +
                            $"circular dependancy is from {allJobs[i].Dependee.Name} => {allJobs[i].Dependor.Name}");
                    }
                    //+ if depender is in list and dependee is not, add dependee only a => and then b => c 
                    // and then reaching (d => a), skip a and add d
                        if (orderedJobs.Contains(allJobs[i].Dependor.Name) && orderedJobs.Contains(allJobs[i].Dependee.Name) == false)
                        {  
                            orderedJobs.Add(allJobs[i].Dependee.Name);
                        }
                    //+ if dependee is in list and dependor is not, add dependor only a => and then b => c 
                    // and then reaching (c => f), skip c and add f
                    else if (orderedJobs.Contains(allJobs[i].Dependee.Name) && orderedJobs.Contains(allJobs[i].Dependor.Name) == false)
                         {
                         orderedJobs.Add(allJobs[i].Dependor.Name);
                         }
                    else
                        { //A new job dependancy not encountered yet e.g  b => c  so add c and then b
                            orderedJobs.Add(allJobs[i].Dependor.Name);  
                            orderedJobs.Add(allJobs[i].Dependee.Name);

                            //Handles when no more jobs after this point
                            if (i == allJobs.Count - 1)
                            {  
                                break;
                            }
                        }   
                }
                // + Function one: A current job not encountered yet with no dependancy, 
                //   add to orderedlist, e.g   a =>. 

                // + Function two: A current job who was a dependor in previous encounter dependancy 
                //  ( which was added to the orderedList with its dependee) is now presented as a 
                //   dependee, so skip it. e.g. b => c, c=>
                else if (orderedJobs.Contains(allJobs[i].Dependee.Name) == false)
                {
                    orderedJobs.Add(allJobs[i].Dependee.Name);
                }
            }
            return "Nearly Done";
        }

        /// <summary>
        /// The input of data had an interested pattern. To make the jobs follow the challenge rules
        /// of f before c, c before b, b before e and a before d, an issue had to be dealt with.
        ///   1) When moving each dependor before its dependee in the ordered list, the result was : f c a d b e
        ///   2) When moving each dependee after its dependor in the ordered list, the result was: a d b e f c

        /// Solution: Move the last pairing's dependee after its dependor once, then move each pairing's dependor
        /// before its dependee.

        /// When checking the first job dependancy in the reverse of the original job pairings, if its dependee is in 
        /// the ordered list, it's given "dependor" in the ordered list needs to be moved "before" the current position 
        /// of that dependee in the ordered list. For all subsequent pairing's, each "dependee" has to be moved "after" 
        /// the current position of its dependor in the ordered list.
        /// </summary>
        /// <returns>The final string sequence of jobs in correct order of precedence </returns>
        public string PrioritiseJobs()
        {
            Boolean shiftChange = false;
            int indexToMove;

            for (int i = allJobs.Count - 1; i >= 0; i--)
            {
                dynamic currentDepender = 0;
                if (allJobs[i].Dependor != null)
                {
                    currentDepender = allJobs[i].Dependor.Name;
                }

                dynamic currentDependee = allJobs[i].Dependee.Name;
                if (currentDepender == 0)
                {
                    continue;
                }
                else
                {
                    if (!shiftChange)
                    {
                        shiftChange = true;
                        indexToMove = orderedJobs.IndexOf(allJobs[i].Dependor.Name);
                        orderedJobs.Remove(currentDependee);
                        orderedJobs.Insert(indexToMove + 1, currentDependee);
                    }
                    else
                    {
                        indexToMove = orderedJobs.IndexOf(allJobs[i].Dependee.Name);
                        orderedJobs.Remove(currentDepender);
                        if (indexToMove == 0)
                        {
                            indexToMove++;
                        }
                        orderedJobs.Insert(indexToMove - 1, currentDepender);
                    }
                }
            }
            return new string(orderedJobs.ToArray());
        }
        public void ResetJobProcessing()
        {
            jobProcesses = "";
            allJobs.Clear();
            orderedJobs.Clear();
        }
    }
}
