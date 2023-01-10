namespace DefaultNamespace
{
    public record Card
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsCounter { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
    }
}