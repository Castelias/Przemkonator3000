namespace Przemkonator3000
{
    internal class Login
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
