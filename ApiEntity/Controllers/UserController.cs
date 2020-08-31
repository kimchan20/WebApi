using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiEntity.Class;
using ApiEntity.Entity;
using ApiEntity.Models;

namespace ApiEntity.Controllers
{
	public class UserController : ApiController
	{
		private serverEntity entity = new serverEntity();
		private JsonConvert jsoncon = new JsonConvert();

		//api entity
		//for Insert User info
		[Route("api/inserUser/")]
		[HttpPost]
		public string InserUser([FromBody] MVC5 user)
		{
			string res = "";
			try
			{
				MVC5 utdb = new MVC5();
				jsoncon = new JsonConvert();
				using (entity = new serverEntity())
				{
					if (!entity.MVC5
						.Where(x => x.username.Equals(user.username, StringComparison.CurrentCulture)).Any())
					{

						entity.MVC5.Add(new MVC5()
						{
							username = user.username.TrimEnd(),
							password = user.password.TrimEnd(),
						});
						entity.SaveChanges();

						return "Success";
					}
					else
					{
						return "Duplicate";
					}
				}
			}
			catch (Exception ee)
			{
				res = "Error : " + ee.Message;
			}


			return res;
		}

		//api entity  for login User
		//
		[Route("api/loginUser/{username}/{password}")]
		[HttpGet]
		public string Login(string username, string password)
		{
			try
			{
				AccountModel accountModel = new AccountModel();
				using (entity = new serverEntity())
				{
					var checklogin = entity.MVC5
						.Where(x => x.username.Equals(username))
						.FirstOrDefault();
					if (checklogin != null)
					{
						accountModel.fakepassword();
						var res = accountModel.verify(password, checklogin.password.TrimEnd()).ToString();
						return res;
					}
					else
					{
						return "false";
					}
				}
			}
			catch (Exception ee)
			{

				return "Error : " + ee.Message;
			}
		}


		//api store procedure
		// get user list
		[Route("api/getUserList")]
		[HttpGet]
		public dynamic userlist()
		{
			try
			{
				AccountModel amModel = new AccountModel();
				List<AccountModel.UserModel>  userModel = new List<AccountModel.UserModel>();
				using (entity = new serverEntity())
				{
					var modelResults = entity.SelectUser().ToList();
					return modelResults;
				}
			}
			catch (Exception ee)
			{
				return ee.Message;
			}
		}
	}
}