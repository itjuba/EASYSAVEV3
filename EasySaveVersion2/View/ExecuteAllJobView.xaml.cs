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

namespace EasySaveVersion2.View
{
/// <summary>
/// Logique d'interaction pour ExecuteAllJobView.xaml
/// </summary>
public partial class ExecuteAllJobView : UserControl
{
    public ExecuteAllJobView()
    {
        InitializeComponent();
    }


    public void ExecuteAllJobs(object sender, RoutedEventArgs e)
    {
        ViewModels.CreateJobViewModel.Model model = new ViewModels.CreateJobViewModel.Model();
        ViewModels.ExecuteAllJobViewModel.GetTaskDetailsaExecuteAll(@"C:\EasySave\job.json", model);
    }

    public void FrLang(object sender, RoutedEventArgs e)
    {
        Title.Text = "Executer Toutes les taches ";
    }
    public void EnLang(object sender, RoutedEventArgs e)
    {
        Title.Text = "Execute All Jobs";
    }

    public string Tb
    {
        get
        {
            string _title = Title.Text;
            return _title;
        }
    }
}
}
