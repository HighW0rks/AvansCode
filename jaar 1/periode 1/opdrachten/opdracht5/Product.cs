namespace Opdracht5
{
    class Product
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public required string Naam { get; set; }
        public decimal Prijs { get; set; }
        public required string Beschrijving { get; set; }

        public Product()
        {
            Id = nextId++;
        }
    }
}

