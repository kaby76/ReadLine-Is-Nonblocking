using System;
using System.Collections.Generic;
using CommandLine;

namespace w
{
	public class Config
	{
		[Option("version", Required = false)]
		public bool? Version { get; set; }

		[Value(1)]
		public IEnumerable<int> Times { get; set; }

		[Option("type", Required = false)]
		public string? Type { get; set; }
	}

    class Program
    {
		static void Main(string[] args)
		{
			int count = 1;
			var result = Parser.Default.ParseArguments<Config>(args)
			.WithParsed(options =>
			{
				if (options.Times != null)
				{
					var i = options.Times.GetEnumerator();
					if (i.MoveNext()) count = i.Current;
				}
			}
			)
			.WithNotParsed(errors =>
			{
			});

			System.Console.Error.WriteLine("Parse completed of C:\\Users\\kenne\\Documents\\AntlrVSIX\\test\\A.g4");
			for (int j = 0; j < count; ++j)
			{
				var s = @"{
  ""FileName"": ""C:\\Users\\kenne\\Documents\\AntlrVSIX\\test\\A.g4""
}";
				System.Console.Write(s);
			}
		}
    }
}
