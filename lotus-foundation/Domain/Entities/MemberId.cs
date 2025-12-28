namespace Domain.Entities
{
    public readonly struct MemberId
    {
        public Guid Value { get; }

        private MemberId(Guid value)
        {
            Value = value;
        }

        public static MemberId New() => new(Guid.NewGuid());

        public static MemberId From(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("MemberId cannot be empty");

            return new MemberId(value);
        }

        public override string ToString() => Value.ToString();
    }

}
