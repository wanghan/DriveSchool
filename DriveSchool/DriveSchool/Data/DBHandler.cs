using System.Data.SQLite;
using System;
using System.Text;
using DriveSchool.Properties;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using DbLinq.Data.Linq;

namespace DriveSchool
{
    class DBHandler
    {
        private SQLiteConnection connection;
        private volatile static DBHandler _instance = null;
        private StudentDataContext dataContext;
        private static readonly object padlock = new object();

        private DBHandler()
        {
            this.connection = new SQLiteConnection();
            string datasource = ConfigurationManager.AppSettings["DataSource"].ToString(); 
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = datasource;
            this.connection.ConnectionString = connstr.ToString();
            this.connection.Open();

            this.dataContext = new StudentDataContext(this.connection);
        }

        public static DBHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DBHandler();
                        }
                    }
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        public void Insert(Student student)
        {
            this.dataContext.StudentTable.InsertOnSubmit(student);
        }

        public void Delete(Student student)
        {
            this.dataContext.StudentTable.DeleteOnSubmit(student);
        }

        public void SubmitChanges()
        {
            this.dataContext.SubmitChanges();
        }

        public bool HasPendingChange()
        {
            ChangeSet changeSet = this.dataContext.GetChangeSet();
            if (changeSet.Deletes.Count == 0 &&
                changeSet.Inserts.Count == 0 &&
                changeSet.Updates.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public StudentCollection QueryAll()
        {
            StudentCollection result = new StudentCollection();

            IEnumerator<Student> iterator = this.dataContext.StudentTable.GetEnumerator();
            while (iterator.MoveNext())
            {
                result.Add(iterator.Current);
            }
            return result;
        }

        public void Close()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
            Instance = null;
        }

        public void TestInsert()
        {

            Student stu1 = new Student() { Name = "stu''1", Identity = "2202014986146513541", Contact = "1212", StartTime = DateTime.Parse("2012-1-1"), EndTime = DateTime.Parse("2012-2-1") };
            Student stu2 = new Student() { Name = "stu2", Identity = "2202014981212113541", Contact = "1212", StartTime = DateTime.Parse("2012-1-1") };
            StudentCollection _allStudents = new StudentCollection();

            StudentDataContext dc = new StudentDataContext(this.connection);
            dc.StudentTable.InsertOnSubmit(stu2);

            dc.SubmitChanges();
        }
    }
}
