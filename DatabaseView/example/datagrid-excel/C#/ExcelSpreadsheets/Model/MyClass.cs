using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ExcelSpreadsheets.Model
{
    public class MyClass : INotifyPropertyChanged
    {
        public enum UserTypes
        {
            TypeA,
            TypeB,
            TypeC,
            TypeD,
            TypeE
        }
        public enum JobStatuses
        {
            Idle,
            Working,
            Pass,
            Fail
        }
       public  int UserID{get; set;}
       // public int UserID
        //{
        //    get ;
        //    set;
        //    //{
        //    //    return _UserID;
        //    //}
        //    //set
        //    //{
        //    //    if (_UserID != value)
        //    //    {
        //    //        _UserID = value;
        //    //        RaisePropertyChanged("UserID");
        //    //    }
        //    //}
        //}

       public string FName{get; set;}
       public string LName { get; set; }
       public string MName { get; set; }
       // public string Name
        //{
        //    get ;
        //    set;
        //    //get
        //    //{
        //    //    return _Name;
        //    //}
        //    //set
        //    //{
        //    //    if (_Name != value)
        //    //    {
        //    //        _Name = value;
        //    //        RaisePropertyChanged("Name");
        //    //    }
        //    //}
        //}

       public  UserTypes Type {get; set;}
       // public UserTypes Type
        //{
        //    get ;
        //    set;
        //    //get
        //    //{
        //    //    return _Type;
        //    //}
        //    //set
        //    //{
        //    //    if (_Type != value)
        //    //    {
        //    //        _Type = value;
        //    //        RaisePropertyChanged("Type");
        //    //    }
        //    //}
        //}

       public JobStatuses JobStatus { get; set; }
       // public JobStatuses JobStatus
        //{
        //    get;
        //    set;
        //    //get
        //    //{
        //    //    return _JobStatus;
        //    //}
        //    //set
        //    //{
        //    //    if (_JobStatus != value)
        //    //    {
        //    //        _JobStatus = value;
        //    //        RaisePropertyChanged("JobStatus");
        //    //    }
        //    //}
        //}


        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}
