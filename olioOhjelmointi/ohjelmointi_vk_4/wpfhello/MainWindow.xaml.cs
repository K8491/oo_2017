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
            textBlock2.Text = " " + (++t) + " " + (i);
        }
        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            // kutsutaan nakyviin Tiedoksi ikkuna
            //About tiedoksiUusi = new About();
            // tiedoksiUusi.ShowDialog();
            textBlock2.Text = " " + (t) + " " + (++i);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double number = 0;
                string value = textBox2.Text;
                double.TryParse(value, out number);
                number = number * 6;
                value = number.ToString("0.00");
                textBox2.Text = value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                double number = 0;
                string value = textBox2.Text;
                double.TryParse(value, out number);
                number = number / 6;
                value = number.ToString("0.00");
                textBox2.Text = value;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //ikkuna textBox3 textBlock3
                //lasi textBox3_1 textBlock3_1
                //karmi textBox3_2 textBlock3_2

                int number = 0;
                int number1 = 0;
                int number2 = 0;
                // otetaan talteen
                string value = textBox3.Text;
                int.TryParse(value, out number);

                value = textBox3_1.Text;
                int.TryParse(value, out number1);

                value = textBox3_2.Text;
                int.TryParse(value, out number2);

                //lasketaan arvoilla
                // a*b
                textBlock3.Text = ((number*number1)/10).ToString("0");
                // pituus ja levys suunnassa poistetaan karmin paksuuden verran
                //(ylhaalta ja alhaalta, oikealta ja vasemalta on a-x * b-x... siis pitais olla
                textBlock3_1.Text = (((number-(number2*2)) * (number1-(number2)*2)) / 10).ToString("0");
                //pituus kertaa pituus plus leveys kertaa leveys
                textBlock3_2.Text = ((number*2 + number1*2 )/10).ToString("0");

                //lisataan tekstia merkkijonoon
                textBlock3.Text = textBlock3.Text + " cm^2";
                textBlock3_1.Text = textBlock3_1.Text + " cm^2";
                textBlock3_2.Text = textBlock3_2.Text + " cm";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
