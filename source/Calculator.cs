////////////////////////////////////////////////////////////////////////////////

using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;

namespace MyTests{
////////////////////////////////////////////////////////////////////////////////
//class Calculator

sealed class Calculator
{
 public Calculator(OpCtx             opCtx,
                   AutomationElement mainWindow)
 {
  m_opCtx=opCtx;

  m_mainWindow=mainWindow;
 }//Calculator

 //-----------------------------------------------------------------------
 public string CalculatorResults
 {
  get
  {
   var element
    =HelperServices.GetTextBox
      (m_opCtx,
       m_mainWindow,
       ElementIDs.CalculatorResults);

   Helper__Log("Try read CalculatorResults value");

   var result=element.Properties.Name.Value;

   Helper__Log("CalculatorResults contains [{0}]",result);

   return result;
  }//get
 }//CalculatorResults

 //-----------------------------------------------------------------------
 public void Close()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.Close);
 }//Close

 //-----------------------------------------------------------------------
 public void ClearCalculatorResults()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.clearButton,ElementIDs.clearEntryButton);
 }//ClearCalculatorResults

 //-----------------------------------------------------------------------
 public void CopyCalculatorResultsToClipboard()
 {
  Helper__Log("CopyCalculatorResultsToClipboard...");

   var element
    =HelperServices.GetTextBox
      (m_opCtx,
       m_mainWindow,
       ElementIDs.CalculatorResults);


  element.SetForeground();
  element.Focus();

  Helper__Log("press Ctrl+C");

  Keyboard.TypeSimultaneously
   (FlaUI.Core.WindowsAPI.VirtualKeyShort.LCONTROL,
    FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_C);
 }//CopyCalculatorResultsToClipboard

 //-----------------------------------------------------------------------
 public void PasteCalculatorResultsFromClipboard()
 {
  Helper__Log("PasteCalculatorResultsFromClipboard...");

   var element
    =HelperServices.GetTextBox
      (m_opCtx,
       m_mainWindow,
       ElementIDs.CalculatorResults);

  element.SetForeground();
  element.Focus();

  Helper__Log("press Ctrl+V");

  Keyboard.TypeSimultaneously
   (FlaUI.Core.WindowsAPI.VirtualKeyShort.LCONTROL,
    FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_V);

  //Let the calculator digest latest operation
  HelperServices.Thread_Sleep(m_opCtx,1*1000);
 }//PasteCalculatorResultsFromClipboard

 //-----------------------------------------------------------------------
 public string GetHeader()
 {
  var element=HelperServices.GetElement(m_opCtx,m_mainWindow,ElementIDs.Header);

  Helper__Log("Try read Header value");

  var result=element.Properties.Name.Value;

  Helper__Log("Header contains [{0}]",result);

  return result;
 }//GetHeader

 //-----------------------------------------------------------------------
 public void TryExitAlwaysOnTopButton()
 {
  Helper__Log("TryExitAlwaysOnTopButton");

  var button=HelperServices.TryGetButton(m_opCtx,m_mainWindow,ElementIDs.ExitAlwaysOnTopButton);

  if(Object.ReferenceEquals(button,null))
   return;

  button.Invoke();
 }//TryExitAlwaysOnTopButton

 //-----------------------------------------------------------------------
 public void setMode__Standard()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.TogglePaneButton);
  Helper__MainWindowElement_Invoke(ElementIDs.Standard);
 }//setMode__Standard

 //-----------------------------------------------------------------------
 public void setMode__Programmer()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.TogglePaneButton);
  Helper__MainWindowElement_Invoke(ElementIDs.Programmer);
 }//setMode__Programmer

  //-----------------------------------------------------------------------
 public void programmerMode__check_hexButton()
 {
  HelperServices.SelectItem(m_opCtx,m_mainWindow,ElementIDs.hexButton);
 }//programmerMode__check_hexButton

  //-----------------------------------------------------------------------
 public void programmerMode__check_decimalButton()
 {
  HelperServices.SelectItem(m_opCtx,m_mainWindow,ElementIDs.decimalButton);
 }//programmerMode__check_decimalButton

 //-----------------------------------------------------------------------
 public string programmerMode__get_hexButtonText()
 {
  return HelperServices.GetPropertyNameValue(m_opCtx,m_mainWindow,ElementIDs.hexButton);
 }//programmerMode__get_hexButtonText

 //-----------------------------------------------------------------------
 public string programmerMode__get_decimalButtonText()
 {
  return HelperServices.GetPropertyNameValue(m_opCtx,m_mainWindow,ElementIDs.decimalButton);
 }//programmerMode__get_decimalButtonText

 //-----------------------------------------------------------------------
 public void press__Num1Button()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.num1Button);
 }//press__Num1Button

 //-----------------------------------------------------------------------
 public void press__Num2Button()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.num2Button);
 }//press__Num2Button

 //-----------------------------------------------------------------------
 public void press__Num3Button()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.num3Button);
 }//press__Num2Button

 //-----------------------------------------------------------------------
 public void press__PlusButton()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.plusButton);
 }//press__PlusButton

 //-----------------------------------------------------------------------
 public void press__MultiplyButton()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.multiplyButton);
 }//press__MultiplyButton

 //-----------------------------------------------------------------------
 public void press__EqualButton()
 {
  Helper__MainWindowElement_Invoke(ElementIDs.equalButton);
 }//press__EqualButton

 //-----------------------------------------------------------------------
 private void Helper__MainWindowElement_Invoke(params string[] ids)
 {
  HelperServices.Invoke(m_opCtx,m_mainWindow,ids);
 }//Helper__MainWindowElement_Invoke

 //-----------------------------------------------------------------------
 private void Helper__Log(string formatStr,params object[] args)
 {
  m_opCtx.Logger.Send(formatStr,args);
 }//Helper__Log

 //-----------------------------------------------------------------------
 private readonly OpCtx             m_opCtx;
 private readonly AutomationElement m_mainWindow;
};//class Calculator

////////////////////////////////////////////////////////////////////////////////
}//namespace MyTests
