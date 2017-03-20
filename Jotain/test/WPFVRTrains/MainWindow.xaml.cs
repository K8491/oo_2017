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
using JAMK.IT;
using System.Threading;

namespace WPFVRTrains
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Train> trains = new List<Train>();
        string selecteStation = "";

        public MainWindow()
        {
            InitializeComponent();
            InitializeMyStuff();
        }
        #region METHODS
        void InitializeMyStuff()
        {
            // omat asetukset kootaan tanne
            // taytetaan combobox nailla asutuksila
            GetStations();
        }
        private void GetStations()
        {
        
                List<Station> stations = new List<Station>();
                stations.Add(new JAMK.IT.Station("JY", "Jyvaskyla"));
                stations.Add(new JAMK.IT.Station("HKI", "Helsinki"));
                stations.Add(new JAMK.IT.Station("TPE", "Tampere"));
                // voisi myosa hakea apin jsonista
                // kiinnitetaan stations kokoelma comboxiin

                cbStations.DisplayMemberPath = "Name"; // bindingin vastakohta koodissa (kiinnitetaan bindaus)
                cbStations.SelectedValuePath = "Code";
                cbStations.DataContext = stations;

        }
        private void GetTrainsAt()
        {
            try
            {
                //haetaan asemalta lahtevat junat
                string st = cbStations.SelectedValue.ToString();
                trains = JAMK.IT.TrainsVM.GetTrainsAt(st);
                dgTrains.DataContext = trains;
                tbMessage.Text = string.Format("Loytyi {0} junaa", trains.Count);
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }
        private void GetTrainsAtAsync()
        {
            //omassa saikeessa ajattava methodi. Ei VOI KASITELLA GUI:ta
            //Mutta muuttujia voi
            trains = JAMK.IT.TrainsVM.GetTrainsAt(selecteStation);
            UpdateUI();
        }
        private void UpdateUI()
        {
            Action action = () =>
            {
                dgTrains.DataContext = trains;
                tbMessage.Text = string.Format("Loysin junaa {0}", trains.Count);
            };
            Dispatcher.BeginInvoke(action);
        }
        #endregion

        private void btnGetTrains_Click(object sender, RoutedEventArgs e)
        {
            if (cbStations.SelectedValue != null)
            {
                // V1 alkuperainen
              //  tbMessage.Text = "Haetaan junat...";
              //  GetTrainsAt();
                // V2 Assynkroninen omassa saikeessa
                selecteStation = cbStations.SelectedValue.ToString();
                new Thread(GetTrainsAtAsync).Start();
                tbMessage.Text = "Haetaan Junia, odota hetki...";

            }
        }
    }
}
