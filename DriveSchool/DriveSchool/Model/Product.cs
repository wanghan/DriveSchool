using System.Windows;
using System.ComponentModel;

namespace DriveSchool
{
    class Product : INotifyPropertyChanged
    {

        private int m_ID;
        private string m_Name;
        private double m_Price;

        public event PropertyChangedEventHandler PropertyChanged;

        public Product()
        {
            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) && this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int ID
        {
            get { return m_ID; }
            set
            {
                m_ID = value;
                OnPropertyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Price
        {
            get
            {
                return m_Price;
            }
            set
            {
                m_Price = value;
                OnPropertyChanged("Price");
            }
        }
    }
}
