using SrtDataCollector.Models;
using FluentResults;
namespace SrtDataCollector.ServiceImplementations
{
    public class SrtManager
    {
        private readonly SrtFileReader _srtFileReader;
        private readonly SrtScraper _srtScraper;
        private readonly ILogger<SrtManager> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SrtManager(SrtFileReader srtFileReader, SrtScraper srtScraper, ILogger<SrtManager> logger, IWebHostEnvironment webHostEnvironment)
        {
            this._srtFileReader = srtFileReader;
            _srtScraper = srtScraper;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public Result<SrtTextModel> PrepareSeriesSrtTextModel(SrtSource srtSource, int season, int episode)
        {
            string folderPath = $"{_webHostEnvironment.WebRootPath}/SrtSources/Series/{srtSource.Name}/S{season:00}/english";
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                if (fileName.Equals(episode.ToString("00")+".srt", StringComparison.OrdinalIgnoreCase))
                {
                    string content = _srtFileReader.ReadFromFile(folderPath + "/" + fileName);
                    var scrapedText = _srtScraper.ScrapeSrtText(content);
                    var ans = new SrtTextModel { SrtSource = srtSource, Episode = episode, Season = season, Text = scrapedText };
                    _logger.LogDebug("scraped text is {0}", scrapedText);
                    return ans;
                }
            }
            return Result.Fail("not found !");
        }
    }
}
