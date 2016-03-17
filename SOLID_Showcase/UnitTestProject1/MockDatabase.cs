using Library.Base;

namespace UnitTestProject1
{
    public class  MockDatabase : IDatabase
    {
        public string ExecuteQuery()
        {
            return "dummy";
        }
    }
}