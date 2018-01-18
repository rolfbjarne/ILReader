using System;

namespace Xamarin
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			foreach (var type in typeof (int).Assembly.GetTypes ()) {
				foreach (var method in type.GetMethods ()) {
					var body = method.GetMethodBody ();
					if (body == null)
						continue;
					var il = body.GetILAsByteArray ();
					Console.WriteLine ("{0}.{1}", method.DeclaringType.FullName, method.Name);
					var reader = new ILReader (method);
					foreach (var instr in reader) {
						var str = instr.ToString ();
						Console.WriteLine ("    {0}", instr);
					}
				}
			}
		}
	}
}
