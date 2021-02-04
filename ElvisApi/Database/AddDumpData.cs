using ElvisApi.Database.Entities;
namespace ElvisApi.Database
{
    public class AddDumpData
    {
        public static void AddTestData(PostgreSqlContext context)
        {
            for (int i = 1; i < 10; i++)
            {
                var testStatement1 = new Statement
                {
                    Id = i,
                    Description = "description " + i,
                    Img = "http://1 " + i,
                    Phone = $"{i}{i * 2}{i * 3}{i * 4}{i * 5}{i * 6}",
                    Title = "test" + i
                };

                context.Statement.Add(testStatement1);

            }

            context.SaveChanges();
        }
    }
}
