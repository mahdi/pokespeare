using Pokespeare.Api.Helpers;
using Xunit;

namespace Pokespeare.Api.Tests {
    public class HelpersTests {
        [Theory]
        [InlineData(new object[] { new[] {"\r", "\\r", "\n", "\\n", "\f", "\\f", "\t", "\\t"} })]
        public void Does_Clean_Text_Remove_Control_Characters(string[] characterControls) {
            // Arrange                                                 
            const string input = "Spits fire that\\nis hot enough to\\nmelt boulders.\\fKnown to cause\\nforest fires\\nunintentionally.";

            // Act
            var output = input.CleanText();

            // Assert
            Assert.NotNull(output);
            foreach (var control in characterControls)
            {
                Assert.DoesNotContain(control, output);
            }
        }
    }
}