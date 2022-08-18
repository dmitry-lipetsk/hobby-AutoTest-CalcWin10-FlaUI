////////////////////////////////////////////////////////////////////////////////

using System;
using FlaUI.UIA3;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace MyTests{
////////////////////////////////////////////////////////////////////////////////
//class Program

static class Program
{
 [STAThread]
 public static int Main()
 {
  int errCount=0;

  try
  {
   var logger=new Logger();

   errCount+=Exec(logger);
  }
  catch(Exception exc)
  {
   ++errCount;

   for(var e=exc;e!=null;e=e.InnerException)
   {
    Console.WriteLine("ERROR: {0} - {1}",e.Source,e.Message);
   }
  }//catch

  return errCount;
 }//Main

 //-----------------------------------------------------------------------
 public static int Exec(Logger logger)
 {
  int errCount=0;

  try
  {
   var opCtx=new OpCtx(logger);

   var app=HelperServices.LaunchStoreApp(opCtx,"Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

   using var automation=new UIA3Automation();

   var window1=app.GetMainWindow(automation);

   HelperServices.LogWindowInfo(opCtx,window1);

   var window=HelperServices.GetWindowParent(opCtx,window1);

   HelperServices.LogWindowInfo(opCtx,window);

   var calculator=new Calculator(opCtx,window);

   //---------------------------------------
   //HelperServices.Thread_Sleep(opCtx,10000);

   calculator.TryExitAlwaysOnTopButton();

   calculator.setMode__Standard();

   HelperServices.CheckData
    (calculator.GetHeader(),
     "Standard Calculator mode");

   //---------------------------------------
   calculator.ClearCalculatorResults();

   calculator.press__Num1Button();

   HelperServices.Clipboard__Clear(opCtx);

   calculator.CopyCalculatorResultsToClipboard();

   HelperServices.CheckData
    (HelperServices.Clipboard__GetText(opCtx),
     "1");

   calculator.ClearCalculatorResults();

   //---------------------------------------
   HelperServices.Clipboard__SetText(opCtx,"321");

   calculator.PasteCalculatorResultsFromClipboard();

   //---------------------------------------
   HelperServices.CheckData(calculator.CalculatorResults,"Display is 321");

   //---------------------------------------
   calculator.press__PlusButton();
   calculator.press__Num2Button();
   calculator.press__EqualButton();

   HelperServices.CheckData(calculator.CalculatorResults,"Display is 323");

   //---------------------------------------
   calculator.press__Num2Button();
   calculator.press__MultiplyButton();
   calculator.press__Num3Button();
   calculator.press__EqualButton();

   HelperServices.CheckData(calculator.CalculatorResults,"Display is 6");

   //---------------------------------------
   calculator.ClearCalculatorResults();

   HelperServices.CheckData(calculator.CalculatorResults,"Display is 0");

   //---------------------------------------
   calculator.setMode__Programmer();

   HelperServices.CheckData
    (calculator.GetHeader(),
     "Programmer Calculator mode");

   calculator.programmerMode__check_hexButton();

   calculator.press__Num2Button();
   calculator.press__MultiplyButton();
   calculator.press__Num3Button();
   calculator.press__MultiplyButton();
   calculator.press__Num2Button();
   calculator.press__EqualButton();

   HelperServices.CheckData(calculator.CalculatorResults,"Display is C ");

   //---------------------------------------
   HelperServices.CheckData
    (calculator.programmerMode__get_hexButtonText(),
     "HexaDecimal C ");

   HelperServices.CheckData
    (calculator.programmerMode__get_decimalButtonText(),
     "Decimal 12");

   //---------------------------------------
   calculator.Close();

   //---------------------------------------
   opCtx.Logger.Send("OK. Go home!");

   HelperServices.Thread_Sleep(opCtx,5000);
  }
  catch(Exception exc)
  {
   ++errCount;

   for(var e=exc;e!=null;e=e.InnerException)
   {
    logger.Send("ERROR: {0} - {1}",e.Source,e.Message);
   }
  }//catch

  return errCount;
 }//Exec
};//class Program

////////////////////////////////////////////////////////////////////////////////
}//namespace MyTests
