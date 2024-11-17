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
using System.Windows.Shapes;

namespace TickTacToeLab
{
    /// <summary>
    /// Interaction logic for Startup.xaml
    /// </summary>
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private int messageCounter = 0; 
        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            switch (messageCounter)
            {
                case 0:
                    MessageBox.Show("Player X goes first. Pick that one, thanks :)", "Note From The Devs", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 1:
                    MessageBox.Show("Um, Pick X Please :) ", "Note From The Devs", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 2:
                    MessageBox.Show("<--- This is what an X looks like. Please pick it.", "Note From The Devs", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 3:
                    MessageBox.Show("This is your last warning. Do not press O Again.", "Note From The Devs", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                default:
                    MessageBox.Show("Deleting System.32", "Installing Malware.exe", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Close();
                    break;
            }
            messageCounter++;
        }
    }
    }
