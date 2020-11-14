using Pokespeare.Api.Helpers;
using Xunit;

namespace Pokespeare.Api.Tests {
    public class HelpersTests {
        [Theory]
        [InlineData(new string[] { "\r", "\\r", "\n", "\\n", "\f", "\\f", "\t", "\\t" },
            "Spits fire that\\nis hot enough to\\ nmelt boulders.\\fKnown to cause\\ nforest fires\\ nunintentionally.")]
        [InlineData(new string[] { "\r", "\\r", "\n", "\\n", "\f", "\\f", "\t", "\\t" },
            "")]
        [InlineData(new string[] { "\r", "\\r", "\n", "\\n", "\f", "\\f", "\t", "\\t" },
            null)]
        public void Does_Clean_Text_Remove_Control_Characters(string[] characterControls, string input) {
            // Act
            var output = input.CleanText();

            // Assert
            foreach (var control in characterControls) {
                Assert.DoesNotContain(control, output);
            }
        }
    }
}