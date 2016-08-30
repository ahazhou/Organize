using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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


        public void loadObjectDetails(ObjectListViewModel viewmodel)
        {
            ObjectDetailsInfo hi = new ObjectDetailsInfo();
            hi.ObjectDetailName = "baby";
            hi.OptionsEntryMethod = entryTypes.ComboBox;
            hi.OptionsEntryNames = new ObservableCollection<OptionsDataNames> { new OptionsDataNames("1"), new OptionsDataNames("2"), new OptionsDataNames("3") };
            hi.key = 0;
            ObjectDetailsInfo hi1 = new ObjectDetailsInfo();
            hi1.ObjectDetailName = "baby1";
            hi1.OptionsEntryMethod = entryTypes.TextBox;
            hi1.OptionsEntryNames = new ObservableCollection<OptionsDataNames> { new OptionsDataNames("a"), new OptionsDataNames("b"), new OptionsDataNames("c") };
            hi1.key = 1;
            ObjectDetailsInfo hi2 = new ObjectDetailsInfo();
            hi2.ObjectDetailName = "baby2";
            hi2.OptionsEntryMethod = entryTypes.RadioButton;
            hi2.OptionsEntryNames = new ObservableCollection<OptionsDataNames> { new OptionsDataNames("1a"), new OptionsDataNames("2b"), new OptionsDataNames("3c") };
            hi2.key = 2;

            ObjectInformation = viewmodel.AddObjectInfo.ObjectDetails;
            //initialize deep copy instead here but later
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

        public void AddItem()
        {
            ObjectInformation.Add(new ObjectDetailsInfo());
        }

        public void AddItem(string currentlistname)
        {
            ObservableCollection<OptionsDataNames> o = (ObjectInformation.FirstOrDefault(x => x.ObjectDetailName == currentlistname)).OptionsEntryNames;
            o.Add(new OptionsDataNames());
        }


        public void RemoveDetailField(string currentobject)
        {
            ObjectInformation.Remove(ObjectInformation.FirstOrDefault(z => z.ObjectDetailName == currentobject));
        }

        public void RemoveDetailField(string currentlistname, string currentitem)
        {
            ObservableCollection<OptionsDataNames> o = (ObjectInformation.FirstOrDefault(x => x.ObjectDetailName == currentlistname)).OptionsEntryNames;
            o.Remove(o.FirstOrDefault(z => z.DataName == currentitem));
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
