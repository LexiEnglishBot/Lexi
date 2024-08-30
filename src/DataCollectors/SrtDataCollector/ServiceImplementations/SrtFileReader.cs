using System.Text;

namespace SrtDataCollector.ServiceImplementations
{
    public class SrtFileReader
    {
        public SrtFileReader()
        {

        }
        public string ReadFromFile(string filePath)
        {
            string content = File.ReadAllText(filePath, Encoding.UTF8);
            return content;
        }

    }
}
