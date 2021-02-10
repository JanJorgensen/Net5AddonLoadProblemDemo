# Net5AddonLoadProblemDemo
Files demonstrating the problem with load of System.IO.Ports.dll when used from addon class library in .NET 5


When executed and the button is pressed, the assembly TheAddon.dll is loaded via reflection, the class AddonMain is instantiated and its method 'Action' is called.

At the moment 'Action' is called, this error happens:

```
System.IO.FileNotFoundException
  HResult=0x80070002
  Message=Could not load file or assembly 'System.IO.Ports, Version=5.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. The system cannot find the file specified.
  Source=TheAddon
  StackTrace:
   at TheAddon.AddonMain.Action() in C:\SW_development\JustTry\Net5AddonLoadProblemDemo\TheAddon\AddonMain.cs:line 12
   at TheCore.AddonLoader.LoadTheAddon() in C:\SW_development\JustTry\Net5AddonLoadProblemDemo\TheCore\AddonLoader.cs:line 16
   at TheApp.MainWindow.button_Click(Object sender, RoutedEventArgs e) in C:\SW_development\JustTry\Net5AddonLoadProblemDemo\TheApp\MainWindow.xaml.cs:line 30
   .
   .
   .
   at System.Windows.Application.Run()
   at TheApp.App.Main()
```
