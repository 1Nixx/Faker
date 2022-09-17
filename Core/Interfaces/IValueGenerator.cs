using Core.Data;

namespace Core.Interfaces
{
	public interface IValueGenerator
	{
		object Generate(Type typeToGenerate, GeneratorContext context);

		bool CanGenerate(Type type);
	}
}
