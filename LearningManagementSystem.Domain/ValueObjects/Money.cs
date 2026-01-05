namespace LearningManagementSystem.Domain.ValueObjects
{
    public sealed class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() { }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency is required");

            Amount = amount;
            Currency = currency;
        }
    }

}