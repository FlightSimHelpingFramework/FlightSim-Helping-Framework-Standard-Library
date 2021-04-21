// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ------------------------------------------------------------------------------------------------------

#region Usings

using System;
using System.Collections.Generic;
using FluentAssertions;
using FSHFStandardLibrary.Core.Json;
using FSHFTestingHelper.IcaoCodes;
using FSHFTestingHelper.Strings;
using NUnit.Framework;

#endregion

namespace FSHFStandardLibrary.UnitTests.Tests.Json
{
    #region Data preparation (class)

    internal class SampleClassData
    {
        public string icao { get; set; }
        public string metar { get; set; }
        public string name { get; set; }
        public string taf { get; set; }
    }

    #endregion

    [Category("Unit")]
    [TestFixture]
    public class DeserializationTests
    {
        public static IEnumerable<object[]> ValidDataForCreatingSampleClassData
        {
            get
            {
                List<object[]> result = new List<object[]>();

                foreach (string icaoCode in IcaoCodes.ValidStringIcaoCodesCollection)
                {
                    foreach (object validString in Strings.ValidStrings)
                    {
                        result.Add(new object[]
                        {
                            icaoCode, $"Airport with icao {icaoCode}!", $"METAR {validString}", $"TAF {validString}"
                        });
                    }
                }

                return result;
            }
        }

        [TestCaseSource(typeof(DeserializationTests), nameof(ValidDataForCreatingSampleClassData))]
        public void Deserialize_WithCorrectJsonString_ShouldWork(string icao, string name, string metar, string taf)
        {
            //Arrange & act
            SampleClassData data = Deserialization.Deserialize<SampleClassData>(
                "{\"icao\":\"" + icao + "\",\"name\":\"" + name + "\",\"metar\":\"" + metar + "\",\"taf\":\"" + taf +
                "\"}");

            //Assert
            data.Should().BeEquivalentTo(new SampleClassData {icao = icao, name = name, metar = metar, taf = taf});
        }

        [Test]
        public void Deserialize_WithNullArgument_ShouldThrow_ArgumentNullException()
        {
            //Arrange
            Action act = () => Deserialization.Deserialize<object>(null);

            //Act & assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}