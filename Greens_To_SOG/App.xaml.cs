using System;
using System.Linq;
using System.Windows;

namespace Greens_To_SOG
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// goes in where you want to access it
   /// if (Application.Current.Properties["CommandLineArgs"] != null)
   /// ParseArgs((string[])Application.Current.Properties["CommandLineArgs"]);

   /// </summary>
   public partial class App : Application
   {
      /*******************************************************************************
      Function    : OnStartup()
      Description : 
      Parameters  : StartupEventArgs e - 
      Returns     : void
      --------------------------------------------------------------------------------
      History:
      2014/11/14 TPR Created
      *******************************************************************************/
      protected override void OnStartup(StartupEventArgs e)
      {
         Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

         if (e.Args != null && e.Args.Count() > 0)
         {
            this.Properties["CommandLineArgs"] = e.Args;
         }
            
         
      }
      /*******************************************************************************
      Function    : Current_DispatcherUnhandledException()
      Description : 
      Parameters  : object sender - 
                  : System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e - 
      Returns     : void
      --------------------------------------------------------------------------------
      History:
      2016/02/29 TPR Created
      *******************************************************************************/
      void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
      {

         MessageBox.Show(string.Format("Unhandled Exception\r\nPlease send logfile and screenshot to GGS\r\n{0}", e.Exception.Message), "Unhandled Error", MessageBoxButton.OK, MessageBoxImage.Error);

         /* Prevent default unhandled exception processing */
         e.Handled = true;
         
      }
   }
}
