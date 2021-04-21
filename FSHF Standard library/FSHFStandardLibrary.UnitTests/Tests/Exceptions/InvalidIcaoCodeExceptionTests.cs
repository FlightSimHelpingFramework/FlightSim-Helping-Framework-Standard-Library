// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using FluentAssertions;
using FSHFStandardLibrary.Core.Exceptions;
using FSHFTestingHelper.Strings;
using NUnit.Framework;

#endregion

namespace FSHFStandardLibrary.UnitTests.Tests.Exceptions
{
    [Category("Unit")]
    [TestFixture]
    public class InvalidIcaoCodeExceptionTests
    {
        [TestCaseSource(typeof(Strings), nameof(Strings.ValidStrings))]
        public void Constuctor_WithValidMessage_ShouldConstruct(string message)
        {
            //Arrange & act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException(message);

            //Assert
            ex.Message.Should().Be(message);
        }

        [TestCaseSource(typeof(Strings), nameof(Strings.ValidStrings))]
        public void
            Constuctor_WithValidMessageAndNullInnerException_ShouldConstructWithDefaultMessage(
                string message)
        {
            //Arrange & act
            InvalidIcaoCodeException ex =
                new InvalidIcaoCodeException(message, null);

            //Assert
            ex.InnerException.Should().BeNull();
        }

        [Test]
        public void Constuctor_WithNullMessage_ShouldConstructWithDefaultMessage()
        {
            //Arrange & act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException(null);

            //Assert
            ex.Message.Should().NotBeNull();
        }

        [Test]
        public void
            Constuctor_WithValidMessageAndInnerException_ShouldConstructWithDefaultMessage()
        {
            //Arrange & act
            InvalidIcaoCodeException ex =
                new InvalidIcaoCodeException("Message", new InvalidIcaoCodeException(nameof(ex)));

            //Assert
            nameof(ex).Should().Be(ex.InnerException.Message);
        }

        [Test]
        public void DefaultConstuctor_ShouldConstruct()
        {
            //Arrange & act
            InvalidIcaoCodeException ex = new InvalidIcaoCodeException();

            //Assert
            ex.Should().NotBeNull();
        }
    }
}