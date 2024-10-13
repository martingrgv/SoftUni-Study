using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
	}
}
