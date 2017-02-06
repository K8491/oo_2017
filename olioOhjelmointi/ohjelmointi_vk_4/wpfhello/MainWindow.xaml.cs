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

namespace wpfhello
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
        //laskurit
       private int i = 0;
       private int t = 0;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
         //  textBlock.Text = "Hello " + textBox.Text;
          // MessageBox.Show("Terve "+ textBox.Text, "Antti's Duu duu");
            textBlock1.Text = " " + (++t) + " " + (i);
        }
        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            // kutsutaan nakyviin Tiedoksi ikkuna
            About tiedoksiUusi = new About();
            // tiedoksiUusi.ShowDialog();
            textBlock1.Text = " " + (t) + " " + (++i);
        }
    }
}
