using Core.Data;
using Core.Interfaces;

namespace Core.Generators
{
	internal class DoubleGenerator : IValueGenerator
	{
		public bool CanGenerate(Type type)
		{
			return type == typeof(double);
		}

		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return context.Random.NextDouble();
		}
	}
}
