using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class AddObjectViewModel
    {
        public AddObjectViewModel(ObjectListViewModel viewmodel)
        {
            Collection = new ObservableCollection<ListObjectModel>();
            foreach(var o in viewmodel.TestCollection)
            {
                //collection is empty need to fix it
                Collection.Add(o.Clone() as ListObjectModel);
            }
        }

        private ObservableCollection<ListObjectModel> collection;
        public ObservableCollection<ListObjectModel> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }

    }
}
