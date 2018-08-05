using System;
using System.Collections.Generic;

namespace PactNet.Library
{
    public class PactNetService
    {
        public User Get(int id) {
            return new User {
                Id = id,
                Name = "Tony Stark",
                Occupation = "Iron Man",
                Roles = new List<Role>{
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
        }
    }
}
