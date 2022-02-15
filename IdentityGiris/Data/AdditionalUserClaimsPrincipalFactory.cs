using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/add-user-data?view=aspnetcore-5.0&tabs=visual-studio#add-claims-to-identity-using-iuserclaimsprincipalfactoryapplicationuser
namespace IdentityGiris.Data
{
	public class AdditionalUserClaimsPrincipalFactory
		: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
	{
		public AdditionalUserClaimsPrincipalFactory(
			UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{ }

		public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
		{
			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;
			identity.AddClaim(new Claim("DisplayName", user.DisplayName));
			return principal;
		}
	}
}
