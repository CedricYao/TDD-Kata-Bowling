using FluentAssertions;
using Xunit;

namespace TddKata.Tests
{
    public class ScoringCalculatorV1Tester
    {
        private ScoreCalculatorV1 _scoreCalculatorV1 =null;
        public ScoringCalculatorV1Tester()
        {
            _scoreCalculatorV1 = new ScoreCalculatorV1();
        }

        [Fact]
        public void should_return_zero()
        {
            var result = _scoreCalculatorV1.CalculateScore();

            result.Should().Be(0);
        }

        [Fact]
        public void roll_one_returns_one()
        {
            var roll = 1;

            var result = _scoreCalculatorV1.CalculateScore(roll);

            result.Should().Be(1);
        }

        [Fact]
        public void two_rolls_returns_sum()
        {
            var roll1 = 1;
            var roll2 = 2;

            var result = _scoreCalculatorV1.CalculateScore(roll1, roll2);
            
            result.Should().Be(3);
        }
    }
}