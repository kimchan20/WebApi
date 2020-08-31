using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiEntity.Models;
using Newtonsoft.Json;

namespace ApiEntity.Class
{
	public class JsonConvert
	{
		private AccountModel accountUser = new AccountModel();
		public AccountModel JsonUser(string user)
		{
			var userModel = Newtonsoft.Json.JsonConvert.DeserializeObject<AccountModel>(user);

			accountUser.username = userModel.username;
			accountUser.password = userModel.password;

			return accountUser;
		}
	}

}