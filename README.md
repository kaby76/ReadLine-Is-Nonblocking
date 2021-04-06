# ReadLine-Is-Nonblocking
Why doesn't ReadLine() block consistently with pipes in Cygwin? Apparently, it does not
even though it says in the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) that it is.

In Msys2, here is a screen shot of ReadLine() breaking on reading output.

![To err is human, but not for computer](Screenshot%20(27).png)

On Linux, the ReadLine() works. When I use another non-C# program inbetween the two
C# programs, e.g., `./w/bin/Debug/net5.0/w.exe 2 | sed 's/ / /' | ./r/bin/Debug/net5.0/r.exe`,
the ReadLine() gets data.

It's non-blocking, because if you then modify the program to perform a *second* ReadLine() call,
the second call will have data! BS!
