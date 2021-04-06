# ReadLine-Is-Nonblocking
[System.Console.ReadLine()](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) is a fundamental
function in the C# runtime. ReadLine() and WriteLine() play a critical role
in input and output for of NET console programs, the reason why NET Core was invented: to provide
a way for C# programs to run across different targets.
For if a console program written in C# cannot run cross-target,
what would be the point of using C# on anything other than Windows?

Unfortunately, the heart of a C# console program does not even function as you would expect. In the following simple programs I wrote,
program "w" writes a single line of data using WriteLine() to stdout, and program "r" reads from stdin using ReadLine().
The two programs are connected using a pipe in a shell. The shell used can be Cmd, or Powershell, or Bash on Linux. On Windows,
I cannot stand Cmd nor Powershell, so I use MSYS2 or Cygwin.
The syntax for all shells is the same: `w.exe | r.exe`.

The program `r.exe` should wait for the writer finish, then return the input until the end of file in the pipe. But, it doesn't:
the call to ReadLine() returns immediately with `null`.

According to the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) ReadLine()
should wait on input. In other words, it should be "blocking". But, it is not.

Here is a screen shot of program "r" returning an empty result, when it is clear, "w" has written data.

![To err is human, but not for computer](Screenshot%20(27).png)

On Linux, the ReadLine() works. When I use another non-C# program inbetween the two
C# programs, e.g., `./w/bin/Debug/net5.0/w.exe 2 | sed 's/ / /' | ./r/bin/Debug/net5.0/r.exe`,
the ReadLine() gets data.

If ReadLine() is blocking, why did the method return without data? If it's non-blocking, how do I know when to stop trying to read the pipe?
