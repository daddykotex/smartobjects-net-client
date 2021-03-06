using System;
using NUnit.Framework;
using Mnubo.SmartObjects.Client.Impl;
using Mnubo.SmartObjects.Client.Config;
using Mnubo.SmartObjects.Client.Models.DataModel;
using System.Threading.Tasks;
using System.Linq;

namespace Mnubo.SmartObjects.Client.ITTest
{
    [TestFixture()]
    public class ModelITTests
    {
        private readonly ISmartObjectsClient client;

        public ModelITTests()
        {
            if (Environment.GetEnvironmentVariable("CONSUMER_KEY") == null ||
                Environment.GetEnvironmentVariable("CONSUMER_SECRET") == null) {
                throw new Exception("Consumer key/secret are unvailable");
            }

            client = ClientFactory.Create(
                new ClientConfig.Builder()
                {
                    Environment = ClientConfig.Environments.Sandbox,
                    ConsumerKey = Environment.GetEnvironmentVariable("CONSUMER_KEY"),
                    ConsumerSecret = Environment.GetEnvironmentVariable("CONSUMER_SECRET")
                }
            );
        }

        [Test()]
        public void TestExport()
        {
            Model model = client.Model.Export();
            Assert.AreEqual(2, model.EventTypes.Count, "event types count");
            Assert.AreEqual(2, model.Timeseries.Count, "timeseries count");
            Assert.AreEqual(1, model.ObjectTypes.Count, "object types count");
            Assert.AreEqual(1, model.ObjectAttributes.Count, "object attributes count");
            Assert.AreEqual(1, model.OwnerAttributes.Count, "owner attributes count");
            Assert.AreEqual(1, model.Sessionizers.Count, "sessionizers count");

        }
    }
}
