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
      

        int id;
        string _FName;
        string _LName;
        string _MName;
        status _status;
        bool _FinaAid;
        visaStatus _visaStats;
        bool _fullTime;
        DateTime _StartDate;
        DateTime _ScheduleDate;
        DateTime _EndDate;
        DateTime _DOB;
        string _Note;
        string _Address;
        string _City;
        string _State;
        int _Zip;
        int _CellPhone;
        int _HomePhone;



        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName
        {
            get { return _FName; }
            set { _FName = value; }
        }
        public string LastName
        {
            get { return _LName; }
            set { _LName = value; }
        }
        public status studentStatus
        {
            get { return _status; }
            set { _status = value; } 
        }
        public bool FinacialAid
        {
            get { return _FinaAid; }
            set { _FinaAid = value; }
        }
        public List<Student> GetEmpList()
        {
            List<Student> temp = new List<Student>();
            temp.Add(new Student() { id = 1, FirstName = "Kien", LastName = "Nguyen" });            
            return temp;
        }
    }
}
