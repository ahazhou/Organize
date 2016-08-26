using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Test.Models;
using Test.ViewModels;

namespace Test.Views
{
    public class ForEnumtoVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((entryTypes)value).ToString() == (string)parameter ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
    public class ForComboboxItemChosenVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ForTextAddColonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value) + ":";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Interaction logic for AddObjectView.xaml
    /// </summary>
    public partial class AddObjectView : UserControl
    {
        public AddObjectView(ObjectListViewModel viewmodel)
        {
            this.DataContext = viewmodel;
            InitializeComponent();
        }



        #region Submitting the Object
        public static readonly RoutedEvent SubmitObjectEvent = EventManager.RegisterRoutedEvent("Submit_Click",
                                                                                RoutingStrategy.Bubble,
                                                                                typeof(RoutedEventHandler),
                                                                                typeof(AddObjectView));

        public event RoutedEventHandler Submit_Click
        {
            add { AddHandler(SubmitObjectEvent, value); }
            remove { RemoveHandler(SubmitObjectEvent, value); }
        }

        private void SubmitObject_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SubmitObjectEvent, this));
        }
        #endregion

        #region Cancel the Addition
        public static readonly RoutedEvent CancelEvent = EventManager.RegisterRoutedEvent("Cancel_Click",
                                                                                RoutingStrategy.Bubble,
                                                                                typeof(RoutedEventHandler),
                                                                                typeof(AddObjectView));

        public event RoutedEventHandler Cancel_Click
        {
            add { AddHandler(CancelEvent, value); }
            remove { RemoveHandler(CancelEvent, value); }
        }
        private void CancelObject_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CancelEvent, this));
        }
        #endregion
    }
}
