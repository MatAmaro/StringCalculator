using FluentAssertions;
using System;
using Xunit;

namespace StringCalculator.UnitTests
{
    public class UnitTest1
    {
        private Domain.StringCalculator sut;
        public UnitTest1()
        {
            sut = new Domain.StringCalculator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]

        public void Add_WhenEmptyOrNullOrWhiteSpaceString_ShouldReturnZero(string input)
        {
            var result = sut.Add(input);

            result.Should().Be(0);

        }

        [Fact]
        public void Add_WhenMoreThenTwoNumbers_ShouldThrowException()
        {

            Action add = () => sut.Add("1,2,3");

            add.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(",,")]
        [InlineData("1,,2")]
        [InlineData(",,1")]
        public void Add_WhenConsecutiveCommas_ShouldThrowArgumentException(string input)
        {
            Action add = () => sut.Add(input);

            add.Should().Throw<ArgumentException>();

        }

        [Theory]
        [InlineData("a,1")]
        [InlineData("a,a")]
        [InlineData("A,2")]
        [InlineData(" ,c")]

        public void Add_WhenNonNumbers_ShouldThrowArgumentException(string input)
        {
            Action add = () => sut.Add(input);

            add.Should().Throw<ArgumentException>();

        }

        [Theory]
        [InlineData("1,2",3)]
        [InlineData("2,4",6)]
        [InlineData("16,14",30)]
        [InlineData("8,1",9)]
        public void Add_WhenValidNumbers_ShouldReturnExpected(string input, int expected)
        {
            var result = sut.Add(input);

            result.Should().Be(expected);
        }

    }
}