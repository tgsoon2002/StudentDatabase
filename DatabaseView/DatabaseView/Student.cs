﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseView
{
    
    public class Student
    {

        public enum status
        {
            current,
            pending,
            graduate,
            cancel
        }
        public enum visaStatus
        {
            F1,
            M1,
            other
        }
        public enum gender
        { Men,Women}
        public enum byage
        {
         Under18,
         eigteento24,
         twentyfivetothirtynine ,
         fourtyplus
        }
        public enum ethic
        {            
            Asian  ,           
            Hispanic_Latino ,           
            American_Native,            
            Non_resident_ailen,            
            Africa_American,            
            Pacific_Islander,            
            White,           
            Two_or_More,            
            unknown            
        }

        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public status Status { get; set; }
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
        public double CellPhone { get; set; }
        public int HomePhone { get; set; }
        public gender Gender { get; set; }
        public int SSN { get; set; }
        public string  driverLicenseNumber { get; set; }
        public byage ByAge { get; set; }
        public string Country { get; set; }
        public string CountryOfPaperWork { get; set; }
        public string  KindOfPaperWork { get; set; }
        public int paperNumber { get; set; }
        public ethic Ethic { get; set; }
        public bool Transfer { get; set; }
        public int HoursTransfer { get; set; }
        public int TotalEnroll { get; set; }
        public int TotalHours { get; set; }
        public bool LeaveOrAbsense { get; set; }
        public bool WithDraw { get; set; }
        public DateTime TheoryExam { get; set; }
        public DateTime PracticeExam { get; set; }
        public string JobPalcement { get; set; }
        public int Sap300 { get; set; }
        public int Sap600 { get; set; }
       
    }
}
