using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Nest;
using ConsoleTextSearcher.Interfaces;


namespace ConsoleTextSearcher.Test
{
    public class ElasticClientFactoryTest
    {

        [Fact]
        public void CreateElasticClient_ReturnsElasticClient()
        {
            var expectedClient = new Mock<IElasticClient>();

            var mockEsClientFactory = new Mock<IElasticClientFactory>();
            
            mockEsClientFactory.Setup(f => f.CreateElasticClient("url", true)).Returns(expectedClient.Object);

            var actualClient = mockEsClientFactory.Object.CreateElasticClient("url", true);

            Assert.Equal(expectedClient.Object.ToString(), actualClient.ToString());
        }

        [Fact]
        public void GetElasticClient_ReturnsElasticClient()
        {
            var expectedClient = new Mock<IElasticClient>();

            var mockEsClientFactory = new Mock<IElasticClientFactory>();

            mockEsClientFactory.Setup(f => f.CreateElasticClient("url", true)).Returns(expectedClient.Object);

            mockEsClientFactory.Setup(f => f.GetElasticClient()).Returns(expectedClient.Object);

            var actualClient = mockEsClientFactory.Object.GetElasticClient();

            Assert.Equal(expectedClient.Object.ToString(), actualClient.ToString());
        }


        [Fact]
        public void CheckClientConnection_ReturnTrue()
        {
            var expectionValue = true;

            var mockEsClientFactory = new Mock<IElasticClientFactory>();

            mockEsClientFactory.Setup(f => f.CheckClientConnection()).Returns(true);

            var actualValue =  mockEsClientFactory.Object.CheckClientConnection();

            Assert.Equal(expectionValue, actualValue);
        }


        [Fact]
        public void CheckClientConnection_ReturnFalse()
        {
            var expectionValue = false;

            var mockEsClientFactory = new Mock<IElasticClientFactory>();

            mockEsClientFactory.Setup(f => f.CheckClientConnection()).Returns(false);

            var actualValue =  mockEsClientFactory.Object.CheckClientConnection();

            Assert.Equal(expectionValue, actualValue);
        }



    }
}