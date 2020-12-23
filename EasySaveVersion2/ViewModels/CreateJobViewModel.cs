    using System;
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using DefaultNamespace;
    using System.Diagnostics;
    using ConsoleApplication1;

    namespace EasySaveVersion2.ViewModels
    {
        public class CreateJobViewModel
        {
            public class Model
            {
                public static string path = @"C:\EasySave\job.json";   // ConfigurationManager.AppSettings.Get("job");

                public class TaskJsonAttribute
                {
                    public string name;
                    public string source;
                    public string target;
                    public string type;
                    public List<string> extension;
                    public List<string> extensionPrio;
                    public string foSof;
                    public Int64 maxLen; 

                    public string Name
                    {
                        get => name;
                    }
                }


                public class File
                {
                    public File(string sourcePath, string targetPath, double FileCopyTime, string FileName, long FileSize,
                        DateTime LastAccessTime, double CryptTime1)
                    {
                        this.sourcePath = sourcePath;
                        this.targetPath = targetPath;
                        this.FileCopyTime = FileCopyTime;
                        this.FileName = FileName;
                        this.LastAccessTime = LastAccessTime;
                        this.FileSize = FileSize;
                        this.CryptTime = CryptTime1;
                    }

                    public string FileName;
                    public string sourcePath;
                    public string targetPath;
                    public double FileCopyTime;
                    public DateTime LastAccessTime;
                    public long FileSize;
                    public double CryptTime;

                }
                public string TaskTitle;
                public double TaskTime;
                public string TaskType;
                public int TaskFileNumber;
                public List<string> TaskCryptedExtension;
                public List<File> files;


                public Dictionary<int, Dictionary<string, string>> GetAllTasksNameType(string jsonfPath)
                {
                    Dictionary<int, Dictionary<string, string>> name_typeDict = new Dictionary<int, Dictionary<string, string>>();
                    Dictionary<string, string> type_name = new Dictionary<string, string>();
                    try
                    {
                        var d = System.IO.File.ReadLines(jsonfPath);
                        int i = 0;
                        foreach (var x in d)
                        {
                            var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(x);


                            // var j = JsonConvert.SerializeObject(objson);
                            if (objson != null && objson.type != null)
                            {
                                type_name.Add(objson.name, objson.type);
                                name_typeDict.Add(i, type_name);
                            }

                            i++;
                        }

                        return name_typeDict;
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

                public static string GetTaskTarget(string specname)
                {

                    IEnumerable<string> lineall = System.IO.File.ReadLines(path);
                    string sources = "";
                    foreach (var tt in lineall)
                    {
                        var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(tt);
                        if (objson.name == specname)
                        {
                            sources = objson.target;
                        }
                    }
                    Console.WriteLine(sources);
                    return sources;
                }

                public static string GetTaskSource(string specname)
                {

                    IEnumerable<string> lineall = System.IO.File.ReadLines(path);
                    string sources = "";
                    foreach (var tt in lineall)
                    {
                        var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(tt);
                        if (objson.name == specname)
                        {
                            sources = objson.source;
                        }
                    }
                    Console.WriteLine(sources);
                    return sources;
                }


                public static List<string> GetAllTasksName(string jsonfPath)
                {
                    List<string> namesList = new List<string>();
                    try
                    {
                        var d = System.IO.File.ReadLines(jsonfPath);

                        foreach (var x in d)
                        {
                            var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(x);


                            // var j = JsonConvert.SerializeObject(objson);
                            if (objson != null)
                            {
                                namesList.Add(objson.name);
                            }
                        }

                        return namesList;
                    }
                    catch (FileNotFoundException d)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(d);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        throw;
                    }
                    catch (IOException e)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        throw;
                    }
                }

                public static Dictionary<int, Dictionary<string, string>> GetTasksNameType(string jsonfPath, string tttname)
                {
                    Dictionary<int, Dictionary<string, string>> namesTypeList = new Dictionary<int, Dictionary<string, string>>();
                    Dictionary<string, string> namesTypeList1 = new Dictionary<string, string>();
                    try
                    {
                        var d = System.IO.File.ReadLines(jsonfPath);
                        int i = 0;
                        foreach (var x in d)
                        {
                            var objson = JsonConvert.DeserializeObject<TaskJsonAttribute>(x);


                            // var j = JsonConvert.SerializeObject(objson);
                            if (objson != null)
                            {
                                if (objson.name == tttname)

                                    namesTypeList1.Add(objson.name, objson.type);
                                namesTypeList.Add(i, namesTypeList1);
                            }

                            i++;
                        }

                        int zr = 0;
                        foreach (var xz in namesTypeList)
                        {

                            zr++;
                        }


                        return namesTypeList;
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
                public void jobToJson(string name, string source, string target, string type, List<string> ext , List<string> extPrio , string foSof , Int64 maxLen)
                {

                    Model.TaskJsonAttribute job_info = new Model.TaskJsonAttribute();

                    job_info.name = name;
                    job_info.source = source;
                    job_info.target = target;
                    job_info.type = type;
                    job_info.extension = ext;
                    job_info.extensionPrio = extPrio;
                    job_info.foSof = foSof;
                    job_info.maxLen = maxLen;

                    string JSONresult = JsonConvert.SerializeObject(job_info);



                    // Console.WriteLine($"\n Path to the json config : {path} \n");
                    Console.WriteLine($"\n The Json object result : {JSONresult} \n");
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(JSONresult.ToString());
                        tw.Close();
                    }
                }
                public bool CheckTaskName(string jsonTaskAllNamePath, string JobName)
                {
                    if (JobName == "" || JobName == null)
                    {
                        bool n = string.IsNullOrEmpty(JobName);
                        if (n)
                        {
                            return true;
                        }
                    }
                    List<string> TaskNames;
                    TaskNames = GetAllTasksName(jsonTaskAllNamePath);
                    foreach (var x in TaskNames)
                    {
                        if (x == JobName)
                        {
                            return true;
                        }
                    }

                    return false;
                }


                public bool CheckDirecotry(string sourcePath)
                {
                    bool dir = false;

                    if (System.IO.Directory.Exists(sourcePath))
                    {

                        dir = true;
                    }

                    // Console.WriteLine("down!");
                    // Console.WriteLine(dir);
                    return dir;
                }

                public bool CheckDirecotryExistFiles(string sourcePath)
                {
                    bool var = false;
                    if (CheckDirecotry(sourcePath))
                    {
                        try
                        {
                            int filesNumbers = System.IO.Directory.GetFiles(sourcePath).Length;
                            if (filesNumbers != 0)
                            {
                                var = true;
                            }
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            Console.WriteLine(e);
                            return var;

                        }
                        catch (PathTooLongException ex1)
                        {
                            Console.WriteLine(ex1);
                            return var;

                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine(ex);
                            return var;

                        }



                    }

                    return var;
                }

                public static void ExecuteSpecific(string pathit, string taskname,Int64 maxilen)
                {
                    List<string> namesList = new List<string>();
                    Dictionary<int, Dictionary<string, string>> namesAndType = GetTasksNameType(pathit, taskname);
                    Model t = new Model();
                    Json js = new Json();
                    int index = 0;



                    foreach (var ddx in namesAndType[index])
                    {
                        namesList.Add(ddx.Key);

                        if (ddx.Value == "complete" && ddx.Key == taskname)
                        {

                            //Console.WriteLine("true herer");



                            GetTaskDetailsaExecute(taskname, pathit, t, js);

                        }

                        if (ddx.Value != "complete")
                        {
                            //Console.WriteLine("not complete !");
                            // Model.Model Task_data = new Model.Model();
                            // List< Model.Model.File> EveryFileData = new List<Model.Model.File>();
                            // Model.Model.File files;
                            // var EveryFiletimer = new Stopwatch();
                            // EveryFiletimer.Start();
                            //
                            // TimeSpan timeTaken = EveryFiletimer.Elapsed; 
                            ViewModels.ExecuteAllJobViewModel.GetFileLogDetails(taskname,maxilen);
                            // EveryFiletimer.Stop();
                            // Task_data.TaskTime = timeTaken.TotalMilliseconds;
                            // Task_data.TaskTitle = taskname;
                            // Task_data.TaskFileNumber = 1;
                            // Task_data.TaskType = "incremental";
                            // Task_data.files = EveryFileData;
                            // Json jss = new Json();
                            // jss.converit(Task_data,"");
                            // Json.convertEtatJsonCreate(sourcePath,taskname,Task_data,EveryFileData.Count.ToString());
                        }
                        index++;
                    }
               
                }




                public static void GetTaskDetailsaExecute(string exname, string exsource, Model t, Json js)
                {

                    string[] line;

                    try
                    {
                        while ((line = System.IO.File.ReadAllLines(exsource)) != null)
                        {

                            for (int i = 0; i <= line.Length; i++)
                            {
                                if (line[i].Contains(exname))
                                {

                                    var objson = JsonConvert.DeserializeObject<Model.TaskJsonAttribute>(line[i]);
                                    var j = JsonConvert.SerializeObject(objson);
                                    var TaskrObj = JObject.Parse(j);

                                    if (TaskrObj != null)
                                    {
                                        string namee = Convert.ToString(TaskrObj["name"]);
                                        if (namee == exname)
                                        {
                                            //Console.WriteLine("here");
                                            string xs = Convert.ToString(TaskrObj["source"]);
                                            string extension = Convert.ToString(TaskrObj["extension"]);
                                            string xt = Convert.ToString(TaskrObj["target"]);
                                            string xtype = Convert.ToString(TaskrObj["type"]);
                                            Int64 maxLen = Convert.ToInt64(TaskrObj["maxLen"]);

                                            Console.WriteLine(extension);




                                            List<string> listo = objson.extension;
                                            Console.WriteLine(listo[0]);
                                            Console.WriteLine("UPPPPPPPPP");





                                            // Model.Model t = new Model.Model();
                                            List<Model.File> EveryFileData = new List<Model.File>();
                                            List<Model.File> EveryFileDat2 = new List<Model.File>();
                                            var timer = new Stopwatch();
                                            timer.Start();

                                             EveryFileDat2 = Copyf.copy(xs, xt, exname, xtype, t, js, EveryFileData, listo , maxLen , null);

                                        timer.Stop();
                                            TimeSpan timeTaken = timer.Elapsed;
                                            string xtime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                                            t.TaskTime = timeTaken.TotalMilliseconds;
                                            t.TaskTitle = exname;
                                            t.TaskFileNumber = EveryFileDat2.Count;
                                            t.files = EveryFileDat2;
                                            t.TaskType = xtype;
                                            t.TaskCryptedExtension = listo;

                                            js.converit(t, xs);
                                            Json.convertEtatJsonCreate(xs, exname, t, EveryFileDat2.Count.ToString());


                                            return;
                                        }


                                    }
                                }
                            }

                        }
                    }
                    catch (FileNotFoundException d)
                    {
                        //Console.BackgroundColor = ConsoleColor.White;
                        // Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(d);
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;

                    }
                    catch (IOException e)
                    {
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(e);
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;

                    }

                }


            }

        }
    }
