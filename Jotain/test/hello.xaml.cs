﻿using System;
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
using System.Windows.Shapes;

namespace test
{
    /// <summary>
    /// Interaction logic for hello.xaml
    /// </summary>
    public partial class hello : Window
    {
        public hello()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtB.Text;
          var gameWindow = new MainWindow(name);
            gameWindow.Show();
            Close();
        }
    }
}
