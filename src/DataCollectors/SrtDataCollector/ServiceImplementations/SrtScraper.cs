using System.Text;

namespace SrtDataCollector.ServiceImplementations
{
    public class SrtScraper
    {
        public SrtScraper()
        {
            
        }
        public string ScrapeSrtText(string content)
        {
            // Split content into subtitle blocks
            var blocks = content.Split(new[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.None);

            StringBuilder extractedText = new StringBuilder();

            foreach (var block in blocks)
            {
                // Each block is separated by empty lines; process non-empty blocks
                if (!string.IsNullOrWhiteSpace(block))
                {
                    // Each block might contain multiple lines, split by new lines
                    var lines = block.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                    // Skip the index and timecode lines
                    if (lines.Length > 2)
                    {
                        for (int i = 2; i < lines.Length; i++)
                        {
                            extractedText.AppendLine(lines[i].Trim());
                        }
                    }
                }
            }

            return extractedText.ToString();
        }
    }
}
