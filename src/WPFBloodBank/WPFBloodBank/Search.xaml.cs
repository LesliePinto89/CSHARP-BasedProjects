using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFBloodBank
{
    public partial class Search : Window
    {
        //private List<DonorDetail> aggreateSearch;
        private DonorDetail toFind;
        private static List<DonorDetail> aSearch;
        private static bool triggeredSearch = false;
        private int birthYear = 0;
        private string searchType = "";

        public Search()
        {
            InitializeComponent();
            aSearch = new List<DonorDetail>();
            triggeredSearch = true;
            SharedFunctions.FullSizeWindow(this);
        }

        private void Data_Click(object sender, RoutedEventArgs e)
        {
            ChangeSearchStatus(false);
            SharedFunctions.ViewAllRecords(this);
        }

        public static List<DonorDetail> FoundMatches()
        {
            return aSearch;
        }

        public static bool TriggeredSearch()
        {
           return triggeredSearch;
        }

        public static void ChangeSearchStatus(bool status)
        {
            triggeredSearch = status;
        }

        public List<string> DbToCustomObject(DonorDetail aDonor) {
            List<string> temp = new List<string>
            {
                aDonor.DOB.ToString(),
                aDonor.Gender,
                aDonor.Ethnicity,
                aDonor.BloodType,
                aDonor.RHFactor
            };
            return temp;
        }

        /// <summary>
        /// Exact search match: All boxes have value and are found
        /// Broad search match: Missing boxes counted as true
        /// to find all related matches to individual valid text,
        /// and all records if all boxes have empty content
        /// </summary>
        /// <param name="x">string version of user typed object</param>
        /// <returns>an array to check if user object match DB entity object</returns>
        public Boolean[] UserSearchMatchRecord(List<string> x) {
            Boolean[] foundParts =  {
                    birthYear == 0 ? false : x[0].Contains(birthYear.ToString()),
               toFind.Gender.Trim().Equals("") ? false : x[1].Trim().ToLower().Equals(toFind.Gender.ToLower()),
               toFind.Ethnicity.Trim().Equals("") ? false : x[2].Trim().ToLower().Equals(toFind.Ethnicity.ToLower()),
               toFind.BloodType.Trim().Equals("") ? false : x[3].Trim().ToLower().Equals(toFind.BloodType.ToLower()),
               toFind.RHFactor.Trim().Equals("") ? false : x[4].Trim().Equals(toFind.RHFactor)
                        };
            
            return foundParts;
        }

        public void GetAllMatches(Boolean[] currentRecord, DonorDetail record)
        {
            List<string> temp = DbToCustomObject(record);
            Boolean[] foundParts = UserSearchMatchRecord(temp);
            if (foundParts.SequenceEqual(currentRecord))
                        aSearch.Add(record);  
        }

        public void UpdateSearchType(string status) {
            searchType = status;
        }


        public Boolean[] CheckForMatch(DonorDetail aDonor) {
            List<string> temp = DbToCustomObject(aDonor);
            Boolean[] isFound = UserSearchMatchRecord(temp);

/*            //When user fails validation 
            if (isFound ==null)
                return null;*/

            //If no match at all of current record to user input
            int allFalse = isFound.Where(x => x == false).Count();
            if (allFalse == isFound.Count()) 
                return null;

            //If exact match found, no more will exist, so stop searching
            int allTrue = isFound.Where(x => x == true).Count();
            if (allTrue == isFound.Count())
                UpdateSearchType("exact");

            return isFound;

        }

        public bool Validation() {
            Match match = Regex.Match(bloodTypeText.Text, "^([A-Z]+\\-)(Positive|Negative)$");
            if (!match.Success && bloodTypeText.Text.Equals("") == false)
            {
                MessageBox.Show("Incorrect format");
                return false;
            }
            return true;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var currentYear = DateTime.Now.Year;
            if (ageText.Text.Equals(String.Empty) == false)
                birthYear = currentYear - Int32.Parse(ageText.Text.Trim());

            bool passed = Validation();
            bool checkEmpty = SharedFunctions.CheckEmptyOnly(this);
            if (!checkEmpty) //First validation
            {
                if (passed) //Second validation
                {
                    toFind = new DonorDetail
                    {
                        Gender = genderText.Text.Trim(),
                        Ethnicity = ethnicityText.Text.Trim(),
                        BloodType = bloodTypeText.Text.Trim(),
                        RHFactor = rhFactorText.Text.Trim()
                    };

                    using (var context = new UserRegistrationDBEntities())
                    {
                        bool start = false;
                        Boolean[] similarRecords = null;
                        var records = context.DonorDetails;
                        foreach (var record in records)
                        {
                            if (!start)
                            {
                                similarRecords = CheckForMatch(record);
                                if (similarRecords == null)
                                    continue;
                                start = true;
                            }
                            GetAllMatches(similarRecords, record);
                            if (searchType.Equals("exact"))
                                break;
                        }
                        ChangeSearchStatus(true);
                        SharedFunctions.ViewAllRecords(this);
                    }
                }
            }
            else
                MessageBox.Show($"No search data added");
        }

 
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ChangeSearchStatus(false);
            SharedFunctions.GoHomeOnly(this);
        }

        private void homeFromReg_Click(object sender, RoutedEventArgs e)
        {
            ChangeSearchStatus(false);
            SharedFunctions.GoHomeOnly(this);
        }
    }
}