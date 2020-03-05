using System;
using Xunit;
using FluentAssertions;
using Iti.BackendChallenge.WebAPI.UseCases;

namespace Iti.BackendChallenge.Tests.Unit.WebAPI.UseCases
{
    public class ValidateStrongPasswordTests
    {
        private readonly ValidateStrongPassword validateStrongPassword;

        public ValidateStrongPasswordTests()
        {
            validateStrongPassword = new ValidateStrongPassword();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueIsNull()
        {
            bool result = validateStrongPassword.IsValid(null);
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueLessThenNineCharacters()
        {
            bool result = validateStrongPassword.IsValid("AbTp9!fo");
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueNotContainDigit()
        {
            bool result = validateStrongPassword.IsValid("Ab#p!food");
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueNotContainLowerCase()
        {
            bool result = validateStrongPassword.IsValid("A2TP!FOOD");
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueNotContainUpperCase()
        {
            bool result = validateStrongPassword.IsValid("1btp!food");
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnFalseWhenValueNotContainSpecialCharacters()
        {
            bool result = validateStrongPassword.IsValid("AbTp1food");
            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnTrue()
        {
            bool result = validateStrongPassword.IsValid("AbTp9!foo");
            result.Should().BeTrue();
        }
    }
}
