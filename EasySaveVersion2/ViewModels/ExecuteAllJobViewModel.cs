    using ConsoleApplication1;
    using DefaultNamespace;
    using EasySave3._1_AN;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
using static ConsoleApplication1.Copyf;
using static EasySaveVersion2.ViewModels.CreateJobViewModel;
using static EasySaveVersion2.ViewModels.CreateJobViewModel.Model;

    namespace EasySaveVersion2.ViewModels
    {
        public class ExecuteAllJobViewModel
        {





            public static void checkporcess(string exe)
            {
                Console.WriteLine("EXEEEEEEEEEEE"+exe);

                Process[] localAll = Process.GetProcesses();
                foreach (var VARIABLE in localAll)
                {
                    Console.WriteLine("VARRRRRRRRRRRRR" + VARIABLE.ProcessName);

                    if (VARIABLE.ProcessName == exe)
                    {
                        //Console.WriteLine("please close firefox !!!");
                        var d = Process.GetProcessesByName(exe);

                        foreach (var VARIABLE2 in d)
                        {
                            if (!VARIABLE2.HasExited)
                            {
                                //Console.WriteLine("please close firefox matghamerch bina aghla9ha !");
                                MessageBox.Show($"please close {exe} ! | svp fermer {exe} ");
                                VARIABLE2.WaitForExit();
                            }
                        }
                    }
                }
            }

            public static  List<Model.File> datas = new List<Model.File>();
            static readonly object locker = new object();
       public static ViewModels.CreateJobViewModel.Model yanisD = new ViewModels.CreateJobViewModel.Model();



        static void show(ConcurrentStack<Copyf.Bigfiles> data)
            {
                Console.WriteLine("doOOOOOOOOOOOOOOOOOOOOOne x ");
                lock (locker)
                {
                string xD = "";
                string aliC = "";
                string nadjibD = "";
                Stopwatch KOKO = new Stopwatch();
                KOKO.Start();
                    foreach (var emlt in data)
                    {
                      
                        Console.WriteLine("file here source code : " + emlt.source);
                        Console.WriteLine("file here source code : " + emlt.target);

                        Console.WriteLine("file here source code : " + emlt.type);

                        Console.WriteLine("file here source code : " + emlt.jobname);
                          xD = emlt.jobname;
                          aliC = emlt.type;
                          nadjibD = emlt.source;
                          Model.File yaniscctl = new Model.File(emlt.source,emlt.target,22,emlt.filename,emlt.filezie,emlt.accesstime,0);
                          datas.Add(yaniscctl);
                       

                    }
                KOKO.Stop();
                TimeSpan tt = KOKO.Elapsed;
                              // Ne pas oublier App config !!

                yanisD.TaskTitle = xD;
                yanisD.TaskType = aliC;
                yanisD.TaskFileNumber = datas.Count;
                yanisD.TaskCryptedExtension = null;
                yanisD.TaskTime = tt.TotalMilliseconds;
                Json jts = new Json();
                yanisD.files = datas;
                jts.converit(yanisD, "");
                Json.convertEtatJsonCreate(nadjibD, xD, yanisD, "1");

            }



        }

            public delegate void ExampleCallback(ConcurrentStack<Copyf.Bigfiles> data);
            public static void GetTaskDetailsaExecuteAll(string exsourceall, ViewModels.CreateJobViewModel.Model k)
            {
                ExampleCallback callbak = new ExampleCallback(show);
                // List<string> urls = null;
                dynamic lineall;
                try
                {
                    lineall = System.IO.File.ReadAllLines(exsourceall);
                    foreach (var tt in lineall)
                    {
                   
                        var objsonAll = JsonConvert.DeserializeObject<TaskJsonAttribute>(tt);
                        var nn = JsonConvert.SerializeObject(objsonAll);
                        var TaskrObj = JObject.Parse(nn);
                        // Console.WriteLine(TaskrObj["name"]);
                        // Console.WriteLine("up");


                        string xsa = Convert.ToString(TaskrObj["source"]);

                        string xta = Convert.ToString(TaskrObj["target"]);
                        string xnamea = Convert.ToString(TaskrObj["name"]);
                        string xtypet = Convert.ToString(TaskrObj["type"]);
                        // string extns = Convert.ToString(TaskrObj["extension"]);

                        string xfoSoft = Convert.ToString(TaskrObj["foSof"]);
                        Int64 maxLen = Convert.ToInt64(TaskrObj["maxLen"]);

                        List<string> extns = objsonAll.extension;

                        checkporcess(xfoSoft);

                        if (xtypet == "complete")
                        {

                            List<ViewModels.CreateJobViewModel.Model.File> EveryFileData5 = new List<ViewModels.CreateJobViewModel.Model.File>();
                            List<ViewModels.CreateJobViewModel.Model.File > EveryFileDat6 = new List<ViewModels.CreateJobViewModel.Model.File>();

                            ViewModels.CreateJobViewModel.Model t2 = new ViewModels.CreateJobViewModel.Model();
                            Json jf = new Json();
                            Stopwatch timer1 = new Stopwatch();
                            timer1.Start();

                            Console.WriteLine("COMPLETE");                   

                            Thread t = new Thread( () =>
                            {
                                var tid = Thread.CurrentThread.ManagedThreadId;
                                Console.WriteLine("THREAD READ YES !!!!!" + tid);
                                EveryFileData5 = Copyf.copy(xsa, xta, xnamea, xtypet, t2, jf, EveryFileDat6, extns , maxLen , callbak);
                            }); 
                            t.Start();
                            t.Join();



                            /*                        EveryFileData5 = Copyf.copy(xsa, xta, xnamea, xtypet, t2, jf, EveryFileDat6, extns);
                            */
                            timer1.Stop();
                            TimeSpan timeTaken = timer1.Elapsed;
                            string xtime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                            k.TaskTime = timeTaken.TotalMilliseconds;
                            k.TaskTitle = xnamea;
                            k.TaskFileNumber = EveryFileData5.Count;
                            k.files = EveryFileData5;
                            k.TaskType = xtypet;
                            k.TaskCryptedExtension = extns;
                            Json jts = new Json();
                            jts.converit(k, xsa);
                            Json.convertEtatJsonCreate(xsa, xnamea, k, EveryFileData5.Count.ToString());
     
                        }

                    else
                    {
                        List<Bigfiles> zz = new List<Bigfiles>();

                        Thread t = new Thread(() =>
                        {

                            zz = GetFileLogDetails(xnamea, maxLen);

                        });
                        t.Start();
                        t.Join();

                        int xzr = 1;
                        List<Model.File> datassss = new List<Model.File>();

                        ViewModels.CreateJobViewModel.Model kkk2 = new ViewModels.CreateJobViewModel.Model();
                        ViewModels.CreateJobViewModel.Model.File fichiers;
                        TimeSpan yanistime;
                        yanistime = TimeSpan.Zero;
                        string timeo = "";
                        string sourcessauce = "";
                        foreach (var bigfififies in zz)
                        {
                            Json jts = new Json();
                            Stopwatch stopit = new Stopwatch();
                            stopit.Start();
                            sourcessauce = bigfififies.source;
                            System.IO.File.Copy(bigfififies.source, bigfififies.target);
                            stopit.Stop();
                            yanistime = stopit.Elapsed;
                            fichiers = new ViewModels.CreateJobViewModel.Model.File(bigfififies.source, bigfififies.target, yanistime.TotalMilliseconds, bigfififies.filename, bigfififies.filezie, bigfififies.accesstime, 0);
                            datassss.Add(fichiers);


                        }

                        Json jkts = new Json();
                        kkk2.TaskTitle = xnamea;
                        kkk2.TaskFileNumber = datassss.Count;
                        kkk2.TaskTime = yanistime.TotalMilliseconds;
                        kkk2.TaskType = xtypet;
                        kkk2.files = datassss;


                        if (datas.Count > 0)
                        {
                            jkts.converit(kkk2, "");
                            Json.convertEtatJsonCreate(sourcessauce, xnamea, kkk2, "1");
                        }

                    }
                }

                    if(yanisD.files != null)
                {
                    foreach (var elmt in yanisD.files)
                    {
                        System.IO.File.Copy(elmt.sourcePath, elmt.targetPath, true);
                        Console.WriteLine("DOWWWWWWWWWWWWWNNNN :  " + elmt.targetPath);
                    }

                }
                 

                // Menu.DoneMsg();
            }
                catch (FileNotFoundException d)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    // Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(d);
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    throw;
                }
                catch (IOException e)
                {
                    //Console.BackgroundColor = ConsoleColor.White;
                    // Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e);
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                }

            }

            public static List<Copyf.Bigfiles> GetFileLogDetails(string Tname,Int64 lengthtttt)
            {
                Bigfiles dd = new Bigfiles();
                List<Copyf.Bigfiles> bigfififi=  new List<Copyf.Bigfiles>();

                List<ViewModels.CreateJobViewModel.Model.File> fileslists = new List<ViewModels.CreateJobViewModel.Model.File>();
                List<string> Taskext = new List<string>();
                ViewModels.CreateJobViewModel.Model Task_data = new ViewModels.CreateJobViewModel.Model();
                var EveryFiletimer = new Stopwatch();
                List<string> extenssss = new List<string>();

                string sourcepathh = CreateJobViewModel.Model.GetTaskSource(Tname);
                string targettss =  CreateJobViewModel.Model.GetTaskTarget(Tname);
                try
                {
                    string log_file = @"C:\EasySave\log.json";                          //ConfigurationManager.AppSettings.Get("log");

                    if (new FileInfo(log_file).Length == 0)
                    {
                        //Console.BackgroundColor = ConsoleColor.White;
                        // Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n you can't performe incremental save ! thank you \n");
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        var d = System.IO.File.ReadLines(log_file);

                        List<ViewModels.CreateJobViewModel.Model> taskmatchlist = new List<ViewModels.CreateJobViewModel.Model>();
                        // List<Model.Model.File> taskmatchlistFile = new List<Model.Model.File>();
                        foreach (var x in d)
                        {

                            var objson = JsonConvert.DeserializeObject<ViewModels.CreateJobViewModel.Model>(x);
                            extenssss = objson.TaskCryptedExtension;
                            foreach (var VARIABLE3 in objson.files)
                            {

                                //Task.File => source 

                                if (VARIABLE3.sourcePath == sourcepathh && objson.TaskType == "complete")
                                {
                                    taskmatchlist.Add(objson);
                                    //Console.BackgroundColor = ConsoleColor.White;
                                    //Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine(objson.TaskFileNumber);
                                    //Console.BackgroundColor = ConsoleColor.White;
                                    //Console.ForegroundColor = ConsoleColor.Black;
                                    //Console.WriteLine("FO9");
                                }
                            }
                        }
                        //you have  to test if taskmatchlist is not empty !
                        if (taskmatchlist.Count() != 0)
                        {
                            foreach (var hh in taskmatchlist)
                            {
                                //Console.BackgroundColor = ConsoleColor.White;
                                //Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n taskmatchlist not empty \n");
                                Console.WriteLine($"\n {hh}"); //just for test
                                //Console.BackgroundColor = ConsoleColor.White;
                                //Console.ForegroundColor = ConsoleColor.Black;
                            }
                        }


                        int i = taskmatchlist.Count;
                        List<string> filesname = new List<string>();
                        foreach (var zt in taskmatchlist)
                        {
                            if (--i > 0)
                            {
                                //Console.BackgroundColor = ConsoleColor.White;
                                //Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n not last \n");
                                //Console.BackgroundColor = ConsoleColor.White;
                                //Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else
                            {


                                if (zt != null && zt.TaskTitle != null)
                                {
                                    Taskext = zt.TaskCryptedExtension;
                                    string source = "";
                                    string target = "";

                                    foreach (var za in zt.files)

                                    {
                                        //Console.WriteLine("down");
                                        //Console.BackgroundColor = ConsoleColor.White;
                                        //Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"\n FILE NAME :  {za.FileName} \n");
                                        source = za.sourcePath;
                                        target = za.targetPath;
                                        filesname.Add(za.FileName);
                                        Console.WriteLine($"\n SOURCE PATH :  {za.sourcePath} \n");
                                        long filinfo = new FileInfo(za.sourcePath + '/' + za.FileName).Length;
                                        Console.WriteLine($"\n SOURCE PATH : {za.sourcePath} FILE NAME : {za.FileName}\n");
                                        Console.WriteLine($"\n FILE INFO : {filinfo} \n");

                                    if (filinfo > lengthtttt)
                                    {
                                      
                                        dd.source = za.sourcePath;
                                        dd.target = za.targetPath;
                                        dd.jobname = zt.TaskTitle;
                                        dd.type = zt.TaskType;
                                        bigfififi.Add(dd);
                                        continue;


                                    }
                                        if (filinfo != za.FileSize)
                                        {
                                            ViewModels.CreateJobViewModel.Model.File f;

                                            EveryFiletimer.Start();
                                            //Console.WriteLine("different");
                                            f = Copy1f.copy1f(za.sourcePath, za.FileName, za.targetPath, Tname, extenssss);
                                            fileslists.Add(f);
                                        }



                                    }

                                }
                            }
                        }
                        int xz = 0;
                        int y = 0;
                        string[] files = Directory.GetFiles(sourcepathh);
                        List<string> realfilesss = new List<string>();
                        foreach (var VARIABLE5 in files)
                        {
                            realfilesss.Add(Path.GetFileName(VARIABLE5));

                        }
                        foreach (var ali in realfilesss)
                        {

                            int k = 0;
                            foreach (var nadjib in filesname)
                            {
                                Console.WriteLine(nadjib);
                                Console.WriteLine("up");
                                k++;
                                // Console.WriteLine(ali);
                                // Console.WriteLine(k);
                                // Console.WriteLine("ali is here down 0");

                                if (ali == nadjib)
                                {
                                    xz++;
                                }
                                else
                                {
                                    y++;
                                    Console.WriteLine(ali);
                                }


                            }
                            if (xz == 0 && y == filesname.Count)
                            {
                                Console.WriteLine("found it");
                                Console.WriteLine(ali);
                                CreateJobViewModel.Model.File kl;
                            long fileinooooo = new FileInfo(sourcepathh).Length;
                            if (fileinooooo >= lengthtttt)
                            {
                                Bigfiles outerbigfiles = new Bigfiles();
                                outerbigfiles.source = sourcepathh;
                                outerbigfiles.target = targettss;
                                outerbigfiles.jobname = Tname;
                                outerbigfiles.type = "incremental";
                                bigfififi.Add(outerbigfiles);
                            }
                                kl = Copy1f.copy1f(sourcepathh, ali, targettss, Tname, extenssss);
                                fileslists.Add(kl);

                            }
                            Console.WriteLine(y);
                            Console.WriteLine("xz --");
                            y = 0;
                            xz = 0;

                        }
                    }
                    EveryFiletimer.Stop();
                    TimeSpan timeTaken = EveryFiletimer.Elapsed;
                    Task_data.TaskTime = timeTaken.TotalMilliseconds;
                    Task_data.TaskTitle = Tname;
                    Task_data.TaskFileNumber = 1;
                    Task_data.TaskType = "incremental";
                    Task_data.files = fileslists;
                    Task_data.TaskCryptedExtension = Taskext;

                    Json jss = new Json();
                    jss.converit(Task_data, "");
                    Json.convertEtatJsonCreate(sourcepathh, Tname, Task_data, fileslists.Count.ToString());

                }
                catch (FileNotFoundException d)
                {
                    Console.WriteLine(d);

                }
                catch (IOException e)
                {
                    Console.WriteLine(e);

                }
                catch (UnauthorizedAccessException adzad)
                {
                    Console.WriteLine(adzad);

                }
            return bigfififi;


            }

        }
    }
