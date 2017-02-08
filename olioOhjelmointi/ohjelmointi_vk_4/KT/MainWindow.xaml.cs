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

namespace KT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string items="";
            foreach (object control in stacky.Children)
            {
                if(control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    if ((bool)checkBox.IsChecked)
                    {
                        if (!(textBox.Text.Contains((string)checkBox.Content)))
                            items += checkBox.Content + " ";
                        checkBox.IsChecked = false;
                    }

                }
            }
            textBox.Text += items;        
        }
    }
}
