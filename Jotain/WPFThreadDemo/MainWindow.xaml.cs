using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFThreadDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }

        #region METHODS  
        void InitializeMyStuff()
        {
            btnFire.IsEnabled = false;
        }
        void UpdateMessage(string msg)
        {
            txtMessage.Text = msg;
        }
        void UpdateMessageAsync(string msg)
        {
            Action action = () => 
             {//methodi jolla ei ole parametreja tai paluu arvoja (delegaatti)
                 txtMessage.Text = msg;
             };
           //suorittaa annetun delegaatin asynkroonisesti siina saikeessa mihin Dispatcher liittyy
            Dispatcher.BeginInvoke(action);
        }
        void DoWork()
        {
            // kaynnistetaan pitkakestoinen tapahtuma
            Thread.Sleep(5000); //5 sek
            UpdateMessageAsync("The work is done and answear comes now!");
        }
        #endregion

        #region EVENTHANDLERS
        private void btnFire_Click(object sender, RoutedEventArgs e)
        {

            count++;
            UpdateMessage("Fire #" + count.ToString());
        }
        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            btnFire.IsEnabled = true;
            // UpdateMessage("A loooooong work started"); //    ei kerkea menna perille kun DoWork() varaa jo saikeen
            //V1: normaalisti tama toimisi mutta nyt methodin pitkan kerston takia ei kerkia paivittya
            //    DoWork();
            //V2: saikeeseen
            UpdateMessageAsync("A loooooong work started");
            new Thread(DoWork).Start();
        }
        #endregion

    }
}
