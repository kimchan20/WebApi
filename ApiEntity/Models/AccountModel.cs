using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ApiEntity.Models
{
	public class AccountModel
	{
		private const int hashkey = 13;
		public virtual void fakepassword()
		{
			BCrypt.Net.BCrypt.HashPassword("",hashkey);
		}
		public string username { get; set; }
		public string password { get; set; }

		public bool checkhashpass { get; set; }

		public virtual bool verify(string password,string hash)
		{
			checkhashpass = BCrypt.Net.BCrypt.Verify(password,hash);
			return checkhashpass;
		}


		public class UserModel
		{
			public int id { get; set; }
			public string username { get; set; }
			public string password { get; set; }
		}
	}
}


