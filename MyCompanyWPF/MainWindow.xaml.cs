using System;
using System.Collections.Generic;
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

namespace MyCompanyWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void ComboBoxItem_Hello(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBoxItem_Work(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Bye(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {

            ChangeDep changeDep = new ChangeDep();
            changeDep.Owner = this;
            changeDep.Show();
           
        }

        private void Button_Click_Del(object sender, RoutedEventArgs e)
        {

        }
    }
}
