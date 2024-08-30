namespace SrtDataCollector.Models
{

    public record SrtTextModel
    {
        public required SrtSource SrtSource { get; set; }

        public string Text { get; set; } = string.Empty;
        public int Season { get; set; } = 0;
        public int Episode { get; set; } = 0;
    }
}
