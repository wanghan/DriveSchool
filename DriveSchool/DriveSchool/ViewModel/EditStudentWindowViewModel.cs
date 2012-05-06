using System;
using System.Windows;
using System.Windows.Input;

namespace DriveSchool
{
    class EditStudentWindowViewModel : ModelBase
    {
        private Student _currentStudent;
        private StudyProcessEntryCollection _studyProcesses;

        public EditStudentWindowViewModel(Student student, Window window)
        {
            if (student == null)
            {
                _currentStudent = new Student();
                _currentStudent.StartTime = DateTime.Now;
                this.IsForNew = true;

                _studyProcesses = new StudyProcessEntryCollection();
            }
            else
            {
                _currentStudent = student;
                this.IsForNew = false;

                _studyProcesses = new StudyProcessEntryCollection();
            }

            foreach (StudyItem key in Enum.GetValues(typeof(StudyItem)))
            {
                string value = _currentStudent.StudyItemGetter(key);
                if (value != null)
                {
                    _studyProcesses.Add(new StudyProcessEntry(key, value.Trim()));
                }
                else
                {
                    _studyProcesses.Add(new StudyProcessEntry(key, ""));
                }
            }

            this.CurrentWindow = window;
        }

        public bool IsSaveClicked
        {
            get;
            private set;
        }

        public bool IsForNew
        {
            get;
            private set;
        }

        public Window CurrentWindow
        {
            get;
            private set;
        }

        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set { this._currentStudent = value; }
        }

        public StudyProcessEntryCollection StudyProcesses
        {
            get { return this._studyProcesses; }
        }

        #region Save & Cancel Command
        public ICommand SaveCommand
        {
            get { return new RelayCommand(SaveExecute, CanExecute); }
        }

        public ICommand CancelCommand
        {
            get { return new RelayCommand(CancelExecute, CanExecute); }
        }

        Boolean CanExecute()
        {
            return true;
        }

        void SaveExecute()
        {
            if (Validate())
            {
                foreach (StudyProcessEntry entry in this._studyProcesses)
                {
                    this._currentStudent.StudyItemSetter(entry.Item, entry.Value);
                }
                this.IsSaveClicked = true;
                this.CurrentWindow.Close();
            }
        }

        void CancelExecute()
        {
            this.IsSaveClicked = false;
            this.CurrentWindow.Close();
        }

        bool Validate()
        {
            if (this.CurrentStudent == null)
            {
                MessageBox.Show("当前编辑学员为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (IsStringNotEmpty(this.CurrentStudent.Name))
            {
                MessageBox.Show("学员姓名不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (IsStringNotEmpty(this.CurrentStudent.Identity))
            {
                MessageBox.Show("学员身份证号码不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        #endregion

        bool IsStringNotEmpty(string s)
        {
            return s == null || string.IsNullOrWhiteSpace(s);
        }
    }
}
