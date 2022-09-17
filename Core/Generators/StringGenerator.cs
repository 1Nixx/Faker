using Core.Data;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
	internal class StringGenerator : IValueGenerator
	{
		private static char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
		public bool CanGenerate(Type type)
		{
			return type == typeof(string);
		}

		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			var stringLength = context.Random.Next(5, 100);
			var builder = new StringBuilder();

			for (int i = 0; i < stringLength; i++)
				builder.Append(chars[context.Random.Next(chars.Length)]);

			return builder.ToString();
		}
	}
}
