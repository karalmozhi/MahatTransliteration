namespace Admin.Controllers
{
	using System;
	using System.Data;
	using System.Linq;
	using Microsoft.AspNetCore.Mvc;
	using Newtonsoft.Json;
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Threading.Tasks;
	using System.Net.Http.Headers;
	using Microsoft.Extensions.Options;
	using Microsoft.AspNetCore.Http;
	using System.Collections.Generic;
	using System.IO;
	using Microsoft.AspNetCore.Hosting;
	using System.Net;
	using FluentValidation.Results;
	using englishtotamil.Models;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.AspNetCore.HttpOverrides;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.Logging;
	using ConsoleApp16;
	namespace Admin.Controllers
	{
		//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:20:14



		public class englishtotamilController : Controller
		{
			private HttpClient client = new HttpClient();
			private IWebHostEnvironment hostingEnv;
			private IOptions<ApiSettings> _balSettings;
			private IOptions<MailSettings> _mailSettings;
			private string url = "";
			private string baseUrl = "";
			private string adminUrl = "";
			private string clientUrl = "";
			private string accesskey = "";
			private IHttpContextAccessor _accessor;
			public IConfiguration Configuration { get; }
			private readonly ILogger<englishtotamilController> _logger;

			public virtual HttpClient getHttpClient()
			{
				client.BaseAddress = new Uri(url);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("englishtotamiltoken"));
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				return client;
			}
			public englishtotamilController(IConfiguration configuration, IHttpContextAccessor accessor, IOptions<ApiSettings> ApiSettings, IOptions<MailSettings> MailSettings, IWebHostEnvironment env, ILogger<englishtotamilController> logger)
			{
				_logger = logger;
				this.hostingEnv = env;
				_balSettings = ApiSettings;
				_mailSettings = MailSettings;
				url = _balSettings.Value.apiURL;
				baseUrl = _balSettings.Value.baseURL;
				adminUrl = _balSettings.Value.adminURL;
				clientUrl = _balSettings.Value.clientURL;
				accesskey = _balSettings.Value.accesskey;

				_accessor = accessor;
				Configuration = configuration;

			}
			public virtual IActionResult detail()
			{
				return View();
			}

			public async Task<JsonResult> PerformTransliteration(string enterthename, string enterthetargetlanguage)
			{
				reference refer = new reference();
				string transliteratedtext = await refer.TransliterateText(enterthename, enterthetargetlanguage);

				return Json(new { transliteratedtext });
			}


			public virtual IActionResult Add_englishtotamil()
			{
				return View();
			}
			[HttpPost()]
			public virtual async Task<IActionResult> Add_englishtotamil(englishtotamilModel model, IFormCollection collection)

			{


				string strReturnMessage = "";
				string redirectTo = "";
				try
				{
					ModelState.Remove("englishtotamilid");
					ModelState.Remove("craftmyapp_actionmethodname");
					model.craftmyapp_actionmethodname = "Add_englishtotamil";
					ModelState.Remove("createduser");
					if (HttpContext.Session.GetString("englishtotamilloginUserID") != null)
						model.createduser = new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
						return RedirectToAction(redirectTo);



					if (HttpContext.Session.GetString("englishtotamilrole_JSON") != null)
					{
						DataTable englishtotamilrole_JSON = HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
						DataView dv = new DataView(englishtotamilrole_JSON);
						dv.RowFilter = "controllername='englishtotamil' AND viewname='list'";

						if (dv.Count > 0)
						{
							redirectTo = dv[0]["actionmethodname"] as string;

						}

					}

					if (ModelState.IsValid)
					{
						englishtotamilModelValidator validator = new englishtotamilModelValidator();
						ValidationResult results = validator.Validate(model);
						if (!results.IsValid)
						{
							var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}", e.PropertyName)));
							strReturnMessage = errorCollection.ToString();
							foreach (var failure in results.Errors)
							{
								ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
							}
						}
						else
						{


							strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(), "api/englishtotamil/Add_englishtotamil", model);
						}
					}
					else
					{
						var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
						strReturnMessage = errorCollection.ToString();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("Error occured in - englishtotamil / Add_englishtotamil , Error Message : " + ex.Message);
					Console.WriteLine(ex);
					strReturnMessage = ex.Message;
				}
				ViewData["message"] = strReturnMessage;
				if (strReturnMessage.Replace("\"", "").Contains("201.1"))
				{
					TempData["message"] = "Success";

					return RedirectToAction(redirectTo);
				}
				else
				{
					if (strReturnMessage == "401.1")
						ViewData["message"] = "Authorization Failed";

					return View(model);
				}

			}




			public virtual async Task<IActionResult> Update_englishtotamil(string englishtotamilid)
			{
				var jsonObjenglishtotamil = await ApiClient.Get_ApiValues(getHttpClient(), "api/englishtotamil/getById_englishtotamil?englishtotamilid=" + englishtotamilid + "&loginUserID=" + HttpContext.Session.GetString("englishtotamilloginUserID"));
				if (jsonObjenglishtotamil.Length > 2)
				{
					jsonObjenglishtotamil = jsonObjenglishtotamil.Substring(1, jsonObjenglishtotamil.Length - 2);
					var model = JsonConvert.DeserializeObject<englishtotamilModel>(jsonObjenglishtotamil);
					HttpContext.Session.SetSession("englishtotamilenglishtotamilModel", model);
					return View(model);
				}
				else
				{
					string redirectTo = "";
					if (HttpContext.Session.GetString("englishtotamilrole_JSON") != null)
					{
						DataTable englishtotamilrole_JSON = HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
						DataView dv = new DataView(englishtotamilrole_JSON);
						dv.RowFilter = "controllername='englishtotamil' AND viewname='list'";

						if (dv.Count > 0)
						{
							redirectTo = dv[0]["actionmethodname"] as string;

						}

					}
					TempData["message"] = "Data Not Found - Contact Administrator";
					return RedirectToAction(redirectTo);

				}
			}
			[HttpPost()]
			public virtual async Task<IActionResult> Update_englishtotamil(englishtotamilModel model, IFormCollection collection)
			{
				string strReturnMessage = "";
				string redirectTo = "";
				try
				{

					if (HttpContext.Session.GetString("englishtotamilrole_JSON") != null)
					{
						DataTable englishtotamilrole_JSON = HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
						DataView dv = new DataView(englishtotamilrole_JSON);
						dv.RowFilter = "controllername='englishtotamil' AND viewname='list'";

						if (dv.Count > 0)
						{
							redirectTo = dv[0]["actionmethodname"] as string;

						}

					}

					ModelState.Remove("englishtotamilid");
					ModelState.Remove("craftmyapp_actionmethodname");
					model.craftmyapp_actionmethodname = "Update_englishtotamil";



					if (HttpContext.Session.GetString("englishtotamilloginUserID") != null)
						model.modifieduser = new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
						return RedirectToAction(redirectTo);


					if (ModelState.IsValid)
					{
						englishtotamilModelValidator validator = new englishtotamilModelValidator();
						ValidationResult results = validator.Validate(model);
						if (!results.IsValid)
						{
							var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}", e.PropertyName)));
							strReturnMessage = errorCollection.ToString();
							foreach (var failure in results.Errors)
							{
								ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
							}
						}
						else
						{

							var modelCopy = HttpContext.Session.GetSession<englishtotamilModel>("englishtotamilenglishtotamilModel");

							strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(), "api/englishtotamil/Update_englishtotamil", model);
						}
					}
					else
					{
						var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
						strReturnMessage = errorCollection.ToString();
					}
				}
				catch (Exception ex)
				{
					_logger.LogError("Error occured in - englishtotamil / Update_englishtotamil , Error Message : " + ex.Message);
					Console.WriteLine(ex);
					strReturnMessage = ex.Message;
				}
				ViewData["message"] = strReturnMessage;
				if (strReturnMessage.Replace("\"", "") == "201.1")
				{
					TempData["message"] = "Success";

					return RedirectToAction(redirectTo);
				}
				else
				{
					if (strReturnMessage == "401.1")
						ViewData["message"] = "Authorization Failed";

					return View(model);
				}

			}
			public virtual async Task<IActionResult> Remove_englishtotamil(string englishtotamilid)
			{
				string message = "";
				try
				{
					message = await ApiClient.Get_ApiValues(getHttpClient(), "api/englishtotamil/Remove_englishtotamil?englishtotamilid=" + englishtotamilid + "&loginUserID=" + HttpContext.Session.GetString("englishtotamilloginUserID"));

					if (message.Replace("\"", "") == "201.1")
					{
						TempData["message"] = "Success";

					}
					else
					{
						TempData["errMessage"] = message.Replace("\"", "");
					}



				}
				catch (Exception ex)
				{
					_logger.LogError("Error occured in - englishtotamil / Remove_englishtotamil , Error Message : " + ex.Message);
					Console.WriteLine(ex);
					TempData["errMessage"] = ex.Message;
					message = ex.Message;
				}

				string redirectTo = "";
				if (HttpContext.Session.GetString("englishtotamilrole_JSON") != null)
				{
					DataTable englishtotamilrole_JSON = HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
					DataView dv = new DataView(englishtotamilrole_JSON);
					dv.RowFilter = "controllername='englishtotamil' AND viewname='list'";

					if (dv.Count > 0)
					{
						redirectTo = dv[0]["actionmethodname"] as string;

					}

				}

				return RedirectToAction(redirectTo);
			}

			public virtual IActionResult englishtotamil_List()
			{
				return View();
			}

			[HttpGet()]
			public virtual async Task<string> get_englishtotamil_List()
			{

				return await ApiClient.Get_ApiValues(getHttpClient(), "api/englishtotamil/englishtotamil_List?loginUserID=" + HttpContext.Session.GetString("englishtotamilloginUserID")
);
			}



			public virtual async Task<string> getById_sp_all_englishtotamil(string englishtotamilid)
			{
				return await ApiClient.Get_ApiValues(getHttpClient(), "api/englishtotamil/getById_sp_all_englishtotamil?englishtotamilid=" + englishtotamilid);

			}








		}

	}
}