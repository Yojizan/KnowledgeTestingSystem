namespace BLL.Infrastructure
{
    public class CreationDetails
    {
        public bool Succeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }

        public CreationDetails(bool succedeed, string message, string property)
        {
            Succeded = succedeed;
            Message = message;
            Property = property;
        }
    }
}
