namespace Domain.Entities
{
    public class FullName
    {
        public string FirstName { get; }
        public string LastName { get; }

        private FullName() { } 

        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }

}
