using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Information.Language.External;
using Sentient.Information.Language.Helpers;
using Sentient.Information.Language.Signal;
using Sentient.Resources.Abstracts.External;
using System.Configuration;

namespace Sentient.Test.Information
{
    [TestClass]
    public class CollectorTest
    {

        private ACollector Collector;
        private Parameters Parameters;

        public CollectorTest()
        {
            Collector = new Collector();
            string oxfordEntriesRoute = ConfigurationManager.AppSettings["OxfordApi.Entries"];
            this.Parameters = ParameterGenerator.GenerateParameters("hello", oxfordEntriesRoute);

        }

        [TestMethod]
        public void Information_Gather()
        {
            Parameters.QueryWord = "hello";
            Definition result = Collector.GatherData<Definition>(Parameters).Result;
            Assert.AreEqual<string>("hello", result.Results[0].Word);

        }

        [TestMethod]
        public void Information_WordNotFound()
        {
            //Parameters out
            Parameters.QueryWord = "inexistantword";
            Lemma result = Collector.GatherData<Lemma>(Parameters).Result;
            Assert.IsNull(result);
        }

    }
}
