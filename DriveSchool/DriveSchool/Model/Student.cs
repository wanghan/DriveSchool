using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace DriveSchool
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

    partial class Student : ModelBase, INotifyPropertyChanged
    {
        private Dictionary<StudyItem, string> _studyProcess;

        public Student()
        {
            _studyProcess = new Dictionary<StudyItem, string>();
        }

        #region Study Item Getter & Setter

        public void StudyItemSetter(StudyItem item, string value)
        {
            PropertyInfo property = typeof(Student).GetProperty(item.ToString());
            MethodInfo method= property.GetSetMethod();
            method.Invoke(this, new object[] { value });
        }

        public string StudyItemGetter(StudyItem item)
        {
            PropertyInfo property = typeof(Student).GetProperty(item.ToString());
            MethodInfo method = property.GetGetMethod();
            return (string)method.Invoke(this, new object[] { });
        }

        #endregion

        public void CloneFrom(Student item)
        {
            this.Name = item.Name;
            this.Identity = item.Identity;
            this.StartTime = item.StartTime;
            this.Contact = item.Contact;
            this.EndTime = item.EndTime;
            this.Note = item.Note;

            //clear study process items
            foreach (StudyItem key in Enum.GetValues(typeof(StudyItem)))
            {
                this.StudyItemSetter(key, "");
            }

            foreach (StudyItem key in item._studyProcess.Keys)
            {
                this.StudyItemSetter(key, item._studyProcess[key]);
            }
        }

        public void ClearStudyProcess()
        {
            if (this._studyProcess != null)
            {
                this._studyProcess.Clear();
            }
        }
    }
}
