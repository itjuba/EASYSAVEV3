using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
    /// Logique d'interaction pour ExecuteSpecificJobView.xaml
    /// </summary>
    public partial class ExecuteSpecificJobView : UserControl
    {
      

        public ExecuteSpecificJobView()
        {
            InitializeComponent();

            //List<string> ext = new List<string>();
            //ext.Add(".txt");

            HHname.Header = "Nom";
            HHsource.Header = "source";
            HHtarget.Header = "destination";
            HHtype.Header = "type";

            HHfoSof.Header = "foSof";


            ObservableCollection<TaskJsonAttribute> jobs = new ObservableCollection<TaskJsonAttribute>();
            jobs = getTasks(@"C:\EasySave\job.json",jobs);


            ListJob.ItemsSource = jobs;

        }
        public class TaskJsonAttribute
        {

            public string name;
            public string source;
            public string target;
            public string type;
            public List<string> extension;

            public string foSof; 

           

            public string Name
            {
                get { return name; }
            }
            public string Source
            {
                get { return source; }
            }
            public string Target
            {
                get { return target; }
            }
            public string Type
            {
                get { return type; }
            }
            public List<string> Extension
            {
                get { return extension; }
            }

            public string FoSof
            {
                get { return foSof;  }
            }

        }


        public ObservableCollection<TaskJsonAttribute> getTasks (string path, ObservableCollection<TaskJsonAttribute> T)
        {
            try
            {
                var d = System.IO.File.ReadLines(path);
                int i = 0;
                foreach (var x in d)
                {
                    var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(x);


                    // var j = JsonConvert.SerializeObject(objson);
                    if (objson != null && objson.type != null)
                    {
                        Console.WriteLine(objson.name + objson.source + objson.target + objson.type + objson.foSof);
                        T.Add(new TaskJsonAttribute()
                        {
                            name = objson.name,
                            source = objson.source,
                            target =objson.target,
                            type = objson.type,
                            foSof = objson.foSof ,
                        }); 
                    }

                    i++;
                }

                return T;
            }

            catch (FileNotFoundException d)
            {
                Console.WriteLine(d);
                throw;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }






        List<string> _listJob = new List<string>();


        public void myCheckBox_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton rb = sender as RadioButton;

            _listJob.Add(rb.Content.ToString());

        }

     

        public void GetJobsList(object sender, RoutedEventArgs e)
        {
            // CheckBox cb = sender as CheckBox;
        }

        


        public void ExecuteSpecificJob(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("okkkkkk");

            if (ListJob.SelectedItems.Count > 0)
            {
                Console.WriteLine("foodqsdqsdqsdo");

                foreach (var drv in ListJob.SelectedItems)
                {

                    var nn = JsonConvert.SerializeObject(drv);
                    var TaskrObj = JObject.Parse(nn);
                    string name = Convert.ToString(TaskrObj["name"]);
                    string foSof = Convert.ToString(TaskrObj["foSof"]);
                    Int64 maxLen = Convert.ToInt64(TaskrObj["maxLen"]);

                    Console.WriteLine("fooo" + name);

                    Console.WriteLine("fooo" + foSof);

                    ViewModels.ExecuteAllJobViewModel.checkporcess(foSof);

                    ViewModels.CreateJobViewModel.Model.ExecuteSpecific(@"C:\EasySave\job.json", name, maxLen);

                }
            }
        }


        public void FrLang (object sender, RoutedEventArgs e)
        {
            Title.Text = "Executer un travaille specifique";
            HHname.Header = "Nom";
            HHsource.Header = "source";
            HHtarget.Header = "destination";
            HHtype.Header = "type";

            HHfoSof.Header = "logiciel metier";

        }

        public void EnLang(object sender, RoutedEventArgs e)
        {
            Title.Text = "Execute a Specific Job";
            HHname.Header = "Name";
            HHsource.Header = "Source";
            HHtarget.Header = "Target";
            HHtype.Header = "Type";

            HHfoSof.Header = "FoSof";
        }


        public string TbTitle
        {
            get
            {
                string n = Title.Text;
                return n;
            }
        }

        public string HName
        {
            get
            {
                string n = HHname.Header.ToString() ;
                return n;
            }
        }

        public string HSource
        {
            get
            {
                string n = HHsource.Header.ToString();
                return n;
            }
        }


        public string HTarget
        {
            get
            {
                string n = HHtarget.Header.ToString();
                return n;
            }
        }


        public string HType
        {
            get
            {
                string n = HHtype.Header.ToString();
                return n;
            }
        }

        public string HfoSof
        {
            get
            {
                string n = HHfoSof.Header.ToString();
                return n; 
            }
        }




    }
}
