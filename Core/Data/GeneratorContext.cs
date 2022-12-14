using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
	public class GeneratorContext
	{
		public Random Random { get; }

		public IFaker Faker { get; }

		public GeneratorContext(Random random, IFaker faker)
		{
			Random = random;
			Faker = faker;
		}
	}
}
