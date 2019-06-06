using FluentAssertions;
using Xunit;

namespace TddKata.Tests
{
    public class Given_an_empty_game_when_scoring
    {
        [Fact]
        public void Should_Return_0()
        {
            var scorer = new ScoringCalculator();
            var result = scorer.Score("");
            result.Should().Be(0);
        }
    }
}
