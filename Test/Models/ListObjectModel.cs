using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
    public enum entryTypes { TextBox, ComboBox, RadioButton }
    public class ObjectDetailsInfo
    {
        public string ObjectDetailName
        {
            get;
            set;
        }
        public entryTypes OptionsEntryMethod
        {
            get;
            set;
        }
        public List<string> OptionsEntryNames
        {
            get;
            set;
        }
    }

    public class ListObjectModel : INotifyPropertyChanged
    {

        public string Name
        {
            get;
            set;
        }

        public ObservableCollection<ObjectDetailsInfo> ObjectDetails
        {
            get;
            set;
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
