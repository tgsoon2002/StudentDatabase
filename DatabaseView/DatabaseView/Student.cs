using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseView
{
    enum status { current, pending, graduate, cancel };
    enum visaStatus { F1, M1, other };
    class Student
    {


        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public status status { get; set; }
        public bool FinaAid { get; set; }
        public visaStatus visaStats { get; set; }
        public bool fullTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DOB { get; set; }
        public string Note { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public int CellPhone { get; set; }
        public int HomePhone { get; set; }

        //public string Details
        //{
        //    get
        //    {
        //        return String.Format("{0} {1} was born on {2}", this.FName, this.LName, this.DOB.ToLongDateString());
        //    }
        //}    
    }
}
