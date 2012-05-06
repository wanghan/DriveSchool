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
        public Student()
        {
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

            foreach (StudyItem key in Enum.GetValues(typeof(StudyItem)))
            {
                this.StudyItemSetter(key, "");
                string newValue = item.StudyItemGetter(key);
                this.StudyItemSetter(key, newValue);
            }
        }
    }
}
