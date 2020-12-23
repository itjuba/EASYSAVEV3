using System;
using System.Collections.Generic;
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
using System.Threading.Tasks;
using System.Threading;





namespace EasySaveVersion2.View
{
    /// <summary>
    /// Logique d'interaction pour BackupInProgressView.xaml
    /// </summary>
    /// 

    public partial class BackupInProgressView : UserControl
    {
   
        public  BackupInProgressView()
        {
            InitializeComponent();
        }

        private void Progress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {        
        }


        static string EndDirectory = @"C:\Users\liabel\Desktop\targetee";
        static string StartDirectory = @"‪C:\Users\liabel\Desktop\sourcee\test.txt";

        private  void Play_Click(object sender, RoutedEventArgs e)
        {
            Parallel.Invoke(
            () =>
              {
                  copyFileTPL(StartDirectory, EndDirectory);
              }
            );
        }

        private static void copyFileTPL(string sourceFile, string targetFile)
        {
            Console.WriteLine("File Copy Operation using the Task Parallel Library");
            Console.WriteLine("File to copy: " + sourceFile);
            Console.WriteLine("Copying file...");

            int count = 0;
            int targetCount = Directory.GetFiles(targetFile).Length;
            int sourceCount = Directory.GetFiles(@"C:\Users\liabel\Desktop\sourcee").Length;
            Console.WriteLine(sourceCount);

            while (targetCount != sourceCount)
            {
/*              File.Copy(sourceFile, targetFile);
*/              ++count;
                float progress = (count / sourceCount) * 100;
                Console.WriteLine("Progress: " + Math.Round(progress, 2).ToString() + "% (rows copied: " + count.ToString() + ")");
                
            }
            Console.WriteLine("Original File: " + sourceFile);
            Console.WriteLine("New File: " + targetFile);
        }



    }
}

