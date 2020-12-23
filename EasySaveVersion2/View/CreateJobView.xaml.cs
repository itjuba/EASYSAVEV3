using System.Windows.Controls;
using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;

namespace EasySaveVersion2.View
{
/// <summary>
/// Logique d'interaction pour CreateJobView.xaml
/// </summary>
public partial class CreateJobView : UserControl
{
    ViewModels.CreateJobViewModel.Model job = new ViewModels.CreateJobViewModel.Model();

    public CreateJobView()
    {
        InitializeComponent();
        this.DataContext = job;

        Title.Text = "Create a Job";

        Lb_Name.Content = "Name : ";

        Lb_Type.Content = "Backup type ";

        RaBtnComp.Content = "complete";

        RaBtnDiff.Content = "Incremental";

        LbExt.Content = "select extentions";

        LbSource.Content = "source";

        LbTarget.Content = "Target";

        LbPrio.Content = "Priority";

        FS_Name.Content = "Foreign Software";

        Max_Length.Content = "Max Length (KB)"; 
    }

    List<string> _listCheck = new List<string>();


    List<string> _listCheckPrio = new List<string>();


    public void myCheckBox_Checked(object sender, RoutedEventArgs e)

    {

        CheckBox cb = sender as CheckBox;

        _listCheck.Add("." + cb.Content.ToString());

    } 

    public void myCheckBox_Unchecked(object sender, RoutedEventArgs e)

    {

        CheckBox cb = sender as CheckBox;

        _listCheck.Remove("." + cb.Content.ToString());


    }


    public void myCheckBoxPrio_Checked(object sender, RoutedEventArgs e)

    {

        CheckBox cb = sender as CheckBox;

        _listCheckPrio.Add("." + cb.Content.ToString());

    }

    public void myCheckBoxPrio_Unchecked(object sender, RoutedEventArgs e)

    {

        CheckBox cb = sender as CheckBox;

        _listCheckPrio.Remove("." + cb.Content.ToString());


    }




    public void SubmitJob(object sender, RoutedEventArgs e)
    {
        string _jobName = JobName.Text;

        string _sourcePath = JobSourcePath.Text;
        string _targetPath = JobTargetPath.Text;

        string _isCompleteChecked = RaBtnComp.IsChecked == true ? "complete" : "differential";
        string _isDiffChecked = RaBtnDiff.IsChecked == true ? "incremental" : "complete";

        string _foSof = FsName.Text;
        long _maxLen = Convert.ToInt64(MaxLength.Text);


        Console.WriteLine($"\n{ _jobName}\n");
        Console.WriteLine($"\n{ _sourcePath}\n");
        Console.WriteLine($"\n{ _targetPath}\n");
        Console.WriteLine($"\n{ _isCompleteChecked}\n");
        Console.WriteLine($"\n{ _isDiffChecked}\n");
        Console.WriteLine($"\n{ _foSof}\n");
        Console.WriteLine($"\n{ _maxLen}\n");

        foreach (var eml in _listCheck)
        {
            Console.WriteLine( "List enc ext : " + eml);
        }

        foreach (var eml in _listCheckPrio)
        {
            Console.WriteLine("List  Priority ext  : " + eml);
        }


        try
        {
            if (job.CheckTaskName(@"C:\EasySave\job.json", _jobName) == false && job.CheckDirecotryExistFiles(_sourcePath) && job.CheckDirecotry(_targetPath))
            {

                job.jobToJson(_jobName, _sourcePath, _targetPath, _isCompleteChecked, _listCheck , _listCheckPrio , _foSof , _maxLen);

            }else
            {
                MessageBox.Show("plz verify all the field | svp verifier tout les champs ");
            }


        }
        catch (IOException et)
        {
            Console.WriteLine(et);
        }





    }


    public void FrLang(object sender, RoutedEventArgs e)
    {
        Title.Text = "Cree une tache ";

        Lb_Name.Content = "Nom : ";

        Lb_Type.Content = "type de sauvegarde : ";

        RaBtnComp.Content = "complete";

        RaBtnDiff.Content = "differantiel";

        LbExt.Content = "choisir les exentions";

        LbSource.Content = "source";

        LbTarget.Content = "destination";

        LbPrio.Content = "priorité";

        FS_Name.Content = "logiciel metier";

        Max_Length.Content = "taille max (KB) ";

    }
    public void EnLang(object sender, RoutedEventArgs e)
    {
        Title.Text = "Create a Job";

        Lb_Name.Content = "Name : ";

        Lb_Type.Content = "Backup type ";

        RaBtnComp.Content = "complete";

        RaBtnDiff.Content = "Incremental";

        LbExt.Content = "select extentions";

        LbSource.Content = "source";

        LbTarget.Content = "Target";


        LbPrio.Content = "Priority";

        FS_Name.Content = "Foreign Software";

        Max_Length.Content = "Max Length (KB) ";

    }

    public string Tb
    {
        get
        {
            string _title = Title.Text;
            return _title;
        }
    }


    public string LbName
    {
        get
        {
            string n = Lb_Name.Content.ToString(); 
            return n ;
        }
    }

    public string LbType
    {
        get
        {
            string n = Lb_Type.Content.ToString();
            return n;
        }
    }

    public string CompleteBtn
    {
        get
        {
            string n = RaBtnComp.Content.ToString();
            return n;
        }
    }

    public string Incremental
    {
        get
        {
            string n = RaBtnDiff.Content.ToString();
            return n;
        }
    }

    public string LbExtention
    {
        get
        {
            string n = LbExt.Content.ToString();
            return n;
        }
    }

    public string LbSourcePath
    {
        get
        {
            string n = LbSource.Content.ToString();
            return n;
        }
    }

    public string LbTargetPath
    {
        get
        {
            string n = LbTarget.Content.ToString();
            return n;
        }
    }


    public string LBmaxLen

    {
        get
        {
            string n = Max_Length.Content.ToString();
            return n; 
        }
    }

    public string LbExtentionPrio
    {
        get
        {
            string n = LbPrio.Content.ToString();
            return n; 
        }
    }




}
}
