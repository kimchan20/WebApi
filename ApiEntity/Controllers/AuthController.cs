using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using ApiEntity.Entity;

namespace ApiEntity.Controllers
{
	public class AuthController : ApiController
	{
		private serverEntity server = new serverEntity();

		public class roleModel
		{
			public string role { get; set; }
			public string username { get; set; }
			public string user_id { get; set; }
		}

		[System.Web.Mvc.HttpGet]
		[System.Web.Http.Route("api/getUserRole/{username}")]
		public roleModel getUserRole(string username)
		{
			using (server = new serverEntity())
			{
				var userRole = server.user_info.Where(x => x.username.Equals(username, StringComparison.CurrentCulture))
					.FirstOrDefault();

				var roleMod = new roleModel()
				{
					role = userRole.role,
					user_id = userRole.user_id,
					username = userRole.username,
				};
				return roleMod;
			}
		}

	}
}