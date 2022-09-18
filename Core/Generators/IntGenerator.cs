using Core.Data;
using Core.Interfaces;

namespace Core.Generators
{
	internal class IntGenerator : IValueGenerator
	{
		public bool CanGenerate(Type type)
		{
			return type == typeof(int);
		}

		public object Generate(Type typeToGenerate, GeneratorContext context)
		{
			return context.Random.Next(1, int.MaxValue);
		}
	}
}
