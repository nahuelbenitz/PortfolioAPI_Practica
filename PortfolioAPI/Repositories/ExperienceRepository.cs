using PortfolioAPI.Entities;

namespace PortfolioAPI.Repositories
{
    public static class ExperienceRepository
    {
        public static List<Experience> Experiences { get; set; } = new List<Experience>()
            {
                new Experience()
                {
                    Id = 1,
                    Title = "Exp 1 Testing",
                    Description = "zaraza",
                    Summary = "zarazazarazazaraza",
                    ImagePath = "zarazazaraza"
                },
                new Experience()
                {
                    Id = 2,
                    Title = "Exp 2 Testing",
                    Description = "zaraza",
                    Summary = "zarazazarazazaraza",
                    ImagePath = "zarazazaraza"
                },
                new Experience()
                {
                    Id = 3,
                    Title = "Exp 3 Testing",
                    Description = "zaraza",
                    Summary = "zarazazarazazaraza",
                    ImagePath = "zarazazaraza"
                },
                new Experience()
                {
                    Id = 4,
                    Title = "Backend",
                    Description = "zaraza",
                    Summary = "zarazazarazazaraza",
                    ImagePath = "zarazazaraza"
                }
            };
        }
    }

