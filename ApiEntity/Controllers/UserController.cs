﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiEntity.Class;
using ApiEntity.Entity;
using ApiEntity.Models;
using NHibernate.Mapping;

namespace ApiEntity.Controllers
{
	public class UserController : ApiController
	{
		private serverEntity entity = new serverEntity();
		private JsonConvert jsoncon = new JsonConvert();
		private AutoGenerate idGenerate = new AutoGenerate();

		//api entity
		//for Insert User info
		[Route("api/insertUser/")]
		[HttpPost]
		public string InserUser([FromBody] user_info user)
		{
			string res = "";
			try
			{
				user_info utdb = new user_info();
				jsoncon = new JsonConvert();
				using (entity = new serverEntity())
				{
					//if (!entity.user_info
					//	.Where(x => x.username.Equals(user.username, StringComparison.CurrentCulture)).Any())
					//{

					//	entity.user_info.Add(new user_info()
					//	{
					//		user_id =  idGenerate.generateUserId().Result,
					//		username = user.username.TrimEnd(),
					//		password = user.password.TrimEnd(),
					//		role = "admin",
					//		dcd2 = DateTime.Now,

					//	});
					//	entity.SaveChanges();

					//	return "Success";
				//	}
					//else
				//	{
					//	return "Duplicate";
					//}


					
					var useridParameter = new SqlParameter("@userid", user.user_id.ToString());
					var usernaParameter = new SqlParameter("@username", user.username.ToString());
					var passwordParameter = new SqlParameter("@password", user.password.ToString());
					var roleParameter = new SqlParameter("@role", user.role.ToString());
					var reSqlParameter = new SqlParameter("@res",SqlDbType.VarChar.ToString());
					reSqlParameter.Direction = ParameterDirection.Output;

					var ss = entity.Database.ExecuteSqlCommand("exec dbo.insertUserInfo @userid, @username, @password, @role",
					useridParameter,usernaParameter,passwordParameter,roleParameter);
					return ss.ToString();

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
					var checklogin = entity.user_info
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
			AccountModel amModel = new AccountModel();
			List<AccountModel.UserModel> userModel = new List<AccountModel.UserModel>();
			using (entity = new serverEntity())
			{
				var modelList = entity.SelectUser().ToList();
				return modelList;
			}
		}

		[Route("api/getEdituser/{id}")]
		[HttpGet]
		public dynamic getEdituser(int id)
		{
			try
			{
				using (entity = new serverEntity())
				{
					var userid = new SqlParameter("@id", id);
					var result =
						entity.Database.SqlQuery<AccountModel.UserModel>("exec getUsertoEdit @id", userid).FirstOrDefault();
					return result;
				}
			}
			catch (Exception ee)
			{
				return ee.Message;
			}
		}
	}
}