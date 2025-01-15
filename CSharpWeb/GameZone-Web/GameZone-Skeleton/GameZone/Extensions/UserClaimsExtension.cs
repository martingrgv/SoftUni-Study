namespace System.Security.Claims
{
	public static class UserClaimsExtension
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}
	}
}
