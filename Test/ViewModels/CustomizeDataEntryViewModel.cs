using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class CustomizeDataEntryViewModel: INotifyPropertyChanged
    {
        public CustomizeDataEntryViewModel(object viewmodel)
        {
            if(viewmodel is ObjectListViewModel)
            {
                loadObjectDetails(viewmodel as ObjectListViewModel);
            }
        }

        private ObservableCollection<ObjectDetailsInfo> objectinformation;
        public ObservableCollection<ObjectDetailsInfo> ObjectInformation
        {
            get
            {
                return objectinformation;
            }
            set
            {
                objectinformation = value;
                RaisePropertyChanged("ObjectInformation");
            }
        }

        private string selectitem;
        public string SelectItem
        {
            get
            {
                return selectitem;
            }
            set
            {
                selectitem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }


        public void loadObjectDetails(ObjectListViewModel viewmodel)
        {
            ObjectDetailsInfo hi = new ObjectDetailsInfo();
            hi.ObjectDetailName = "baby";
            hi.OptionsEntryMethod = entryTypes.ComboBox;
            hi.OptionsEntryNames = new List<string> { "one", "two", "three" };
            ObjectDetailsInfo hi1 = new ObjectDetailsInfo();
            hi1.ObjectDetailName = "baby1";
            hi1.OptionsEntryMethod = entryTypes.TextBox;
            hi1.OptionsEntryNames = new List<string> { "1", "2", "3" };
            ObjectDetailsInfo hi2 = new ObjectDetailsInfo();
            hi2.ObjectDetailName = "baby2";
            hi2.OptionsEntryMethod = entryTypes.RadioButton;
            hi2.OptionsEntryNames = new List<string> { "11", "22", "33" };

            ObjectInformation = viewmodel.AddObjectInfo.ObjectDetails;
            if(ObjectInformation == null)
            {
                ObjectInformation = new ObservableCollection<ObjectDetailsInfo>();
            }
            ObjectInformation.Add(hi);
            ObjectInformation.Add(hi1);
            ObjectInformation.Add(hi2);
        }

        public void updateObjectDetails()
        {

        }

        public void addObjectDetails()
        {

        }
        
        public void deleteObjectDetails()
        {

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
