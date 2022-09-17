using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	internal interface IObjectInitService
	{
		void InitFields(object obj, Type objectType);
		void InitProps(object obj, Type objectType);
	}
}
