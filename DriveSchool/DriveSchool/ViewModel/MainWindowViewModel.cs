using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace DriveSchool
{
    class MainWindowViewModel : ModelBase, INotifyPropertyChanged
    {
        private StudentCollection _students;
        private StudentCollection _filteredStudents;
        private StudentCollection _allStudents;
        private CollectionView _searchConditions;
        private Student _selectedItem;
        private SearchConditionEntry _selelctedSearchConditionEntry;
        private string _searchKeyword;

        public MainWindowViewModel(Window window)
        {
            this.CurrentWindow = window;
            this._allStudents = DBHandler.Instance.QueryAll();
            this._filteredStudents = new StudentCollection();

            this.Students = this._allStudents;

            IList<SearchConditionEntry> searchConditionList = new List<SearchConditionEntry>();
            searchConditionList.Add(new SearchConditionEntry("姓名", SearchCategory.SearchByName));
            searchConditionList.Add(new SearchConditionEntry("身份证", SearchCategory.SearchByIdentity));
            this._searchConditions = new CollectionView(searchConditionList);
            this._searchKeyword = "";
        }

        public Window CurrentWindow
        {
            get;
            private set;
        }

        public ICommand ExitCommand
        {
            get;
            private set;
        }

        public StudentCollection Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                this.RaisePropertyChanged("Students");
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

        public SearchConditionEntry SelectedSearchCondition
        {
            get { return this._selelctedSearchConditionEntry; }
            set
            {
                this._selelctedSearchConditionEntry = value;
                this.RaisePropertyChanged("SelectedSearchCondition");
            }
        }

        public string SearchKeyword
        {
            get { return this._searchKeyword; }
            set
            {
                this._searchKeyword = value;
                this.RaisePropertyChanged("SearchKeyword");
            }
        }

        #region Edit Command

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
            Student editItem = new Student();
            editItem.CloneFrom(this.SelectedItem);
            EditStudentWindowViewModel vm = new EditStudentWindowViewModel(editItem, window);
            window.DataContext = vm;
            window.ShowDialog();
            OnEditComplete(vm);
        }

        #endregion

        #region Add Command

        public ICommand AddCommand
        {
            get { return new RelayCommand(AddExecute, CanAddExecute); }
        }

        Boolean CanAddExecute()
        {
            return true;
        }

        void AddExecute()
        {
            EditStudentWindow window = new EditStudentWindow();
            EditStudentWindowViewModel vm = new EditStudentWindowViewModel(null, window);
            window.DataContext = vm;
            window.ShowDialog();
            OnEditComplete(vm);
        }

        #endregion

        #region Show All Command

        public ICommand ShowAllCommand
        {
            get { return new RelayCommand(ShowAllExecute, CanShowAllExecute); }
        }

        Boolean CanShowAllExecute()
        {
            return true;
        }

        void ShowAllExecute()
        {
            this.Students = this._allStudents;
        }

        #endregion

        #region Save Command

        public ICommand SaveCommand
        {
            get { return new RelayCommand(SaveExecute, CanSaveExecute); }
        }

        Boolean CanSaveExecute()
        {
            return DBHandler.Instance.HasPendingChange();
        }

        void SaveExecute()
        {
            DBHandler.Instance.SubmitChanges();
        }

        #endregion

        #region Remove Command

        public ICommand RemoveCommand
        {
            get { return new RelayCommand(RemoveExecute, CanRemoveExecute); }
        }

        Boolean CanRemoveExecute()
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

        void RemoveExecute()
        {
            string message = String.Format("确认删除当前学员：{0},{1}", this.SelectedItem.Identity, this.SelectedItem.Name);
            MessageBoxResult confirm = MessageBox.Show(message, "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                Student stu = this.SelectedItem;
                this._allStudents.Remove(stu);
                this.Students = this._allStudents;
                DBHandler.Instance.Delete(stu);
            }
        }

        #endregion

        #region Search Command

        public ICommand SearchCommand
        {
            get { return new RelayCommand(SearchExecute, CanSearchExecute); }
        }

        Boolean CanSearchExecute()
        {
            if (this.SelectedSearchCondition != null && !string.IsNullOrWhiteSpace(this.SearchKeyword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void SearchExecute()
        {
            string keyword=this.SearchKeyword.Trim();

            if (this.SelectedSearchCondition.Category==SearchCategory.SearchByName)
            {
                this._filteredStudents.Clear();
                foreach (Student stu in this._allStudents)
                {
                    if (stu.Name.Contains(keyword))
                    {
                        this._filteredStudents.Add(stu);
                    }
                }

                this.Students = this._filteredStudents;
            }
            else if (this.SelectedSearchCondition.Category == SearchCategory.SearchByIdentity)
            {
                this._filteredStudents.Clear();
                foreach (Student stu in this._allStudents)
                {
                    if (stu.Identity.Contains(keyword))
                    {
                        this._filteredStudents.Add(stu);
                    }
                }

                this.Students = this._filteredStudents;
            }
        }

        #endregion

        void OnEditComplete(EditStudentWindowViewModel vm)
        {
            if (vm.IsSaveClicked)
            {
                if (!vm.IsForNew)
                {
                    this.SelectedItem.CloneFrom(vm.CurrentStudent);
                    ((MainWindow)this.CurrentWindow).ResizeGridViewColumns();
                }
                else
                {
                    Student stu = vm.CurrentStudent;
                    this._allStudents.Add(stu);
                    DBHandler.Instance.Insert(stu);
                    this.Students = this._allStudents;
                    ((MainWindow)this.CurrentWindow).ResizeGridViewColumns();
                }
            }
        }
    }
}
