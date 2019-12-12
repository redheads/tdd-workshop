namespace Playground.Domain
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; } = 0;

        public bool IsValid() =>
            !string.IsNullOrWhiteSpace(FirstName)
            && !string.IsNullOrWhiteSpace(LastName);
    }
}