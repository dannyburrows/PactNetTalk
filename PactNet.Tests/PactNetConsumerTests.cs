using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PactNet.Library;
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
            var expectedUser = new User {
                Id = 0,
                Name = "Tony Stark",
                Occupation = "Iron Man",
                Roles = new List<Role> {
                new Role {
                Name = "Genius",
                Description = "Building Jarvis, aka Vision, aka AI"
                },
                new Role {
                Name = "CEO",
                Description = "Lying to the board"
                },
                new Role {
                Name = "Fighter",
                Description = "Made Thanos bleed"
                }
                }
            };
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
                        Body = expectedUser
                });
            var consumer = new PactNet.Library.PactNetClient (_baseUri);
            // Act
            var result = await consumer.Get (0);
            // Assert
            Assert.True(result.Equals(expectedUser));
            _mockProviderService.VerifyInteractions();
        }
    }
}