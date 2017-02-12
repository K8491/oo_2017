using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace KT
{
    /// <summary>
    /// Interaction logic for KT2.xaml
    /// </summary>
    public partial class KT2 : Window
    {
        public KT2()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               Debug.WriteLine(" " + textBox.Text + ": " + textBox1.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
