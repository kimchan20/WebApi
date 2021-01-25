using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ApiEntity.Entity;

namespace ApiEntity.Class
{
	public class AutoGenerate
	{
		private serverEntity serverEntity = new serverEntity();
		public async Task<string> generateUserId()
		{
			var res = "";
			using (serverEntity = new serverEntity())
			{
				var lastuser = serverEntity.user_info.OrderByDescending(x => x.id).Count();
				string userid = "000000000";
				int id = Int32.Parse(userid) + (lastuser + 1);
				res = String.Format("{0:000000000", id);
			}

			return res;
		}
	}
}