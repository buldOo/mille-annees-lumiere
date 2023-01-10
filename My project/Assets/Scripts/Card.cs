namespace DefaultNamespace
{
    public record Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsCounter { get; set; }
    }
}