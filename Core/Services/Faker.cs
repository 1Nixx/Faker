using Core.Data;
using Core.Helpers;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	public class Faker : IFaker
	{
		private readonly GeneratorContext _generatorContext;
		private readonly List<IValueGenerator> _valueGenerators;
		private readonly IDependencyChecker _cycleDependencyChecker;

		public Faker()
		{
			_generatorContext = new GeneratorContext(
				new Random((int)DateTime.Now.Ticks & 0x0000FFFF),
				this
			);

			_cycleDependencyChecker = new CycleDependencyChecker();
			_valueGenerators = GetAllGeneratorsFromAssembly();
		}

		private static List<IValueGenerator> GetAllGeneratorsFromAssembly()
		{
			var generatorsList = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(t => t.GetInterfaces().Contains(typeof(IValueGenerator)) && t.IsClass)
				.Select(t => (IValueGenerator)Activator.CreateInstance(t)).ToList();
			return generatorsList;
		}

		public T Create<T>()
		{
			return (T)CreateInstance(typeof(T));
		}

		public object Create(Type type)
		{
			return CreateInstance(type);
		}

		private object CreateInstance(Type type)
		{
			if (_cycleDependencyChecker.IsOverflowing())
				throw new InvalidOperationException();

			foreach (var generator in _valueGenerators)
			{
				if (generator.CanGenerate(type))
					return generator.Generate(type, _generatorContext);
			}

			var creatorService = new ObjectCreatorService(this);
			var initializeService = new ObjectInitService(this);

			_cycleDependencyChecker.AddDependency(type);

			var rowObject = creatorService.CreateObject(type);

			initializeService.InitFields(rowObject, type);
			initializeService.InitProps(rowObject, type);

			_cycleDependencyChecker.RemoveDependency(type);

			return rowObject;
		}

		
	}
}
