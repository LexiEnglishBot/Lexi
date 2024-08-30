namespace SrtDataCollector.Models
{
    public record SrtSource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SrtSourceType Type { get; set; } = SrtSourceType.UnKnown;
    }
}
