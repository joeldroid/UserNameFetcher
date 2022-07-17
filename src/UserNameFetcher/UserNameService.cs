namespace UserNameFetcher
{
    internal class UserNameService : IUserNameService
    {
        private readonly IDictionary<int, string> _userNames;

        public UserNameService()
        {
            _userNames = new Dictionary<int, string>
            {
                {1, "John"}, {2, "Mary"}, {3, "Peter"}
            };
        }

        public string GetUserName(int userId)
        {
            return _userNames.FirstOrDefault(x => x.Key == userId).Value;
        }
    }
}
