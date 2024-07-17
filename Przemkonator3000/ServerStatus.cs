
namespace Przemkonator3000
{
    public class ServerStatus
    {

        public string Name { get; set; }
        public string Status { get; set; }
        public string FirstStatus { get; set; }
        public string SecondStatus { get; set; }

        public ServerStatus(string name, string status, string firstStatus, string secondStatus)
        {
            Name = name;
            Status = status;
            FirstStatus = firstStatus;
            SecondStatus = secondStatus;
        }


    }
}
