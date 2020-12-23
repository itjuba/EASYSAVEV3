using DefaultNamespace;
using SocketWshop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
 using System.Linq;
using System.Net.Sockets;
using System.Text;
 using System.Threading;

using static EasySaveVersion2.ViewModels.CreateJobViewModel;
using static EasySaveVersion2.ViewModels.ExecuteAllJobViewModel;

namespace ConsoleApplication1
{
  
    public class Copyf
    {
       public struct Bigfiles
        {
            public string source;
            public string filename;
            public long filezie;
            public DateTime accesstime;
            public string target;
            public string jobname;
            public string type;

        }


        public static string fileName;
        private static int fileNumber = 0;
        private static int fileNumber1 = 0;
        
        
        static string ProgressBar(int progress)
        {
            // Convertit le progress en texte, et on fixe la longueur à 3 caractères avec un petit PadLeft 
            string textual = progress.ToString().PadLeft(3, ' ');
            // Réutilisation de la même string pour afficher un texte représentant le progrès
            textual = "Progress " + textual + "% ";
            // Calcul de la taille disponible pour la progressbar
            // Console.WindowWidth retourne le nombre de colonnes de la console.
            // Il faut retrancher 1 car sinon le texte fait exactement la largeur de la console, 
            // ce qui entraînerait de facto un retour à la ligne (et ce serait moche, et l'effet 
            // progressbar disparaîtrait...)
            int barsize = Console.WindowWidth - 1 - textual.Length;
            // Initialisation d'un string builder d'une capacité égale à la taille de la progressbar
            string p = "#";
            // Une petit règle de trois pour caler le progrès sur la taille de la progressbar
            progress = progress * barsize / 100;
 
            // Et la fonction retourne une string avec des padding sur la gauche pour afficher le progress
            // et un padding sur la droite pour donner une arrière plan à la progressbar
            return textual + p.ToString().PadLeft(progress, Convert.ToChar("#"));
        }
        public static   List<Model.File>  copy(string sourcePath, 
                                                    string targetPath,
                                                    string name,
                                                    string type, 
                                                    Model t,
                                                    Json j, 
                                                    List<Model.File> EveryFileData2,
                                                    List<string> ext ,
                                                    Int64 maxLen ,
                                                    ExampleCallback callbak
                                                    )
        {
            List<Model.File> EveryFileData = new List<Model.File>();
            string[] files = System.IO.Directory.GetFiles(sourcePath);

            List<string> lists = new List<string>();
            ConcurrentStack<Bigfiles> bigfilesall = new ConcurrentStack<Bigfiles>();
            try
                {
                    var timer = new Stopwatch();
                    timer.Start();
                foreach (string s in files)
                    {
                        var EveryFiletimer = new Stopwatch();
                        EveryFiletimer.Start();
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        //Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"\n DOWN : {fileName} \n");
                        var destFile = System.IO.Path.Combine(targetPath, fileName);
                        long length = new FileInfo(s).Length;
                        string et = new FileInfo(s).Extension;
                     
                        Console.WriteLine("YANIS AW HNA" + et);
                        Console.WriteLine("YANIS AW HNA" + "." + ext);
                        int xd = 0;

                            if (length >= maxLen)
                            {
                        Bigfiles bifieldata = new Bigfiles();
                        bifieldata.source = s;
                        bifieldata.target = destFile;
                        bifieldata.jobname = name;
                        bifieldata.type = type;
                        bifieldata.filezie = length;
                        bifieldata.filename =fileName;
                        bifieldata.accesstime = DateTime.Today;
                              bigfilesall.Push(bifieldata);
                                callbak(bigfilesall);
                                bigfilesall.Clear();
                                Console.WriteLine("RAK KBIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIR " + maxLen);
                              
                                continue;
 
                              
                            }
                    Socket socket;


                    socket = Client.SeConnecter();

                    Client.EcouterReseau(socket, fileName);
                    Client.Deconnecter(socket);



                    if (ext.Contains(et))
                            {
                                xd++;
                                try
                                {
                                    Console.WriteLine("ANI HNA ...........");
                                    Process p = new Process();
                                    p.StartInfo.FileName = @"C:\CryptoSoft.exe";
                                    p.StartInfo.Arguments = s;
                                    p.StartInfo.UseShellExecute = false;
                                    p.StartInfo.RedirectStandardOutput = true;
                                    p.StartInfo.RedirectStandardError = true;
                                    
                                    
                                    var cryptage = new Stopwatch();
                                
                                    cryptage.Start();
                                    p.Start();
                                    string output = p.StandardOutput.ReadLine();
                                    cryptage.Stop();
                                    TimeSpan Cryptotime = cryptage.Elapsed;
                                    Console.WriteLine("cryptage =========="+Cryptotime.TotalMilliseconds);
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
                                    EveryFileData2.Add(new Model.File(sourcePath, 
                                                                        targetPath,
                                                                         EveryFiletimeTaken.TotalMilliseconds, 
                                                                         fileName, 
                                                                         length, 
                                                                         lastAccessTime,
                                                                         Cryptotime.TotalMilliseconds));
                                    fileNumber++;
                                            
                                }
                                catch (FileNotFoundException dz)
                                {
                                    Console.WriteLine(dz);
                                }

                            }

                            
                    

                            else
                            {
                                DateTime lastAccessTime = File.GetLastAccessTime(s);
                                System.IO.File.Copy(s, destFile, true);
                                Console.WriteLine(s);
                                EveryFiletimer.Stop();
                                TimeSpan EveryFiletimeTaken = EveryFiletimer.Elapsed;
                                EveryFileData2.Add(new Model.File(sourcePath, targetPath,
                                    EveryFiletimeTaken.TotalMilliseconds, fileName, length, lastAccessTime,0));
                                fileNumber++;
                            }

                            // Console.WriteLine(fileNumber);
                     
                        Console.WriteLine(xd);
                    }

                    var directories = Directory.GetDirectories(sourcePath);
                    int d = 0;
              
                foreach (var x in directories)
                    {
                        Console.WriteLine(x);
                        string dirname = new DirectoryInfo(x).Name;
                        Directory.CreateDirectory(targetPath + '\\'+dirname);
                        copy(sourcePath + '\\' + dirname, targetPath + '\\' + dirname, name, type , t, j, EveryFileData2, ext, maxLen, callbak);

                    }
                // Console.WriteLine("1");
                //

            }
            
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
                return EveryFileData2;
        }
    }
}