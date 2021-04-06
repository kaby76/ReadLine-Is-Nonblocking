# ReadLine-Is-Nonblocking
[System.Console.ReadLine()](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) is a critical function in the C# runtime. ReadLine() and WriteLine() play a critical role
in input and output for of a NET program, the central point of why NET Core was invented.
For if a console written in C# cannot run cross-platform,
what would be the point of using C# for other than Windows?

Unfortunately, the heart of a C# console program does not even function as you would expect. In the following simple programs, I write from
one using WriteLine() and read from the other using ReadLine(). The two programs are connected using a pipe in a shell, i.e.,
`w.exe | r.exe`. The program `r.exe` should wait for the writer finish, then return the input until the end of file in the pipe. But, it doesn't:
the call to ReadLine() returns immediately with `null`.

According to the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) ReadLine() should wait on input,
or be "blocking". But, it is not.

Here is a screen shot of program "r" returning an empty result, when it is clear, "w" has written data.

![To err is human, but not for computer](Screenshot%20(27).png)

On Linux, the ReadLine() works. When I use another non-C# program inbetween the two
C# programs, e.g., `./w/bin/Debug/net5.0/w.exe 2 | sed 's/ / /' | ./r/bin/Debug/net5.0/r.exe`,
the ReadLine() gets data.

If ReadLine() is blocking, why did the method return without data? If it's non-blocking, how do I know when to stop trying to read the pipe?
