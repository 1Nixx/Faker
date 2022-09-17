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
			throw new NotImplementedException();
		}

		
	}
}
