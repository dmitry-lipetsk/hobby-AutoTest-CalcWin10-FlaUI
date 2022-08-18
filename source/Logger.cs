﻿////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;

namespace MyTests{
////////////////////////////////////////////////////////////////////////////////
//class Loggerger

class Logger
{
 public void Send(string formatStr,params object?[] args)
 {
  var args2=args.Select(x=>HelperServices.WrapData(x)).ToArray();

  Console.WriteLine(formatStr,args2);
 }//Send
};//class Logger

////////////////////////////////////////////////////////////////////////////////
}//namespace MyTests
