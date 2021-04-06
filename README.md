# ReadLine-Is-Nonblocking
Why doesn't ReadLine() block consistently with pipes in Cygwin? Apparently, it does not
even though it says in the [documentation](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline?view=net-5.0) that it is.

In Msys2, here is a screen shot of ReadLine() breaking on reading output.


