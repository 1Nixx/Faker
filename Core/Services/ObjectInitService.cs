using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
	internal class ObjectInitService : IObjectInitService
	{
		private readonly IFaker _faker;
		public ObjectInitService(IFaker faker)
		{
			_faker = faker;
		}

		public void InitFields(object obj, Type objectType)
		{
			var fields = objectType.GetFields().Where(f => !f.IsInitOnly);

			foreach (var field in fields)
			{
				try
				{
					if (Equals(field.GetValue(obj), GetDefaultValue(field.FieldType)))
						field.SetValue(obj, _faker.Create(field.FieldType));
				}
				catch { }
			}
		}

		public void InitProps(object obj, Type objectType)
		{
			var props = objectType.GetProperties().Where(p => p.CanWrite);

			foreach (var prop in props)
			{
				try
				{
					if (Equals(prop.GetValue(obj), GetDefaultValue(prop.PropertyType)))
						prop.SetValue(obj, _faker.Create(prop.PropertyType));
				}
				catch { }
			}
		}


		private object? GetDefaultValue(Type objType)
		{
			return objType.IsValueType ? Activator.CreateInstance(objType) : null;
		}
	}
}
