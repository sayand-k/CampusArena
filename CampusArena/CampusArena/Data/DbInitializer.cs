using Microsoft.AspNetCore.Identity;

namespace CampusArena.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdmin(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            // 1. Create the Roles (The Badges)
            string[] roleNames = { "Admin", "Captain", "Scorer" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // 2. Create the Master Admin (The Person)
            string adminEmail = "admin@campusarena.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                // Create a new user object
                var newAdmin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                // Save the user to the database with a password
                // Note: In a real app, use a very strong password!
                var createPowerUser = await userManager.CreateAsync(newAdmin, "Admin@123");

                if (createPowerUser.Succeeded)
                {
                    // Give this person the "Admin" badge
                    await userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }
}