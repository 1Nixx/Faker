using Core.Data;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
	internal class DateTimeGenerator : IValueGenerator
	{
		public bool CanGenerate(Type type)
		{
			return type == typeof(DateTime);
		}

		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return new DateTime(
				year: context.Random.Next(1, 3000),
				month: context.Random.Next(1, 12),
				day: context.Random.Next(1, 28),
				hour: context.Random.Next(0, 23),
				minute: context.Random.Next(0, 59),
				second: context.Random.Next(0, 59),
				millisecond: context.Random.Next(0, 999)
			);
		}
	}
}
