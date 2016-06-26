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

namespace WarCardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Construction
        public MainWindow()
        {
            InitializeComponent();

            RegisterEvents();
        }

        #endregion

        #region Methods

        private void RegisterEvents()
        {
            btn_newGame.MouseEnter += Btn_newGame_MouseEnter;
            btn_rules.MouseEnter += Btn_rules_MouseEnter;
            btn_exit.MouseEnter += Btn_exit_MouseEnter;

            btn_newGame.MouseLeave += MainMenu_MouseLeave;
            btn_rules.MouseLeave += MainMenu_MouseLeave;
            btn_exit.MouseLeave += MainMenu_MouseLeave;
        }

        

        #endregion

        #region event handling
        private void btn_newGame_Click(object sender, RoutedEventArgs e)
        {
            var GameWindow = new GameWindow();
            GameWindow.Show();
            this.Close();
        }

        private void btn_rules_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void MainMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            txt_info.Text = string.Empty;
        }

        private void Btn_exit_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_info.Text = "exit your game";
        }

        private void Btn_rules_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_info.Text = "learn about the rules";
        }

        private void Btn_newGame_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_info.Text = "play game";
        }


        #endregion
    }
}
