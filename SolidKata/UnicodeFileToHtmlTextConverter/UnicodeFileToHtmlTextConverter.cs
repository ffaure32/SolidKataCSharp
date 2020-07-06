using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        private string _fullFilenameWithPath;

        private TextReader _textReader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
            _textReader = File.OpenText(_fullFilenameWithPath);
        }

        public UnicodeFileToHtmlTextConverter(TextReader textReader)
        {
            _fullFilenameWithPath = string.Empty;
            _textReader = textReader;
        }
        public string GetFilename()
        {
            return _fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _textReader)
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
    class HttpUtility
    {
        public static string HtmlEncode(string line)
        {
            line = line.Replace("<", "&lt;");
            line = line.Replace(">", "&gt;");
            line = line.Replace("&", "&amp;");
            line = line.Replace("\"", "&quot;");
            line = line.Replace("\'", "&quot;");
            return line;
        }
    }
}
