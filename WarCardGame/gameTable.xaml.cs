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

namespace WarCardGame
{
    /// <summary>
    /// Interaction logic for gameTable.xaml
    /// </summary>
    /// 
    public partial class gameTable : Window
    {

        private static Random rand = new Random();

        private static Random random { get { return random; } }


        public gameTable()
        {
            InitializeComponent();
        }

        private void btn_newGame_Click(object sender, RoutedEventArgs e)
        {
            //next card
        }
    }
}
