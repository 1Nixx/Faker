

using Core.Services;



var faker = new Faker();

var fakerName = faker.Create<B>();

Console.WriteLine();


class User
{
	//public string Name { get; set; }
	public TimeSpan Age { get; set; }
	public B a;
}

class B
{
	public int A { get; set; }
	public char C { get; set; }

	public User User { get; set; }

	public readonly int ff;

	public B()
	{
		A = 1;
		C = 'a';
	}

	private B(int a, char c, int F)
	{
		A = a;
		C = c;
	}

	public B(int a, char c)
	{
		A = a;
		C = c;
	}

	
}