using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private bool searchType;

        public Search()
        {
            InitializeComponent();
            aSearch = new List<DonorDetail>();
            triggeredSearch = true;
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
        /// <param name="currentRecord">string version of user typed object</param>
        /// <returns>an array to check if user object match DB entity object</returns>
        public Boolean[] UserSearchMatchRecord(List<string> currentRecord) {
            Boolean[] foundParts = {
                currentRecord.Any(x => birthYear == 0 ? false : x.Contains(birthYear.ToString())),
                currentRecord.Any(x =>toFind.Gender.Trim().Equals("") ? false :x.ToLower().Contains(toFind.Gender.ToLower())),
                currentRecord.Any(x =>toFind.Ethnicity.Trim().Equals("") ? false :x.ToLower().Contains(toFind.Ethnicity.ToLower())),
                currentRecord.Any(x =>toFind.BloodType.Trim().Equals("") ? false :x.ToLower().Contains(toFind.BloodType.ToLower())),
                currentRecord.Any(x =>toFind.RHFactor.Trim().Equals("") ? false :x.Contains(toFind.RHFactor))
                    };
            return foundParts;
        }

        public void BroadSearch(Boolean[] currentRecord, DonorDetail record)
        {
           Boolean[] foundParts = {
           record.DOB.Value.Year == birthYear,
           record.Gender.Trim() == genderText.Text,
           record.Ethnicity.Trim() == ethnicityText.Text,
           record.BloodType.Trim() == bloodTypeText.Text,
           record.RHFactor.Trim() == rhFactorText.Text
            };

            if (foundParts.SequenceEqual(currentRecord))
                        aSearch.Add(record);  
        }

        public Boolean[] CheckForMatch(DonorDetail aDonor) {
            List<string> temp = DbToCustomObject(aDonor);
            Boolean[] isFound = UserSearchMatchRecord(temp);
            int trueCounter = 0;
            foreach (bool check in isFound)
            {
                if (check)
                    trueCounter++;
            }
            if (trueCounter == isFound.Count() && searchType)
            {
                aSearch.Add(aDonor);
                return new bool[] { };
            }
            else if (trueCounter > 0 && !searchType)
                return isFound;
            
            return null;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var currentYear = DateTime.Now.Year;
            if (ageText.Text.Equals(String.Empty) == false)
                birthYear = currentYear - Int32.Parse(ageText.Text.Trim());

            //Affects search type in process
            TypeOfSearch();
            bool checkEmpty = SharedFunctions.CheckEmptyOnly(this);

            if (!checkEmpty)
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
                        if (TypeOfSearch() == false)  //broad search
                        {
                            if (!start)
                            {
                                similarRecords = CheckForMatch(record);
                                //dummy array to say exact search is done
                               
                                if (similarRecords == null)
                                    continue;
                                else if (similarRecords.Count() == 0)
                                    break;
                                else
                                start = true;
                            }
          
                            BroadSearch(similarRecords, record);
                        }
                    }
                    ChangeSearchStatus(true);
                    SharedFunctions.ViewAllRecords(this);
                }
            }
            else
                MessageBox.Show($"No search data added");
        }

        /// <summary>
        /// If true, then all boxes have data, so its an
        /// exact search
        /// </summary>
        /// <returns></returns>
        public bool TypeOfSearch() {
            searchType = true;
            foreach (TextBox tb in SharedFunctions.FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "")
                {
                    searchType = false;
                    break;
                }
            }
            return searchType;
        }
        private void CancelSend_Click(object sender, RoutedEventArgs e)
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