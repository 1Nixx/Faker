using Core.Interfaces;
using Core.Services;
using System.Collections;

namespace Tests
{
	public class Tests
	{
		private IFaker _faker;

		[SetUp]
		public void Setup()
		{
			_faker = new Faker();
		}

		[Test]
		[TestCase(typeof(int))]
		[TestCase(typeof(double))]
		[TestCase(typeof(char))]
		[TestCase(typeof(string))]
		[TestCase(typeof(float))]
		[TestCase(typeof(long))]
		[TestCase(typeof(DateTime))]
		public void CreateObject_PrimitiveTypes_DoesNotThrow(Type t)
		{
			Assert.DoesNotThrow(() => _faker.Create(t));
		}

		[Test]
		[TestCase(typeof(List<int>))]
		[TestCase(typeof(List<double>))]
		[TestCase(typeof(List<char>))]
		[TestCase(typeof(List<string>))]
		[TestCase(typeof(List<float>))]
		[TestCase(typeof(List<long>))]
		public void CreateObject_List_DoesNotThrow(Type t)
		{
			Assert.DoesNotThrow(() => _faker.Create(t));
			Assert.IsNotEmpty((IList)_faker.Create(t));
		}

		[Test]
		[TestCase(typeof(IEnumerable<int>))]
		public void CreateObject_IEnumerable_Throw(Type t)
		{
			Assert.Throws(typeof(Exception), () => _faker.Create(t));
		}

		[Test]
		[TestCase(typeof(short))]
		[TestCase(typeof(byte))]
		[TestCase(typeof(bool))]
		[TestCase(typeof(uint))]
		public void CreateObject_UnSetPrimitiveTypes_Throw(Type t)
		{
			Assert.Throws(typeof(Exception), () => _faker.Create(t));
		}

		[Test]
		public void CreateObject_AllTypesOfFields()
		{
			var obj = _faker.Create<A>();

			Assert.Multiple(() =>
			{
				Assert.NotZero(obj.x);
				Assert.NotZero(obj.field);
				Assert.Zero(obj.fieldRO);
				Assert.NotZero(obj.prop);
				Assert.Zero(obj.propRO);
				Assert.NotNull(obj.b);
				Assert.NotZero(obj.b.x);
			});
		}

		[Test]
		public void CreateObject_TestCtors()
		{
			var obj = _faker.Create<TestCtor>();

			Assert.Multiple(() =>
			{
				Assert.NotZero(obj.A);
				Assert.NotZero(obj.B);
				Assert.Zero(obj.C);
				Assert.Null(obj.BB);
			});
		}
		
		[Test]
		public void CreateObject_TestCycleDependency_Throw()
		{
			Assert.Throws<Exception>(() => _faker.Create<C>());
		}

		[Test]
		public void CreateObject_TestCycleDependency_Limit_DoesNotThrow()
		{


			Assert.DoesNotThrow(() =>
			{
				var obj = _faker.Create<A1>();

				Assert.NotNull(obj.B);
			});
		}
	}
}