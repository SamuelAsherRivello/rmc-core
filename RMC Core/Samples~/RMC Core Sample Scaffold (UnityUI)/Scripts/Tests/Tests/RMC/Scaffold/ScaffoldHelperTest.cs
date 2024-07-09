
using NUnit.Framework;

namespace RMC.Core.Samples.Scaffold
{
    public class ScaffoldHelperTest
    {
        [Test]
        public void FormatWithCapitalStarting_ResultIsUpper_WhenInputIsLower()
        {
            // Arrange
            string message = "hello world!";
            
            // Act
            string result = ScaffoldHelper.FormatWithCapitalStarting(message);

            // Assert
            Assert.That(result, Is.EqualTo("Hello world!"));
        }

    }
}
