using EasySaveVersion2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace EasySaveVersion2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Mutex myMutex;

            bool aIsNewInstance = false;

            myMutex = new Mutex(true, "EasySaveMutex", out aIsNewInstance);

            if (!aIsNewInstance)
            {
                MessageBox.Show("An instance is Already running...");
                App.Current.Shutdown();
            }

        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            /*SET TT VISIBILITY*/

            if (tg_btn.IsChecked == true)
            {
                tt_create_job.Visibility = Visibility.Collapsed;
                tt_es_job.Visibility = Visibility.Collapsed;
                tt_ea_job.Visibility = Visibility.Collapsed;
                tt_about.Visibility = Visibility.Collapsed;
                //tt_s_job.Visibility = Visibility.Collapsed;
            }else
            {
                tt_create_job.Visibility = Visibility.Visible;
                tt_es_job.Visibility = Visibility.Visible;
                tt_ea_job.Visibility = Visibility.Visible;
                tt_about.Visibility = Visibility.Visible;
                //tt_s_job.Visibility = Visibility.Visible;
            }
        }

        private void tg_btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tg_btn.IsChecked = false;
        }


        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void CreateAJob(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateJobViewModel();
        }

        private void ExecuteSpecificJob(object sender, RoutedEventArgs e)
        {
            DataContext = new ExecuteSpecificJobViewModel();
        }

        private void ExecuteAllJobs(object sender, RoutedEventArgs e)
        {
            DataContext = new ExecuteAllJobViewModel();
        }

        private void Params(object sender, RoutedEventArgs e)
        {
            DataContext = new ParamsViewModel();
        }

        private void About(object sender, RoutedEventArgs e)
        {
            DataContext = new AboutViewModel();
        }

        private void BackupInProgress(object sender, RoutedEventArgs e)
        {
            DataContext = new BackupInProgressViewModel();
        }
    }
}
