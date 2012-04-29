using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DriveSchool
{
    class Student : ModelBase, INotifyPropertyChanged
    {
        public enum StudyItem
        {
            MakeCard = 1,
            ReturnCard = 2,
            TheoryTestFirst = 3,
            TheoryTestSecond = 4,
            StakeTestFirst = 5,
            StakeTestSecond = 6,
            NineTestFirst = 7,
            NineTestSecond = 8,
            RoadTestFirst = 9,
            RoadTestSecond = 10
        }

        private string _name;
        private string _identity;
        private string _contact;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _note;
        private Dictionary<StudyItem, string> _studyProcess;

        public Student()
        {
            this._studyProcess = new Dictionary<StudyItem, string>();
        }

        #region BaseInfo property

        public string Name
        {
            get { return _name; }
            set { this._name = value; this.RaisePropertyChanged("Name"); }
        }

        public string Identity
        {
            get { return _identity; }
            set { this._identity = value; this.RaisePropertyChanged("Identity"); }
        }

        public string Contact
        {
            get { return _contact; }
            set { this._contact = value; this.RaisePropertyChanged("Contact"); }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set { this._startTime = value; this.RaisePropertyChanged("StartTime"); }
        }

        public DateTime EndTime
        {
            get { return _endTime; }
            set { this._endTime = value; this.RaisePropertyChanged("EndTime"); }
        }

        public string Note
        {
            get { return _note; }
            set { this._note = value; this.RaisePropertyChanged("Note"); }
        }

        #endregion

        #region Study process property
        public string MakeCard
        {
            get { return StudyItemGetter(StudyItem.MakeCard); }
            set { StudyItemSetter(StudyItem.MakeCard, value); }
        }

        public string ReturnCard
        {
            get { return StudyItemGetter(StudyItem.ReturnCard); }
            set { StudyItemSetter(StudyItem.ReturnCard, value); }
        }

        public string TheoryTestFirst
        {
            get { return StudyItemGetter(StudyItem.TheoryTestFirst); }
            set { StudyItemSetter(StudyItem.TheoryTestFirst, value); }
        }

        public string TheoryTestSecond
        {
            get { return StudyItemGetter(StudyItem.TheoryTestSecond); }
            set { StudyItemSetter(StudyItem.TheoryTestSecond, value); }
        }

        public string StakeTestFirst
        {
            get { return StudyItemGetter(StudyItem.StakeTestFirst); }
            set { StudyItemSetter(StudyItem.StakeTestFirst, value); }
        }

        public string StakeTestSecond
        {
            get { return StudyItemGetter(StudyItem.StakeTestSecond); }
            set { StudyItemSetter(StudyItem.StakeTestSecond, value); }
        }

        public string NineTestFirst
        {
            get { return StudyItemGetter(StudyItem.NineTestFirst); }
            set { StudyItemSetter(StudyItem.NineTestFirst, value); }
        }

        public string NineTestSecond
        {
            get { return StudyItemGetter(StudyItem.NineTestSecond); }
            set { StudyItemSetter(StudyItem.NineTestSecond, value); }
        }

        public string RoadTestFirst
        {
            get { return StudyItemGetter(StudyItem.RoadTestFirst); }
            set { StudyItemSetter(StudyItem.RoadTestFirst, value); }
        }

        public string RoadTestSecond
        {
            get { return StudyItemGetter(StudyItem.RoadTestSecond); }
            set { StudyItemSetter(StudyItem.RoadTestSecond, value); }
        }

        #endregion

        private void StudyItemSetter(StudyItem item, string value)
        {
            this._studyProcess[item] = value;
            this.RaisePropertyChanged(item.ToString());
        }

        private string StudyItemGetter(StudyItem item)
        {
            if (this._studyProcess.ContainsKey(item))
            {
                return this._studyProcess[item];
            }
            return "";
        }

        public void CloneFrom(Student item)
        {
            this.Name = item.Name;
            this.Identity = item.Identity;
            this.StartTime = item.StartTime;
            this.Contact = item.Contact;
            this.EndTime = item.EndTime;
            this.Note = item.Note;
            this._studyProcess.Clear();
            foreach (StudyItem key in item._studyProcess.Keys)
            {
                this._studyProcess[key] = item._studyProcess[key];
            }
        }
    }
}
