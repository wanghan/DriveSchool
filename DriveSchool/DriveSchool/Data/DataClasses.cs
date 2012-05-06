namespace DriveSchool
{

    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Linq.Mapping;
    using System.Diagnostics;
    using DbLinq.Data.Linq;
    using DbLinq.Vendor;

    class StudentDataContext : DataContext
    {
        public StudentDataContext(IDbConnection connection)
            : base(connection, new DbLinq.Sqlite.SqliteVendor())
        {
        }

        public StudentDataContext(IDbConnection connection, IVendor vendor)
            : base(connection, vendor)
        {
        }

        public Table<Student> StudentTable { get { return GetTable<Student>(); } }

    }

    [Table(Name = "main.student")]
    partial class Student : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged handling

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region string Contact

        private string _contact;
        [DebuggerNonUserCode]
        [Column(Storage = "_contact", Name = "Contact", DbType = "TEXT")]
        public string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                if (value != _contact)
                {
                    _contact = value;
                    OnPropertyChanged("Contact");
                }
            }
        }

        #endregion

        #region DateTime? EndTime

        private DateTime? _endTime;
        [DebuggerNonUserCode]
        [Column(Storage = "_endTime", Name = "EndTime", DbType = "DATETIME")]
        public DateTime? EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (value != _endTime)
                {
                    _endTime = value;
                    OnPropertyChanged("EndTime");
                }
            }
        }

        #endregion

        #region int ID

        private int _id;
        [DebuggerNonUserCode]
        [Column(Storage = "_id", Name = "Id", DbType = "INTEGER", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        #endregion

        #region string Identity

        private string _identity;
        [DebuggerNonUserCode]
        [Column(Storage = "_identity", Name = "Identity", DbType = "TEXT")]
        public string Identity
        {
            get
            {
                return _identity;
            }
            set
            {
                if (value != _identity)
                {
                    _identity = value;
                    OnPropertyChanged("Identity");
                }
            }
        }

        #endregion

        #region string MakeCard

        private string _makeCard;
        [DebuggerNonUserCode]
        [Column(Storage = "_makeCard", Name = "MakeCard", DbType = "TEXT")]
        public string MakeCard
        {
            get
            {
                return _makeCard;
            }
            set
            {
                if (value != _makeCard)
                {
                    _makeCard = value;
                    OnPropertyChanged("MakeCard");
                }
            }
        }

        #endregion

        #region string Name

        private string _name;
        [DebuggerNonUserCode]
        [Column(Storage = "_name", Name = "Name", DbType = "TEXT")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        #endregion

        #region string NineTestFirst

        private string _nineTestFirst;
        [DebuggerNonUserCode]
        [Column(Storage = "_nineTestFirst", Name = "NineTestFirst", DbType = "TEXT")]
        public string NineTestFirst
        {
            get
            {
                return _nineTestFirst;
            }
            set
            {
                if (value != _nineTestFirst)
                {
                    _nineTestFirst = value;
                    OnPropertyChanged("NineTestFirst");
                }
            }
        }

        #endregion

        #region string NineTestSecond

        private string _nineTestSecond;
        [DebuggerNonUserCode]
        [Column(Storage = "_nineTestSecond", Name = "NineTestSecond", DbType = "TEXT")]
        public string NineTestSecond
        {
            get
            {
                return _nineTestSecond;
            }
            set
            {
                if (value != _nineTestSecond)
                {
                    _nineTestSecond = value;
                    OnPropertyChanged("NineTestSecond");
                }
            }
        }

        #endregion

        #region string Note

        private string _note;
        [DebuggerNonUserCode]
        [Column(Storage = "_note", Name = "Note", DbType = "TEXT")]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                if (value != _note)
                {
                    _note = value;
                    OnPropertyChanged("Note");
                }
            }
        }

        #endregion

        #region string ReturnCard

        private string _returnCard;
        [DebuggerNonUserCode]
        [Column(Storage = "_returnCard", Name = "ReturnCard", DbType = "TEXT")]
        public string ReturnCard
        {
            get
            {
                return _returnCard;
            }
            set
            {
                if (value != _returnCard)
                {
                    _returnCard = value;
                    OnPropertyChanged("ReturnCard");
                }
            }
        }

        #endregion

        #region string RoadTestFirst

        private string _roadTestFirst;
        [DebuggerNonUserCode]
        [Column(Storage = "_roadTestFirst", Name = "RoadTestFirst", DbType = "TEXT")]
        public string RoadTestFirst
        {
            get
            {
                return _roadTestFirst;
            }
            set
            {
                if (value != _roadTestFirst)
                {
                    _roadTestFirst = value;
                    OnPropertyChanged("RoadTestFirst");
                }
            }
        }

        #endregion

        #region string RoadTestSecond

        private string _roadTestSecond;
        [DebuggerNonUserCode]
        [Column(Storage = "_roadTestSecond", Name = "RoadTestSecond", DbType = "TEXT")]
        public string RoadTestSecond
        {
            get
            {
                return _roadTestSecond;
            }
            set
            {
                if (value != _roadTestSecond)
                {
                    _roadTestSecond = value;
                    OnPropertyChanged("RoadTestSecond");
                }
            }
        }

        #endregion

        #region string StakeTestFirst

        private string _stakeTestFirst;
        [DebuggerNonUserCode]
        [Column(Storage = "_stakeTestFirst", Name = "StakeTestFirst", DbType = "TEXT")]
        public string StakeTestFirst
        {
            get
            {
                return _stakeTestFirst;
            }
            set
            {
                if (value != _stakeTestFirst)
                {
                    _stakeTestFirst = value;
                    OnPropertyChanged("StakeTestFirst");
                }
            }
        }

        #endregion

        #region string StakeTestSecond

        private string _stakeTestSecond;
        [DebuggerNonUserCode]
        [Column(Storage = "_stakeTestSecond", Name = "StakeTestSecond", DbType = "TEXT")]
        public string StakeTestSecond
        {
            get
            {
                return _stakeTestSecond;
            }
            set
            {
                if (value != _stakeTestSecond)
                {
                    _stakeTestSecond = value;
                    OnPropertyChanged("StakeTestSecond");
                }
            }
        }

        #endregion

        #region DateTime? StartTime

        private DateTime? _startTime;
        [DebuggerNonUserCode]
        [Column(Storage = "_startTime", Name = "StartTime", DbType = "DATETIME")]
        public DateTime? StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (value != _startTime)
                {
                    _startTime = value;
                    OnPropertyChanged("StartTime");
                }
            }
        }

        #endregion

        #region string TheoryTestFirst

        private string _theoryTestFirst;
        [DebuggerNonUserCode]
        [Column(Storage = "_theoryTestFirst", Name = "TheoryTestFirst", DbType = "TEXT")]
        public string TheoryTestFirst
        {
            get
            {
                return _theoryTestFirst;
            }
            set
            {
                if (value != _theoryTestFirst)
                {
                    _theoryTestFirst = value;
                    OnPropertyChanged("TheoryTestFirst");
                }
            }
        }

        #endregion

        #region string TheoryTestSecond

        private string _theoryTestSecond;
        [DebuggerNonUserCode]
        [Column(Storage = "_theoryTestSecond", Name = "TheoryTestSecond", DbType = "TEXT")]
        public string TheoryTestSecond
        {
            get
            {
                return _theoryTestSecond;
            }
            set
            {
                if (value != _theoryTestSecond)
                {
                    _theoryTestSecond = value;
                    OnPropertyChanged("TheoryTestSecond");
                }
            }
        }

        #endregion

        #region ctor
        #endregion

    }
}