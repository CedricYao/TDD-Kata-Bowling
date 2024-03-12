using FluentAssertions;
using Xunit;

namespace TddKata.Tests
{
  
    public class Given_a_full_game_without_strikes_when_scoring
    {
        [Theory]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        [InlineData("5- 5- 5- 5- 5- 5- 5- 5- 5- 5-", 50)]
        [InlineData("5- 5- 5- 5- 5- 5- 5- 5- 5- 6-", 51)]
        [InlineData("-- -- -- -- -- -- -- -- -- --", 0)]
        [InlineData("-5 -- -- -- -- -- -- -- -- --", 5)]
        [InlineData("45 -- -- -- -- -- -- -- -- --", 9)]
        [InlineData("4/ -- -- -- -- -- -- -- -- --", 10)]
        [InlineData("4/ -- 5- -- -- -- -- -- -- --", 15)]
        [InlineData("4/ 5- -- -- -- -- -- -- -- --", 20)]
        [InlineData("5/ 5/ -- -- -- -- -- -- -- --", 25)]
        public void Should_return_expected_score(string game, int expected_score)
        {
            var scoringCalculator = new ScoringCalculator();

            var result = scoringCalculator.Score(game);
            result.Should().Be(expected_score);
        }
    }
}