using Core.Data;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Generators
{
	internal class CharGeneratror : IValueGenerator
	{
		private static char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

		public bool CanGenerate(Type type)
		{
			return type == typeof(char);
		}
		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return chars[context.Random.Next(chars.Length)];
		}
	}
}
