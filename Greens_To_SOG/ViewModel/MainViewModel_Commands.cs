using System.Windows.Input;

namespace Greens_To_SOG
{
   /// <summary>
   /// 
   /// </summary>
   public partial class MainViewModel
   {
      private ICommand pClose;
      /// <summary>
      /// 
      /// </summary>
      public ICommand CmdClose
      {
         get { return pClose = new DelegateCommand(fnClose); }
      }

      private ICommand pRunSOG;
      /// <summary>
      /// 
      /// </summary>
      public ICommand CmdRunSOG
      {
         get { return pRunSOG = new DelegateCommand(fnRunSOG); }
      }

   }/* End Class */
}/* End NameSpace */
