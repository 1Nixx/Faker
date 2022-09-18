using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{


	public class A
	{
		public int x;
		public int field;
		public readonly int fieldRO;
		public int prop { get; set; }
		public  int propRO { get;  }
		public B b;

		public A(int x, B b)
		{
			this.x = x;
			this.b = b;
		}

		public A(int x)
		{
			this.x = x;
		}
	}

	public class B
	{
		public double x { get; set; }

		public B()
		{

		}

		public B(float x)
		{

		}
	}

	public class TestCtor
	{
		public int A { get; set; }
		public int B { get; set; }
		public int C { get; }
		public B BB { get; }
		public TestCtor()
		{

		}

		public TestCtor(int a, int b)
		{
			A = a;
			B = b;
		}

		private TestCtor(int a, int b, int c)
		{
			A = a;
			B = b;
			C = c;	
		}

		public TestCtor(int a, int b, int c, int d)
		{		
			A = a;
			B = b;
			C = c;
			throw new Exception();
		}
	}



	public class C
	{
		public C(D d)
		{
		}
	}

	public class D
	{
		public D(E e)
		{
		}
	}

	public class E
	{
		public E(F f)
		{
		}
	}

	public class F
	{
		public F(D d)
		{
		}
	}


	class A1
	{
		public B1 B { get; set; }
	}

	class B1
	{
		public C1 C { get; set; }
	}

	class C1
	{
		public A1  A { get; set; } 
	}
}
