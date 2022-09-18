using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	internal class ObjectCreatorService : IObjectCreatorService
	{
		private readonly IFaker _faker;
		public ObjectCreatorService(IFaker faker)
		{
			_faker = faker;
		}

		public object CreateObject(Type type)
		{
			var typeConstructors = type.GetConstructors()
				.OrderByDescending(c => c.GetParameters().Length)
				.ToList();

			foreach (var ctor in typeConstructors)
			{
				try
				{
					var parameters = ctor.GetParameters()
						.Select(t => t.ParameterType)
						.Select(_faker.Create).ToArray();

					return ctor.Invoke(parameters);
				}
				catch
				{}
			}

			throw new Exception();
		}
	}
}
