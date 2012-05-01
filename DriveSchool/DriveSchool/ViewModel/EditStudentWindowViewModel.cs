using System;
using System.Windows;
using System.Windows.Input;

namespace DriveSchool
{
    class EditStudentWindowViewModel : ModelBase
    {
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

        public EditStudentWindowViewModel(Student student, Window window)
        {
            if (student == null)
            {
                _currentStudent = new Student();
                _currentStudent.StartTime = DateTime.Now;
                this.IsForNew = true;
            }
            else
            {
                _currentStudent = student;
                this.IsForNew = false;
            }

            this.CurrentWindow = window;
        }

        private Student _currentStudent;
        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set { this._currentStudent = value; }
        }


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

        bool IsStringNotEmpty(string s)
        {
            return s == null || string.IsNullOrWhiteSpace(s);
        }
    }
}
