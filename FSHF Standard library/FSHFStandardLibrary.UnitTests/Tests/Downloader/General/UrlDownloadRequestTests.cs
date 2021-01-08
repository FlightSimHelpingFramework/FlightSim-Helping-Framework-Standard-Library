// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using FluentAssertions;
using FSHFStandardLibrary.Core.Downloader.General;
using FSHFTestingHelper.Downloader;
using NUnit.Framework;

#endregion

namespace FSHFStandardLibrary.UnitTests.Tests.Downloader.General
{
    [Category("Unit")]
    [TestFixture]
    public class UrlDownloadRequestTests
    {
        [TestCaseSource(typeof(Urls), nameof(Urls.ValidUrlsCollection))]
        public void Constructor_WithValidParameters_ShouldConstruct(Uri url)
        {
            //Arrange & act
            UrlDownloadRequest request = new(url);

            //Assert
            request.Url.Should().Be(url);
        }

        [TestCaseSource(typeof(Urls), nameof(Urls.ValidUrlsCollection))]
        public void ToString_WithValidParameters_ShouldReturnCorrectString(Uri url)
        {
            //Arrange & act
            UrlDownloadRequest request = new(url);
            string toStringRepresentation = request.ToString();

            //Assert
            toStringRepresentation.Should().Contain(url.ToString());
        }

        [Test]
        public void Constructor_WithNullParameter_ShouldThrow_ArgumentNullException()
        {
            //Arrange
            Action act = () => new UrlDownloadRequest(null);

            //Act & assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}