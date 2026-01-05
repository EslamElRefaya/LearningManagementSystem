namespace LearningManagementSystem.Domain.ValueObjects
{
    public sealed class Email
    {
        public string Value { get; }
        private Email()
        { 
        } 
        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email is required");

            if (!value.Contains("@"))
                throw new ArgumentException("Invalid email format");

            Value = value.ToLower();
        }

        public override string ToString() => Value;
    }
}
