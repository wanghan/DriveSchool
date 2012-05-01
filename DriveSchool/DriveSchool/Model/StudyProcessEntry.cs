using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DriveSchool
{
    class StudyProcessEntry
    {

        public static Dictionary<StudyItem, string> ItemNames = new Dictionary<StudyItem, string> { 
            {StudyItem.MakeCard,"制卡"},
            {StudyItem.ReturnCard,"回卡"},
            {StudyItem.TheoryTestFirst,"理论（初考）"},
            {StudyItem.TheoryTestSecond,"理论（补考）"},
            {StudyItem.StakeTestFirst,"桩考（初考）"},
            {StudyItem.StakeTestSecond,"桩考（补考）"},
            {StudyItem.NineTestFirst,"九项（初考）"},
            {StudyItem.NineTestSecond,"九项（补考）"},
            {StudyItem.RoadTestFirst,"路面（初考）"},
            {StudyItem.RoadTestSecond,"路面（补考）"}
        };

        public string Name
        {
            get
            {
                return ItemNames[this.Item];
            }
        }
        public StudyItem Item { get; set; }
        public string Value { get; set; }

        public StudyProcessEntry(StudyItem item, string value)
        {
            this.Item = item;
            this.Value = value;
        }
    }

    class StudyProcessEntryCollection : ObservableCollection<StudyProcessEntry>
    {

    }
}
