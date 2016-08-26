using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Test.Models;
using Test.Resources;

namespace Test.ViewModels
{
    public class ObjectListViewModel: INotifyPropertyChanged
    {

        private GetData testdata;
        public ObjectListViewModel()
        {
            testdata = new GetData();
            LoadData();
        }

        private void LoadData()
        {
            testcollection = testdata.GetList().MakeObservableCollection();
        }

        private ListObjectModel addobjectinfo;
        public ListObjectModel AddObjectInfo
        {
            get
            {
                return addobjectinfo;
            }
            set
            {
                addobjectinfo = value;
                RaisePropertyChanged("AddObjectInfo");
            }
        }

        public void AddObject()
        {
            if(addobjectinfo != null)
                AddData(addobjectinfo);
        }
        
        private void AddData(ListObjectModel model)
        {
            if(testcollection == null)
            {
                testcollection = new ObservableCollection<ListObjectModel>();
            }
            testcollection.Add(model);
            RaisePropertyChanged("TestCollection");
        }

        private ObservableCollection<ListObjectModel> testcollection;
        public ObservableCollection<ListObjectModel> TestCollection
        {
            get
            {
                return testcollection;
            }
            set
            {
                testcollection = value;
                RaisePropertyChanged("TestCollection");
            }
        }

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
