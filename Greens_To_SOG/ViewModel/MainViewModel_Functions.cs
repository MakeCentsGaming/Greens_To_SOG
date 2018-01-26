using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Greens_To_SOG
{
   /// <summary>
   /// 
   /// </summary>
   public partial class MainViewModel
   {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="obj"></param>
      private void fnClose(object obj = null)
      {
         CloseAction();
      }

      //MVM.MakeAbout();
      /// <summary>
      /// MVM.MakeAbout();
      /// <Label x:Name="About" Content="{ Binding About, Mode = TwoWay, UpdateSourceTrigger = PropertyChanged}" Margin="0,-3.283,3,0" VerticalAlignment="Top" HorizontalAlignment="Right" Width="101.967" Height="25.96"/>
      /// </summary>
      public string fnMakeAbout()
      {
         Version v = Assembly.GetExecutingAssembly().GetName().Version;
         About = string.Format(CultureInfo.InvariantCulture, @"Version {0}.{1}.{2} (r{3})", v.Major, v.Minor, v.Build, v.Revision);
         return About;
      }

      // <summary>
      /// 
      /// </summary>
      /// <param name="obj"></param>
      public void fnParseList(object obj = null)
      {
         if (Application.Current.Properties["CommandLineArgs"] != null)
         {
            Files = (string[])Application.Current.Properties["CommandLineArgs"];
         }
         if (Files == null) return;
            //Files = new string[] { @"C:\Users\davidg\source\repos\ExtractRBG_FromGreen\ExtractRBG_FromGreen\images\WORK_FOLDER\~&-caac_concrete_damaged_03_c~7c4a2f13.tiff" };
            //MessageBox.Show("wdfskdfsd");
            foreach (string file in Files)
         {
            //Here is where the items drug into the tool will be as file
            //MessageBox.Show(file);
            CmdOutput += file + Environment.NewLine;
            RunThisFile = file;
            fnRunThisFile();
         }
         //MessageBox.Show("Finished");
         //don't forget to close when done
      }

      // <summary>
      /// 
      /// </summary>
      /// <param name="obj"></param>
      public void fnRunThisFile(object obj = null)
      {
         string file = RunThisFile;
         if(obj!=null)
         {
            file = (string)obj;
         }
         if (Directory.Exists(file))
         {
            CmdOutput += file;
            if (Path.GetFileName(file) == "originals")
            {
               MessageBox.Show("Not doing this image because it is in the orignals folder and has already been done.");
               return;
            }
            string[] allfiles = System.IO.Directory.GetFiles(file, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string o in allfiles)
            {
               clsExtractRBG.ExtractThese(o);
            }
         }
         else if (File.Exists(file))
         {
            if (Path.GetFileName(Path.GetDirectoryName(file)) == "originals")
            {
               MessageBox.Show("Not doing this image because it is in the orignals folder and has already been done.");
               return;
            }
            
            clsExtractRBG.ExtractThese(file);
         }
         if(stringWriter!=null)
         {
            consoleOutput = stringWriter.ToString();
         }

      }
      
      // <summary>
      /// 
      /// </summary>
      /// <param name="obj"></param>
      private void fnRunSOG(object obj = null)
      {
         BackgroundWorker bg = new BackgroundWorker();
         bg.DoWork += Bg_DoWork;
         bg.RunWorkerCompleted += Bg_RunWorkerCompleted;
         bg.RunWorkerAsync();
      }

      private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine("");
         Console.WriteLine("======================================= Done ===============================");
         Console.ReadLine();
         consoleOutput = stringWriter.ToString();
         MessageBox.Show("Image extraction completed.\n\nSee log window for more information.", "Finished",
            MessageBoxButton.OK, MessageBoxImage.Information);
      }

      private void Bg_DoWork(object sender, DoWorkEventArgs e)
      {
        // myconsoleOutput = "testing sdfkjsdl;kfjds";
         if (DirList == null) return;
         while(DirList.Count>0)
         {
            fnRunThisFile(DirList[0]);
            if(DirList.Count>0)
            {
               App.Current.Dispatcher.Invoke((Action)delegate 
               {
                  DirList.Remove(DirList[0]);
               });
            }
         }
         
      }
   }/* End Class */
}/* End NameSpace */
