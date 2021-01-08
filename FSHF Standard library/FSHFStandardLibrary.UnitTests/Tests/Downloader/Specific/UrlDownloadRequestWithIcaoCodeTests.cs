// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FluentAssertions;
using FSHFStandardLibrary.Core.Codes;
using FSHFStandardLibrary.Core.Downloader.Specific;
using FSHFTestingHelper.Downloader;
using NUnit.Framework;

#endregion

namespace FSHFStandardLibrary.UnitTests.Tests.Downloader.Specific
{
    [Category("Unit")]
    [TestFixture]
    public class UrlDownloadRequestWithIcaoCodeTests
    {
        [TestCaseSource(typeof(Urls), nameof(Urls.ValidUrlsCollection))]
        public void Constructor_WithValidParameters_ShouldConstruct(Uri url)
        {
            //Arrange
            IcaoCode expectedIcaoCode = new("UUEE");

            //Act
            UrlDownloadRequestWithIcaoCode request = new(url, expectedIcaoCode);

            //Assert
            request.Url.Should().Be(url);
            request.AirportIcaoCode.Should().Be(expectedIcaoCode);
        }

        [TestCaseSource(typeof(Urls), nameof(Urls.ValidUrlsCollection))]
        public void ToString_WithValidParameters_ShouldReturnCorrectString(Uri url)
        {
            //Arrange & act
            IcaoCode expectedIcaoCode = new("EDDF");
            UrlDownloadRequestWithIcaoCode request = new(url, expectedIcaoCode);
            string toStringRepresentation = request.ToString();

            //Assert
            toStringRepresentation.Should().Contain(url.ToString()).And.Contain(expectedIcaoCode.ToString());
        }

        [Test]
        public void Constructor_WithNullParameters_ShouldThrow_ArgumentNullException()
        {
            //Arrange
            Action act = () => new UrlDownloadRequestWithIcaoCode(null, null);

            //Act & assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}