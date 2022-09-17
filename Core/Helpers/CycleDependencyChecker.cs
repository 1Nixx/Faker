using Core.Interfaces;
using System.ComponentModel;

namespace Core.Helpers
{
    internal class CycleDependencyChecker : IDependencyChecker
    {
		private readonly int _nestingLimit = 5;

		private Stack<Type> _createdTypesHolder;

		public CycleDependencyChecker()
		{
			_createdTypesHolder = new();
		}

		public CycleDependencyChecker(int nestingLimit) : this()
		{
			_nestingLimit = nestingLimit;
		}

		public void AddDependency(Type type)
		{
			_createdTypesHolder.Push(type);
		}

		public void RemoveDependency(Type type)
		{
			_createdTypesHolder.Pop();
		}

		public bool IsOverflowing()
		{
			return _createdTypesHolder.GroupBy(t => t.FullName)
				.Select(c => new
				{
					typeAmount = c.Count()
				}).Where(b => b.typeAmount >= _nestingLimit)
				.Count() > 0;
		}
	}
}