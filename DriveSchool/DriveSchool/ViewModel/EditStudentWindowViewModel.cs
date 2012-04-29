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

        public bool IsForNow
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
                this.IsForNow = true;
            }
            else
            {
                _currentStudent = student;
                this.IsForNow = false;
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
            this.IsSaveClicked = true;
            this.CurrentWindow.Close();
        }

        void CancelExecute()
        {
            this.IsSaveClicked = false;
            this.CurrentWindow.Close();
        }
    }
}
