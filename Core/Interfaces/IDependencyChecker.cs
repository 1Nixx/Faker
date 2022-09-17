using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Core.Interfaces
{
	internal interface IDependencyChecker
	{
		void AddDependency(Type type);
		void RemoveDependency(Type type);
		bool IsOverflowing();
	}
}
