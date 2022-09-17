

using Core.Services;



var faker = new Faker();

var fakerName = faker.Create<List<string>>();

foreach (var item in fakerName)
{
	Console.WriteLine(item);
}