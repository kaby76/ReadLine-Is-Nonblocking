# ReadLine-Is-Nonblocking
[System.Console.ReadLine()](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) is a fundamental
function in the C# runtime. ReadLine() and WriteLine() play a critical role
in the input and output of data of NET console programs, the reason why NET Core was invented: to provide
a way for C# programs to run *consistently* across different targets.
For if a console program written in C# cannot run cross-target,
what would be the point of using C# on anything other than Windows?

Unfortunately, the heart of a C# console program does not even function as you would expect. In the following simple programs I wrote,
program "w" writes a single line of data using WriteLine() to stdout, and program "r" reads from stdin using ReadLine().
The two programs are intended to be used in a shell, connected together using a pipe. For Windows, the shell can be Cmd, Powershell, or Cygwin or a variant of Cygwin, such as MSYS2. On Linux, Bash is used. As
I cannot stand Cmd nor Powershell, I typically use MSYS2 or Cygwin.
But, the syntax for all shells is more or less the same: `w.exe | r.exe`.

The program `r.exe` should wait for the writer finish, then return the input until the end of file in the pipe. But, it doesn't:
the call to ReadLine() returns immediately with `null`.

According to the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) ReadLine()
should wait on input. In other words, it should be "blocking". But, it is not.

Here is a screen shot of program "r" returning an empty result, when it is clear, "w" has written data.

![To err is human, but not for computer](Screenshot%20(27).png)

On Linux, the "r" gets the data. When I use another non-C# program between the two
C# programs, i.e., `./w/bin/Debug/net5.0/w.exe 2 | sed 's/ / /' | ./r/bin/Debug/net5.0/r.exe`,
the "r" program works. If I add code to ignore the null result of the first call to ReadLine() and
try again, the second call to ReadLine() returns data! In other words, ReadLine() is not blocking, or there is a bug
in the C# runtime.

If ReadLine() is blocking, why did the method return without data? If it's non-blocking, how do I know when to stop trying to read the pipe?
