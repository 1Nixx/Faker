using Core.Data;
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

		public Faker()
		{
			_generatorContext = new GeneratorContext(
				new Random((int)DateTime.Now.Ticks & 0x0000FFFF),
				this
			);

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
			return (T)Create(typeof(T));
		}

		object IFaker.Create(Type type)
		{
			return Create(type);
		}

		private object Create(Type type)
		{
			foreach (var generator in _valueGenerators)
			{
				if (generator.CanGenerate(type))
					return generator.Generate(type, _generatorContext);
			}

			var creatorService = new ObjectCreatorService(this);
			var initializeService = new ObjectInitService(this);

			var rowObject = creatorService.CreateObject(type);

			initializeService.InitFields(rowObject, type);
			initializeService.InitProps(rowObject, type);

			return rowObject;
		}

		
	}
}
