using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Input;
using System;

namespace DriveSchool
{
    class MainWindowViewModel : ModelBase
    {
        private IList<Student> _students;
        private CollectionView _searchConditions;
        private Student _selectedItem;
        public ICommand ExitCommand
        {
            get;
            private set;
        }

        public MainWindowViewModel()
        {
            this._students = new List<Student>();

            Student stu1 = new Student { Name = "stu1", Identity = "2202014986146513541", Contact = "1212", StartTime = "2012-1-1", EndTime = "2012-1-12" };
            stu1.MakeCard = "开始";
            Student stu2 = new Student { Name = "stu2", Identity = "2202014981212113541", Contact = "1212", StartTime = "2012-1-1", EndTime = "2012-1-12" };

            this._students.Add(stu1);
            this._students.Add(stu2);

            IList<SearchConditionEntry> searchConditionList = new List<SearchConditionEntry>();
            searchConditionList.Add(new SearchConditionEntry("姓名"));
            searchConditionList.Add(new SearchConditionEntry("身份证"));
            this._searchConditions = new CollectionView(searchConditionList);
        }

        public IList<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
            }
        }

        public CollectionView SearchConditions
        {
            get { return this._searchConditions; }
        }

        public Student SelectedItem
        {
            get { return this._selectedItem; }
            set
            {
                this._selectedItem = value;
                this.RaisePropertyChanged("SelectedItem");
            }
        }

        public ICommand EditCommand
        {
            get { return new RelayCommand(EditExecute, CanEditExecute); }
        }

        Boolean CanEditExecute()
        {
            if (this.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void EditExecute()
        {
            EditStudentWindow window = new EditStudentWindow();
            window.Show();
        }
    }
}
