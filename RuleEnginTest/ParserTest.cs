namespace RuleEnginTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RuleEngine;
    using System;
    using System.Collections.Generic;
    using System.IO;

    [TestClass]
    public class ParserTest
    {
        private static readonly string _inputData;
        static ParserTest()
        {
            _inputData = File.ReadAllText("raw_data.json");
        }

        [TestMethod]
        public void TestParserWithoutRule()
        {
            List<SignalData> expectedInvalidSignals = new List<SignalData>();

            var parser = new Parser();

            if (parser.TryParse(_inputData, out List<SignalData> actualValidSignals, out List<SignalData> actualInvalidSignals, false))
            {
                CollectionAssert.AreEqual(expectedInvalidSignals, actualInvalidSignals);
            }
            else
            {
                Assert.Fail("Unable to parse incoming data.");
            }
        }

        [TestMethod]
        public void TestParserWithRulesFromFile()
        {
            var expectedInvalidSignals = new List<SignalData>
            {
                new SignalData("ATL2", "LOW", "String"),
                new SignalData("ATL2", "LOW", "String"),
                new SignalData("ATL2", "LOW", "String"),
                new SignalData("ATL2", "LOW", "String")
            };

            var rules = Rule.GetRules();

            var parser = new Parser();
            if (parser.TryParse(_inputData, out List<SignalData> actualValidSignals, out List<SignalData> actualInvalidSignals, false, rules))
            {
                CollectionAssert.AreEqual(expectedInvalidSignals, actualInvalidSignals);
            }
            else
            {
                Assert.Fail("Unable to parse incoming data.");
            }
        }

        [TestMethod]
        public void TestParserWithCustomRules()
        {
            var expectedInvalidSignals = new List<SignalData>
            {
                new SignalData("ATL9", "2017-06-13 22:40:10", "Datetime"),
                new SignalData("ATL3", "LOW", "String"),
                new SignalData("ATL10", "2017-07-26 16:35:11", "Datetime"),
                new SignalData("ATL9", "2017-01-10 01:13:47", "Datetime"),
                new SignalData("ATL7", "LOW", "String"),
                new SignalData("ATL10", "2017-08-02 05:20:21", "Datetime"),
                new SignalData("ATL9", "2017-05-29 14:58:42", "Datetime"),
                new SignalData("ATL10", "2017-09-22 03:24:18", "Datetime"),
                new SignalData("ATL3", "LOW", "String"),
                new SignalData("ATL7", "LOW", "String"),
                new SignalData("ATL9", "2017-05-27 15:55:49", "Datetime"),
                new SignalData("ATL7", "LOW", "String"),
                new SignalData("ATL9", "2017-03-05 03:39:40", "Datetime"),
                new SignalData("ATL3", "LOW", "String"),
                new SignalData("ATL3", "LOW", "String"),
                new SignalData("ATL3", "LOW", "String")
            };

            var rules = new List<Rule>
            {
                new Rule("ATL9", new DateTime(2017, 6, 14), Comparison.LessThan),
                new Rule("ATL3", "LOW", Comparison.Equal),
                new Rule("ATL10", new DateTime(2017, 7, 15), Comparison.GreaterThan),
                new Rule("ATL7", "HIGH", Comparison.NotEqual)
            }.ToArray();

            var parser = new Parser();
            if (parser.TryParse(_inputData, out List<SignalData> actualValidSignals, out List<SignalData> actualInvalidSignals, false, rules))
            {
                CollectionAssert.AreEqual(expectedInvalidSignals, actualInvalidSignals);
            }
            else
            {
                Assert.Fail("Unable to parse incoming data.");
            }
        }

        [TestMethod]
        public void TestParserOnFirstValidationFailureWithCustomRules()
        {
            var expectedInvalidSignals = new List<SignalData>
            {
                new SignalData("ATL7", "LOW", "String")
            };

            var rules = new List<Rule>
            {
                new Rule("ATL7", "HIGH", Comparison.NotEqual)
            }.ToArray();

            var parser = new Parser();
            if (parser.TryParse(_inputData, out List<SignalData> actualValidSignals, out List<SignalData> actualInvalidSignals, true, rules))
            {
                CollectionAssert.AreEqual(expectedInvalidSignals, actualInvalidSignals);
            }
            else
            {
                Assert.Fail("Unable to parse incoming data.");
            }
        }
    }
}
