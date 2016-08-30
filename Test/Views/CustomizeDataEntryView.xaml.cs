using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.Models;
using Test.ViewModels;

namespace Test.Views
{
    /// <summary>
    /// Interaction logic for CustomizeDataEntryView.xaml
    /// </summary>
    public partial class CustomizeDataEntryView : UserControl
    {
        public CustomizeDataEntryView(ObjectListViewModel viewmodel)
        {
            this.DataContext = new CustomizeDataEntryViewModel(viewmodel);
            InitializeComponent();
            
        }

        private void SaveInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddItem();
        }

        private void AddField_Click(object sender, RoutedEventArgs e)
        {
            string currentlist = (sender as Button).Tag as string;
            ViewModel.AddItem(currentlist);
        }

        private void RemoveField_Click(object sender, RoutedEventArgs e)
        {
            string currentobject = (sender as Button).Tag as string;
            ViewModel.RemoveDetailField(currentobject);
        }

        private void RemoveDataField_Click(object sender, RoutedEventArgs e)
        {
            //may cause issues with slowing the program (space vs time)
            string currentlistname = (sender as Button).Tag as string;
            string currentitem = ((sender as Button).FindName("CurrentItem") as TextBox).Text;
            ViewModel.RemoveDetailField(currentlistname, currentitem);
        }

        private CustomizeDataEntryViewModel ViewModel
        {
            get
            {
                return this.DataContext as CustomizeDataEntryViewModel;
            }
        }
    }
}
