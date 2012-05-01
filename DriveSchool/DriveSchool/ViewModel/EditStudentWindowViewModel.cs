using System;
using System.Windows;
using System.Windows.Input;

namespace DriveSchool
{
    class EditStudentWindowViewModel : ModelBase
    {
        private Student _currentStudent;
        private StudyProcessEntryCollection _studyProcesses;
        private StudyProcessEntry _selectedStudyProcessEntry;

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

                foreach (StudyItem key in Enum.GetValues(typeof(StudyItem)))
                {
                    string value=_currentStudent.StudyItemGetter(key);
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        _studyProcesses.Add(new StudyProcessEntry(key, value));
                    }
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
            set { this._studyProcesses = value; }
        }

        public StudyProcessEntry SelectedStudyProcessEntry
        {
            get { return this._selectedStudyProcessEntry; }
            set
            {
                this._selectedStudyProcessEntry = value;
                this.RaisePropertyChanged("SelectedStudyProcessEntry");
            }
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
                this._currentStudent.ClearStudyProcess();
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

        #region Edit Study Item Command

        public ICommand EditStudyItemCommand
        {
            get { return new RelayCommand(EditStudyItemExecute, CanEditStudyItemExecute); }
        }

        Boolean CanEditStudyItemExecute()
        {
            if (this.SelectedStudyProcessEntry != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void EditStudyItemExecute()
        {
            
        }

        #endregion

        #region Add Study Item Command

        public ICommand AddStudyItemCommand
        {
            get { return new RelayCommand(AddStudyItemExecute, CanAddStudyItemExecute); }
        }

        Boolean CanAddStudyItemExecute()
        {
            return true;
        }

        void AddStudyItemExecute()
        {
        }

        #endregion

        #region Remove Study Item Command

        public ICommand RemoveStudyItemCommand
        {
            get { return new RelayCommand(RemoveStudyItemExecute, CanRemoveStudyItemExecute); }
        }

        Boolean CanRemoveStudyItemExecute()
        {
            if (this.SelectedStudyProcessEntry != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void RemoveStudyItemExecute()
        {
            string message = String.Format("确认删除当前项: {0}", this.SelectedStudyProcessEntry.Name);
            MessageBoxResult confirm = MessageBox.Show(message, "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                this.StudyProcesses.Remove(this.SelectedStudyProcessEntry);
            }
        }

        #endregion

        bool IsStringNotEmpty(string s)
        {
            return s == null || string.IsNullOrWhiteSpace(s);
        }
    }
}
