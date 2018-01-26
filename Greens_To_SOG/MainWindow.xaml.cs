using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Greens_To_SOG
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      [DllImport("Kernel32")]
      public static extern void AllocConsole();

      [DllImport("Kernel32")]
      public static extern void FreeConsole();

      public MainViewModel MVM { get { return this.DataContext as MainViewModel; } }
		public MainWindow()
      {
         InitializeComponent();
         MVM.ControlsAvail = true;
         
         string[] Files = (string[])Application.Current.Properties["CommandLineArgs"];
         if (Files!=null &&  Files.Length>0)
            this.WindowState = WindowState.Minimized;
         else {
            MVM.stringWriter = new StringWriter();
            Console.SetOut(MVM.stringWriter);
            
            MVM.ConvertImage = "pack://application:,,,/Images/Green.png";
            MVM.OConvertImage = "pack://application:,,,/Images/O.png";
            MVM.GConvertImage = "pack://application:,,,/Images/G.png";
            MVM.SConvertImage = "pack://application:,,,/Images/S.png";
         }
         clsDragNDrop.ListDragNDrop(fileslist,this);
      }
      
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         
         
         if (Application.Current.Properties["CommandLineArgs"] != null)
         {
            
            AllocConsole();
            Intro();
            MVM.fnParseList();
            /*Console.WriteLine("test");
            
            MVM.Files = (string[])Application.Current.Properties["CommandLineArgs"];
            Console_Outputxaml cmdoutput = new Console_Outputxaml();
            cmdoutput.ShowDialog();
            //MessageBox.Show("closing now");
            this.Close();*/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("======================================= Done ===============================");
            //Console.Beep();
            Console.ReadLine();

            FreeConsole();
            this.Close();
         }
      }

      private void Intro()
      {
         string ver = MVM.fnMakeAbout();
         Console.WriteLine("");
         Console.WriteLine("=========================== Greens To SOG ====================================");
         Console.WriteLine("");
         Console.WriteLine("   Version: " + ver);
         Console.WriteLine("      by:");
         Console.WriteLine("   _____            __            _________                    __           ");
         Console.WriteLine(@"  /     \  _____   |  | __  ____  \_   ___ \   ____    ____  _/  |_   ______");
         Console.WriteLine(@" /  \ /  \ \__  \  |  |/ /_/ __ \ /    \  \/ _/ __ \  /    \ \   __\ /  ___/");
         Console.WriteLine(@"/    Y    \ / __ \_|    < \  ___/ \     \____\  ___/ |   |  \ |  |   \___ \ ");
         Console.WriteLine(@"\____|__  /(____  /|__|_ \ \___  > \______  / \___  >|___|  / |__|  /____  >");
         Console.WriteLine(@"        \/      \/      \/     \/         \/      \/      \/             \/ ");

         Console.WriteLine("");
         Console.WriteLine("=============================================================================");
         Console.WriteLine("");
         Console.WriteLine("Ready to begin:");
         Console.WriteLine("");
         
      }

      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         consolelog.ScrollToEnd();
      }
   }
}
