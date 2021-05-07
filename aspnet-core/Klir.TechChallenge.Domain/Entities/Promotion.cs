namespace Klir.TechChallenge.Domain.Entities
{
    public class Promotion
    {
        public int Id { get; }
        public string Description { get; }

        public Promotion(int id, string description)
        {
            Id = id;
            Description = description;  
        }
    }
}
