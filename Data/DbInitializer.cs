using Cricks.Data.DbModels;
using Microsoft.AspNetCore.Identity;

namespace Cricks.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, CricksDataContext context)
        {
            // Create roles
            var roles = new[] { "User", "Manager", "Admin", "Owner", "Scorer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create default Admin user
            var adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
            if (await userManager.FindByNameAsync(adminUser.UserName) == null)
            {
                await userManager.CreateAsync(adminUser, "Admin123#");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create default Owner user
            var ownerUser = new IdentityUser { UserName = "owner", Email = "owner@example.com" };
            if (await userManager.FindByNameAsync(ownerUser.UserName) == null)
            {
                await userManager.CreateAsync(ownerUser, "Owner123#");
                await userManager.AddToRoleAsync(ownerUser, "Owner");
            }

            // Crete default Dismissal Types
            await InitializeDismissalTypes(context);

        }

        private static async Task InitializeDismissalTypes(CricksDataContext context)
        {
            var dismissalTypes = new List<DismissalType>
            {
                new DismissalType { Name = "Bowled", Description = "The bowler has hit the stumps and dislodged the bails" },
                new DismissalType { Name = "Caught", Description = "The batsman has hit the ball and it has been caught by a fielder" },
                new DismissalType { Name = "Boundary", Description = "The batsman has hit a six where the Six is not permitted" },
                new DismissalType { Name = "LBW", Description = "The ball hits the batsman's leg in front of the stumps and it would have hit the stumps" },
                new DismissalType { Name = "Run Out", Description = "A player is out if no part of his bat or person is grounded behind the popping crease while the ball is in play and the wicket is fairly put down" },
                new DismissalType { Name = "Stumped", Description = "A batsman is out when the wicket-keeper puts down the wicket, while the batsman is out of his ground and not attempting a run" },
                new DismissalType { Name = "Hit Wicket", Description = "A batsman is out if he dislodges one or both bails with his bat, person, clothing or equipment in the act of receiving a ball, or in setting off for a run" },
                new DismissalType { Name = "Handled the Ball", Description = "A batsman is out if he wilfully strikes the ball with a hand not holding the bat, unless he does so with the consent of the opposition" },
                new DismissalType { Name = "Obstructing the Field", Description = "A batsman is out if he wilfully obstructs the opposition by word or action" },
                new DismissalType { Name = "Hit the Ball Twice", Description = "A batsman is out if he wilfully strikes the ball again with his bat or person, other than a hand not holding the bat, after the ball has been touched by a fielder" },
                new DismissalType { Name = "Timed Out", Description = "An incoming batsman is out if he takes more than three minutes to be ready to face the next delivery" },
                new DismissalType { Name = "Retired Out", Description = "In Test cricket, a batsman may retire out and will be considered out, with that term listed on the scorecard" }
            };

            foreach (var dismissalType in dismissalTypes)
            {
                if (!context.DismissalTypes.Any(dt => dt.Name == dismissalType.Name))
                {
                    context.DismissalTypes.Add(dismissalType);
                }
            }

            var extraTypes = new List<ExtraType>
            {
                new ExtraType { Name = "No Ball" },
                new ExtraType { Name = "Wide" },
                new ExtraType { Name = "Bye" },
                new ExtraType { Name = "Leg Bye" },
                new ExtraType { Name = "Penalty" }
            };

            foreach (var extraType in extraTypes)
            {
                if (!context.ExtraTypes.Any(et => et.Name == extraType.Name))
                {
                    context.ExtraTypes.Add(extraType);
                }
            }

            var playerTypes = new List<PlayerType>
            {
                new PlayerType { Name = "Batsman" },
                new PlayerType { Name = "Bowler" },
                new PlayerType { Name = "All-Rounder" },
                new PlayerType { Name = "Wicket-Keeper" },
                new PlayerType { Name = "Only-Fielder" }
            };

            foreach (var playerType in playerTypes)
            {
                if (!context.PlayerTypes.Any(pt => pt.Name == playerType.Name))
                {
                    context.PlayerTypes.Add(playerType);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
