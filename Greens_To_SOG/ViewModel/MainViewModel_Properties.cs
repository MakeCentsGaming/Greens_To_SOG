using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Timers;
using System.Windows;

namespace Greens_To_SOG
{
   /// <summary>
   /// 
   /// </summary>
   public partial class MainViewModel
   {      
      private Timer Clock { get; set; }            
      private static MainViewModel _instance;
      /// <summary>
      /// 
      /// </summary>
      public static MainViewModel Instance
      {
         get { return _instance; }
         set
         {
            _instance = value;
            if (_instance != null)
               _instance.OnPropertyChanged("Instance");
         }
      }
      /// <summary>
      /// 
      /// </summary>
      public Window MyParentWindow { get; set; }
      
      /// <summary>
      /// 
      /// </summary>
      public Action CloseAction { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Action SetWaitCursor { get; set; }

      /// <summary>
      /// 
      /// </summary>
      public Action SetNormalCursor { get; set; }

      private string _WelcomeMessage;
      /// <summary>
      /// 
      /// </summary>
      public string WelcomeMessage
      {
         get { return _WelcomeMessage; }
         set
         {
            _WelcomeMessage = value;
            OnPropertyChanged("WelcomeMessage");
         }
      }

      private string _CurrentDisplayDate;
      /// <summary>
      /// 
      /// </summary>
      public string CurrentDisplayDate
      {
         get { return _CurrentDisplayDate; }
         set
         {
            _CurrentDisplayDate = value;
            OnPropertyChanged("CurrentDisplayDate");
         }
      }
      

      private Visibility _OverlayVisibility;
      /// <summary>
      /// 
      /// </summary>
      public Visibility OverlayVisibility
      {
         get { return _OverlayVisibility; }
         set
         {
            _OverlayVisibility = value;
            OnPropertyChanged("OverlayVisibility");
         }
      }
      

      private string _OverlayMessage;
      /// <summary>
      /// 
      /// </summary>
      public string OverlayMessage
      {
         get { return _OverlayMessage; }
         set
         {
            _OverlayMessage = value;
            OnPropertyChanged("OverlayMessage");
         }
      }
      

      private bool _LayoutRootEnabled;
      /// <summary>
      /// 
      /// </summary>
      public bool LayoutRootEnabled
      {
         get { return _LayoutRootEnabled; }
         set
         {
            _LayoutRootEnabled = value;
            OnPropertyChanged("LayoutRootEnabled");
         }
      }


      private ObservableCollection<string> _DirList;
      /// <summary>
      /// 
      /// </summary>
      public ObservableCollection<string> DirList
      {
         get { return _DirList; }
         set
         {
            _DirList = value;
            OnPropertyChanged("DirList");
         }
      }

      private string _About;
      /// <summary>
      /// 
      /// </summary>
      public string About
      {
         get { return _About; }
         set
         {
            _About = value;
            OnPropertyChanged("About");
         }
      }

      private string _RunThisFile;
      /// <summary>
      /// 
      /// </summary>
      public string RunThisFile
      {
         get { return _RunThisFile; }
         set
         {
            _RunThisFile = value;
            OnPropertyChanged("RunThisFile");
         }
      }

      private string _CmdOutput;
      /// <summary>
      /// 
      /// </summary>
      public string CmdOutput
      {
         get { return _CmdOutput; }
         set
         {
            _CmdOutput = value;
            OnPropertyChanged("CmdOutput");
         }

      }
      private string[] _Files;
      /// <summary>
      /// 
      /// </summary>
      public string[] Files
      {
         get { return _Files; }
         set
         {
            _Files = value;
            OnPropertyChanged("Files");
         }
      }


      private string _ConvertImage;
      /// <summary>
      /// 
      /// </summary>
      public string ConvertImage
      {
         get { return _ConvertImage; }
         set
         {
            _ConvertImage = value;
            OnPropertyChanged("ConvertImage");
         }
      }

      private string _OConvertImage;
      /// <summary>
      /// 
      /// </summary>
      public string OConvertImage
      {
         get { return _OConvertImage; }
         set
         {
            _OConvertImage = value;
            OnPropertyChanged("OConvertImage");
         }
      }

      private string _GConvertImage;
      /// <summary>
      /// 
      /// </summary>
      public string GConvertImage
      {
         get { return _GConvertImage; }
         set
         {
            _GConvertImage = value;
            OnPropertyChanged("GConvertImage");
         }
      }
      private string _SConvertImage;
      /// <summary>
      /// 
      /// </summary>
      public string SConvertImage
      {
         get { return _SConvertImage; }
         set
         {
            _SConvertImage = value;
            OnPropertyChanged("SConvertImage");
         }
      }

      private string _consoleOutput;
      /// <summary>
      /// 
      /// </summary>
      public string consoleOutput
      {
         get { return _consoleOutput; }
         set
         {
            _consoleOutput = value;
            OnPropertyChanged("consoleOutput");
         }
      }

      private StringWriter _stringWriter;
      /// <summary>
      /// 
      /// </summary>
      public StringWriter stringWriter
      {
         get { return _stringWriter; }
         set
         {
            _stringWriter = value;
            OnPropertyChanged("stringWriter");
         }
      }
      private bool _ControlsBusy;
      /// <summary>
      /// 
      /// </summary>
      public bool ControlsAvail
      {
         get { return _ControlsBusy; }
         set
         {
            _ControlsBusy = value;
            OnPropertyChanged("ControlsBusy");
         }
      }
   }/* End Class */
}/* End NameSpace */