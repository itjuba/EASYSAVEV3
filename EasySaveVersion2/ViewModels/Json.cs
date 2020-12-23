using System;
using System.IO;
using EasySave3._1_AN;
using Newtonsoft.Json;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;
using static EasySaveVersion2.ViewModels.CreateJobViewModel;



namespace DefaultNamespace
{
    public class Json
    {

        class Etat
        {
            public string TaskTitle;
            public DateTime time;
            public bool state;
            public int progress;
            public int leftfilesNumber;
            public long lefsizefile;
            public Model data;

        }
        static readonly object locker = new object();
        static readonly object locker2 = new object();




        public static void convertEtatJsonCreate(string source, string title, Model data, string number)

        {

            lock (locker)
            {
                if (Directory.Exists(source))
                {
                    string[] files = Directory.GetFiles(source);
                    int i = 0;
                    long size = 0;
                    foreach (var VARIABLE in files)
                    {
                        i++;
                        long filesize = new FileInfo(VARIABLE).Length;
                        size = size + filesize;
                    }



                    Etat et = new Etat();
                    et.time = DateTime.Now;
                    et.TaskTitle = title;
                    et.state = false;
                    et.progress = 0;
                    et.lefsizefile = size;
                    et.leftfilesNumber = i;
                    if (number != null)
                    {
                        et.leftfilesNumber = Convert.ToInt32(number);
                        et.progress = 100;
                        et.lefsizefile = 0;
                        et.leftfilesNumber = 0;
                    }
                    else
                    {
                        et.leftfilesNumber = i;
                    }


                    et.data = data;

                    string JSONresult = JsonConvert.SerializeObject(et);
                    string path = @"C:\EasySave\state.json";                    // Ne pas oublier App config !!
                    using (var tw = new StreamWriter(path, append: true))

                    {
                        tw.WriteLine(JSONresult.ToString());
                        tw.Close();
                    }
                }
                else
                {
                    int i = 0;
                    long size = 0;



                    Etat et = new Etat();
                    et.time = DateTime.Now;
                    et.TaskTitle = title;
                    et.state = false;
                    et.progress = 0;
                    et.lefsizefile = size;
                    et.leftfilesNumber = i;
                    if (number != null)
                    {
                        et.leftfilesNumber = Convert.ToInt32(number);
                        et.progress = 100;
                        et.lefsizefile = 0;
                        et.leftfilesNumber = 0;
                    }
                    else
                    {
                        et.leftfilesNumber = i;
                    }


                    et.data = data;

                    string JSONresult = JsonConvert.SerializeObject(et);
                    string path = @"C:\EasySave\state.json";                    // Ne pas oublier App config !!
                    using (var tw = new StreamWriter(path, append: true))

                    {
                        tw.WriteLine(JSONresult.ToString());
                        tw.Close();
                    }
                }



            }
        }



            public void converit(Model datas, string source)
            {
            lock (locker2)
            {
                string JSONresult = JsonConvert.SerializeObject(datas);
                string path = @"C:\EasySave\log.json";                    // Ne pas oublier App config !!

                using (var tw = new StreamWriter(path, append: true))

                {
                    tw.WriteLine(JSONresult.ToString());
                    tw.Close();
                }

            }
        }

              
        }
    }
            

