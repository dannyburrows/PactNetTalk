using System;
using System.Collections.Generic;

namespace PactNet.Library
{
    public class PactNetService
    {
        public object Get(int id) {
            return new {
                id = id,
                name = "Tony Stark",
                occupation = "Iron Man",
                roles = new List<object>{
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
            };
        }
    }
}
