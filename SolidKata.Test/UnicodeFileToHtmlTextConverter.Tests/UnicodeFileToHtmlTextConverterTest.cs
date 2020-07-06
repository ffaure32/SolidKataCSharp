
using System.IO;
using Xunit;
namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class HikerTest
    {
        [Fact]
        public void foobar()
        {
            TextReader tr = new StringReader("toto");
            UnicodeFileToHtmlTextConverter converter = new UnicodeFileToHtmlTextConverter(tr);
            Assert.Equal("toto<br />", converter.ConvertToHtml());
        }
    }
}
