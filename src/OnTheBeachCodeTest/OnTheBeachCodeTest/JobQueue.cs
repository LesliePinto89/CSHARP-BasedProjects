using System;
using System.Collections.Generic;

namespace OnTheBeachCodeTest
{
    class JobQueue
    {
        private readonly List<string> jobAssignments;
        private string jobProcesses;
        private List<Job> allJobs = Job.getJobs();
        private List<char> orderedJobs = new List<char>();

        public string HasDependancy(string jobString) {

                if (jobString[0] == jobString[jobString.Length - 1]) {
                    return jobString[0].ToString();
                }

                else if (Char.IsLetter(jobString[jobString.Length - 1]))  //Add job with dependancy
                {
                    new Job((char)jobString[0], String.Concat(jobString[1], jobString[2]), jobString[3]);
                }
                else
                {
                    new Job((char)jobString[0], String.Concat(jobString[1], jobString[2]));
                }
        
              return new string ("");
        }
        public JobQueue(string currentJobProcesses) {
            this.jobProcesses = currentJobProcesses;
        }

        public string reportConflict(string jobConstruct) {
                string conflict = $"Error: Job ID '{jobConstruct}' can’t depend on itself.";
                return conflict;
        }
        public string AssignJobStructure()
        {
                string jobConstruct = "";
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
                        if (jobConstruct == jobConstruct[0].ToString())
                        {//Needed when conflict is at the end index 
                            string error = reportConflict(jobConstruct);
                            return error;
                        }
                    }
                    break;
                }
                //Add each job and its dependancy if applicable within job strucuture
                else if (Char.IsLetter(jobProcesses[i]))
                {
                    jobConstruct += jobProcesses[i];

                }
                else if (jobProcesses[i] == '\r')  //Signifies no dependancy so go to next job
                {  
                    jobConstruct = HasDependancy(jobConstruct);
                    if (jobConstruct != "") {

                        //Needed when conflict is any index but the last one
                        if (jobConstruct == jobConstruct[0].ToString())
                        {
                            string error = reportConflict(jobConstruct);
                            return error;
                        }
                    }
                    if (jobProcesses.Contains(' '))  //Removes white space as part of vertabim string arguement input
                    {
                        jobProcesses = jobProcesses.Replace(" ", String.Empty);
                    }
                }
                else if (jobProcesses[i] == '=') //Add job dependancy operator =>
                {
                    jobConstruct += string.Concat(jobProcesses[i], jobProcesses[++i]);
                }
                else if (jobProcesses[i] == '\n') {
                    //No jobs left, used for single job with / without dependancy
                    if(jobProcesses.Length == i+1) {
                        break;
                    }
                    
                }
                }
            return "Passed";
        }

        public string BreakdownJobs()
        {    
            for (int i = 0; i < allJobs.Count;i++ ) {

                // + if dependee and dependor is in ordered list (by this point, this is the part where the circular dependency triggers), return error message
                if (orderedJobs.Contains(allJobs[i].DependancyName) && orderedJobs.Contains(allJobs[i].Name))
                {
                    return new string($"Error: Jobs cant have circular dependancies. Last trace in user input that confirms " +
                        $"circular dependancy is from {allJobs[i].Name} => {allJobs[i].DependancyName}");
                }

                // + if A job has no dependancy, add that job to list. e.g   a =>. Also when their no dependancy but it was a depender ealier
                // so  b => f  and then last value could be f =>
                else if (allJobs[i].DependancyName == 0 && orderedJobs.Contains(allJobs[i].Name) == false)
                {
                    orderedJobs.Add(allJobs[i].Name);
                }

                else if (allJobs[i].DependancyName != 0)
                {
                    //+ if depender in list and dependee is not, add dependee only a => and then b => c and then c => f  and then ----> (d => a)
                    if (orderedJobs.Contains(allJobs[i].DependancyName) && orderedJobs.Contains(allJobs[i].Name) == false)
                    {
                        orderedJobs.Add(allJobs[i].Name);
                    }
                    else
                    {
                        orderedJobs.Add(allJobs[i].DependancyName);  //Add depender first
                        orderedJobs.Add(allJobs[i].Name);  //Add dependee second
                       
                        //Handles when no more jobs after this point
                        if (i == allJobs.Count - 1)
                        {
                            break;
                        }
                    }

                    //Edge case if input is something like: a=> b=>c  c=>d  d=>  f=>a e=>f");
                    if (orderedJobs.Count != allJobs.Count) { 
                        // + if a job flow's depender is not in list, add that depender to list and then add dependee. e.g b => c

                        //+ if next index's job name (dependee) is in list (in this case was a depender previously) and its depedancy is not,
                        //add that index's job depender and not that index's job name (dependee)  e.g. b => -->(c)<---  and then c => f
                        if (orderedJobs.Contains(allJobs[i + 1].Name) && orderedJobs.Contains(allJobs[i + 1].DependancyName) == false)
                        {
                            //This skips  values such as f=> which could have been c=> f, so when f=> comes up, dont add it's non existing dependancu
                            if (allJobs[i + 1].DependancyName != 0)
                            {
                                orderedJobs.Add(allJobs[i + 1].DependancyName);
                            }
                            i++;
                        }

                    /*    // This is when a circular dependancy occurs at the end of the iteration where it contains duplicate values 
                        // from the stored sequence If next index's job name (dependee) is in list (in this case was a depender previously)          
                        // and has depender, move index dont add anything e.g c => e d => c and then e => d 
                        else if (orderedJobs.Contains(allJobs[i + 1].Name) && orderedJobs.Contains(allJobs[i + 1].DependancyName))
                        {
                            //Edge case just in case
                            return new string($"Error: Circular dependancy from {allJobs[i].Name} => {allJobs[i].DependancyName}");
                        }*/
                }
                }
            }
            return "Nearly Done";
            }

        public string PrioritiseJobs() {
            Boolean shiftChange = false;
            int indexToMove;

            for (int i = allJobs.Count-1; i >= 0; i--) {
                char currentDepender = allJobs[i].DependancyName;
                char currentDependee = allJobs[i].Name;
                if (allJobs[i].DependancyName == 0) {
                    continue;
                }
                else 
                {
                    if (!shiftChange)
                    {
                        shiftChange = true;
                        indexToMove = orderedJobs.IndexOf(allJobs[i].DependancyName);
                        orderedJobs.Remove(currentDependee);
                        orderedJobs.Insert(indexToMove + 1, currentDependee);
                    }
                    else
                    {
                        indexToMove = orderedJobs.IndexOf(allJobs[i].Name);
                        orderedJobs.Remove(currentDepender);
                        if (indexToMove == 0) {
                            indexToMove++;
                        }
                        orderedJobs.Insert(indexToMove -1, currentDepender);
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
