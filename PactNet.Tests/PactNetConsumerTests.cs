using System;
using System.Collections.Generic;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace PactNet.Tests {
    public class PactNetConsumerTests : IClassFixture<ConsumerApiPact> {
        private IMockProviderService _mockProviderService;
        private string _baseUri;

        public PactNetConsumerTests (ConsumerApiPact apiPact) {
            _mockProviderService = apiPact.MockProviderService;
            _mockProviderService.ClearInteractions ();
            _baseUri = apiPact.MockProviderServiceBaseUri;
        }

        [Fact]
        public async Task GetUser_WhenPactExists_ReturnsUser () {
            // Arrange
            _mockProviderService
                .Given ("There is a user with id 0")
                .UponReceiving ("A GET request with the user id")
                .With (new ProviderServiceRequest {
                    Method = HttpVerb.Get,
                        Path = "api/users/0",
                        Headers = new Dictionary<string, object> { { "Accept", "application/json" }
                        }
                })
                .WillRespondWith (new ProviderServiceResponse {
                    Status = 200,
                        Headers = new Dictionary<string, object> { { "Content-Type", "application/json" }
                        },
                        Body = new {
                            id = 0,
                                name = "Tony Stark",
                                occupation = "Iron Man",
                                roles = new List<object> {
                                    new {
                                        name = "Genius",
                                            description = "Building Jarvis, aka Vision, aka AI"
                                    },
                                    new {
                                        name = "CEO",
                                            description = "Lying to the board"
                                    },
                                    new {
                                        name = "Fighter",
                                            description = "Made Thanos bleed"
                                    }
                                }
                        }
                });
            var consumer = new PactNet.Library.PactNetClient();
            // Act
            var result = await consumer.Get(0);
            // Assert
            Assert.Equal(0, result.Id)
        }
    }
}