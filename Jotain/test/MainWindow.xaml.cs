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
namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ammukset = 10;
        private int maxAmmukset = 10;

        public MainWindow()
        {
            InitializeComponent();
            initmystuff();
        }
        public void initmystuff()
        {
            /*
             *      var watch = System.Diagnostics.Stopwatch.StartNew();
              // the code that you want to measure comes here
              watch.Stop();
              var elapsedMs = watch.ElapsedMilliseconds;

            muista bindata eventeiks ammusten kaytto, ettei kokoajan tarvii sanoa  lataus.Value = ammukset
             * 
             * */
        }
        private void stackp_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (ammukset > 0)
            {
                ammukset--;
                lataus.Value = ammukset;
                label.Content = "Ammukset " + ammukset +"/"+ maxAmmukset;
              Point position = Mouse.GetPosition(this.stackp);
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Black);
                l.StrokeThickness = 2.0;
                l.X1 = 10;
                l.Y1 = 10;
                l.X2 = position.X;
                l.Y2 = position.Y;
                l.HorizontalAlignment = HorizontalAlignment.Left;
                l.VerticalAlignment = VerticalAlignment.Center;
                stackp.Children.Clear();
                stackp.Children.Add(l);
               
            }
        }

        private void stackp_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = Mouse.GetPosition(this.stackp);
            playerpos.Text = "X: " + position.X + "\n" + "Y: " + position.Y;
        }

        private void lataaAmmukset_Click(object sender, RoutedEventArgs e)
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset; // pitais hoitaa eventilla
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;  // pitais hoitaa eventilla
        }
    }
}

