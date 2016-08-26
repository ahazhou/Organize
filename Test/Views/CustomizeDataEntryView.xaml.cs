using System;
using System.Collections.Generic;
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
    public class ForDefaultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
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

        private void AddInfoRow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
