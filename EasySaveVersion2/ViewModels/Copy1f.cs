    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
using System.Net.Sockets;
using DefaultNamespace;
using SocketWshop;

namespace EasySave3._1_AN
    {
        public class Copy1f
        {

            public static EasySaveVersion2.ViewModels.CreateJobViewModel.Model.File copy1f(string sourcePath, string fileName, string targetPath, string title, List<string> ext)
            {
                EasySaveVersion2.ViewModels.CreateJobViewModel.Model.File fichier;
                Console.WriteLine(fileName);

                try
                {

                    // Model Task_data = new Model();
                    // List<Model.File> EveryFileData = new List<Model.File>();

                    var destFile = System.IO.Path.Combine(targetPath, fileName);
                    Console.WriteLine(targetPath);
                    var EveryFiletimer = new Stopwatch();
                    EveryFiletimer.Start();
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"\n SOURCE PATH :  {sourcePath} \n");
                    string et = new FileInfo(sourcePath + '/' + fileName).Extension;
                    long length = new FileInfo(sourcePath + '/' + fileName).Length;
                    Console.WriteLine("et" + et);
                    Console.WriteLine("ext" + "." + ext);
                    if (ext.Contains(et))
                    {
                        //Console.WriteLine("55555555555555555555555555555555555");
                        try
                        {
                            //Console.WriteLine("ANI HNA ...........");
                            Process p = new Process();
                            p.StartInfo.FileName = @"C:\CryptoSoft.exe";
                            p.StartInfo.Arguments = sourcePath + '\\' + fileName;
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.RedirectStandardError = true;

                            var cryptage = new Stopwatch();
                            cryptage.Start();


                            p.Start();
                            string output = p.StandardOutput.ReadLine();
                            cryptage.Stop();

                        Socket socket;
                        socket = SocketWshop.Client.SeConnecter();
                        Client.EcouterReseau(socket, fileName);
                        Client.Deconnecter(socket);
                        TimeSpan Cryptotime = cryptage.Elapsed;
                            Console.WriteLine("output is " + output);
                            Console.WriteLine("here" + "/home/juba/Desktop/docs/mvc2/" + fileName);
                            Console.WriteLine(targetPath);
                            Console.WriteLine(destFile);
                            bool etz = File.Exists(output);
                            Console.WriteLine("exist ! " + etz);

                            File.Copy(output, destFile, true);

                            // Console.WriteLine(output);
                            p.WaitForExit();
                            EveryFiletimer.Stop();
                            DateTime lastAccessTime = File.GetLastAccessTime(output);

                            TimeSpan EveryFiletimeTaken = EveryFiletimer.Elapsed;
                            fichier = new EasySaveVersion2.ViewModels.CreateJobViewModel.Model.File(sourcePath, targetPath, EveryFiletimeTaken.TotalMilliseconds, fileName, length, lastAccessTime, Cryptotime.TotalMilliseconds);
                            return fichier;
                        }
                        catch (FileNotFoundException dz)
                        {
                            Console.WriteLine(dz);
                        }

                    }

                    File.Copy(sourcePath + '/' + fileName, destFile, true);

                    FileInfo originalFile = new FileInfo(sourcePath);
                    // originalFile.CopyTo(targetPath+fileName, true);
                    EveryFiletimer.Stop();
                    TimeSpan timeTaken = EveryFiletimer.Elapsed;
                    string xtime = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

                    fichier = new EasySaveVersion2.ViewModels.CreateJobViewModel.Model.File(
                        sourcePath,
                        targetPath, timeTaken.TotalMilliseconds,
                        fileName,
                        new FileInfo(sourcePath + '/' + fileName).Length,
                        File.GetLastAccessTime(fileName), 0
                    );

                    // Task_data.TaskTime = timeTaken.TotalMilliseconds;
                    // Task_data.TaskTitle = title;
                    // Task_data.TaskFileNumber = 1;
                    // Task_data.TaskType = "incremental";
                    // EveryFileData.Add(task);
                    // Task_data.files = EveryFileData;
                    // Json js = new Json();
                    // js.converit(Task_data,sourcePath);
                    // Json.convertEtatJsonCreate(sourcePath,title,Task_data,1.ToString());


                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    return fichier;
                }
                catch (IOException e)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n ERROR : {e} \n");
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;

                }
                catch (UnauthorizedAccessException xzad)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n Unauthorized Access Exception ERROR : {xzad} \n");
                    //Console.BackgroundColor = ConsoleColor.White;
                    //Console.ForegroundColor = ConsoleColor.Black;
                }

                return null;
            }

        }
    }
