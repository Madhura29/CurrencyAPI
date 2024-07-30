namespace CurrencyAPI.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public required string From_Currency { get; set; }

        public required string To_Currency { get; set; }

        public required double Rate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
