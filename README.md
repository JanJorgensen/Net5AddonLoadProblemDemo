# Net5AddonLoadProblemDemo
Files demonstrating the problem with load of System.IO.Ports.dll when used from addon class library in .NET 5


When the WPF application TheApp is started and the UI button is pressed, the assembly TheAddon.dll is loaded via reflection, the class AddonMain is instantiated and its method 'Action' is called.

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

It makes no difference to use version 5.0.1 or 6.0.0 of System.IO.Ports.dll.

I also added another WPF applicalication (TheDirectUserApp) that directly has a project reference to TheAddon. That makes the application load the System.IO.Ports.dll directly when started, and everything works.
But that's not what I want. I don''t wish to have hard references to all my addons from all my wpf and console applications.
As a side effect, I now get a System.PlatformNotSupportedException (""System.IO.Ports is currently only supported on Windows"") if TheDirectUserApp has been executed before TheApp.
Building TheDirectUserApp creates the ""runtimes"" folder in the output folder, where System.IO.Ports.dll can be found in runtimes\win\lib\netstandard2.0 (not net5.0 !!). At the same time System.IO.Ports.dll is also copied directly into the output folder.
