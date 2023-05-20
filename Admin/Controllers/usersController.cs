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
                
                
				//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:57
				
                
                
				public class usersController : Controller
				{	 
					private HttpClient  client = new HttpClient();
					private IWebHostEnvironment hostingEnv;
					private IOptions<ApiSettings> _balSettings;
                    private IOptions<MailSettings> _mailSettings;
					private string  url = "";
					private string  baseUrl = "";
                    private string  adminUrl = "";
                    private string  clientUrl = "";
                    private string  accesskey = "";
					private IHttpContextAccessor _accessor;
                    public IConfiguration Configuration { get; }
                    private readonly ILogger<usersController> _logger;
                    
					public virtual HttpClient getHttpClient()
					{
						client.BaseAddress = new Uri(url);
						client.DefaultRequestHeaders.Accept.Clear();
						client.DefaultRequestHeaders.Add("Authorization", "Bearer " + HttpContext.Session.GetString("englishtotamiltoken")); 
						client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
						return client; 
					}
					public usersController(IConfiguration configuration,IHttpContextAccessor accessor,IOptions<ApiSettings> ApiSettings, IOptions<MailSettings> MailSettings, IWebHostEnvironment env, ILogger<usersController> logger)
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

	

					
				
			  public virtual async Task<string> getById_alloweddevices(string usersid)
			  {
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_alloweddevices?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
					 
			  }


			  public virtual IActionResult CreatePlatform()
			  {
					return View();
			  }	
			  [HttpPost()]
			public virtual async Task<string> CreatePlatform(usersModel model, IFormCollection collection)
			{
				string strReturnMessage = "";
				
				try
				{
					ModelState.Remove("usersid");
					ModelState.Remove("createduser");
                    ModelState.Remove("craftmyapp_actionmethodname");
                    model.craftmyapp_actionmethodname="CreatePlatform";
					
					ModelState.Remove("profilepicture");

					
			 	 
					 if (ModelState.IsValid)
					 {
							 usersModelValidator validator = new usersModelValidator();
							 ValidationResult results = validator.Validate(model);
							 if (!results.IsValid)
							 {
								 var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
								 strReturnMessage = errorCollection.ToString();
								 foreach (var failure in results.Errors)
								 {
									ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
								 }
							 }
							 else
							 {
								 model.userrole =collection["userrole"];
								 var files = Request.Form.Files;
foreach (var file in files) 
{
var filename = ContentDispositionHeaderValue
.Parse(file.ContentDisposition)
.FileName
.Trim('"'); 
string fileExtention = "." + filename.Split('.').Last(); 
Random rnd = new Random();
string uploadFileName = System.Text.RegularExpressions.Regex.Replace(filename.Split('.').First(), @"[^0-9a-zA-Z_.]+", "").Replace(" ", String.Empty)+"_"+"users_" +rnd.Next(1, 10000).ToString() + DateTime.Now.ToString("ddMMyyHHmmss")+ fileExtention;
if (fileExtention != ".")
{
var filanameFolder = hostingEnv.WebRootPath +  "/uploads/"; 
if (!Directory.Exists(filanameFolder))
{
Directory.CreateDirectory(filanameFolder);
}
filename  = filanameFolder + uploadFileName;
using (FileStream fs = System.IO.File.Create(filename))
{
file.CopyTo(fs);
fs.Flush();
}
if (file.Name == "profilepicture")
{
uploadFileName = baseUrl + "/uploads/" + uploadFileName;
model.profilepicture = uploadFileName;
}
}
}

								 strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/Register_Profile", model);
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
                _logger.LogError("Error occured in - users / CreatePlatform , Error Message : " + ex.Message);
                 Console.WriteLine(ex);
				 strReturnMessage = ex.Message;
			 }
		     ViewData["message"] = strReturnMessage;
			 if(strReturnMessage.Replace("\"", "").Contains("201.1")){
				 TempData["message"] = "Success";
				 
				return "Success";
			 }else{
				  if(strReturnMessage=="401.1")
				  	 	 strReturnMessage = "Authorization Failed";

				  return strReturnMessage;
			 }
 
		   }

			  public virtual IActionResult Register_Profile()
			  {
					return View();
			  }	
			  [HttpPost()]
			public virtual async Task<string> Register_Profile(usersModel model, IFormCollection collection)
			{
				string strReturnMessage = "";
				
				try
				{
					ModelState.Remove("usersid");
					ModelState.Remove("createduser");
                    ModelState.Remove("craftmyapp_actionmethodname");
                    model.craftmyapp_actionmethodname="Register_Profile";
					
					ModelState.Remove("profilepicture");

					
			 	 
					 if (ModelState.IsValid)
					 {
							 usersModelValidator validator = new usersModelValidator();
							 ValidationResult results = validator.Validate(model);
							 if (!results.IsValid)
							 {
								 var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
								 strReturnMessage = errorCollection.ToString();
								 foreach (var failure in results.Errors)
								 {
									ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
								 }
							 }
							 else
							 {
								 model.userrole =collection["userrole"];
								 var files = Request.Form.Files;
foreach (var file in files) 
{
var filename = ContentDispositionHeaderValue
.Parse(file.ContentDisposition)
.FileName
.Trim('"'); 
string fileExtention = "." + filename.Split('.').Last(); 
Random rnd = new Random();
string uploadFileName = System.Text.RegularExpressions.Regex.Replace(filename.Split('.').First(), @"[^0-9a-zA-Z_.]+", "").Replace(" ", String.Empty)+"_"+"users_" +rnd.Next(1, 10000).ToString() + DateTime.Now.ToString("ddMMyyHHmmss")+ fileExtention;
if (fileExtention != ".")
{
var filanameFolder = hostingEnv.WebRootPath +  "/uploads/"; 
if (!Directory.Exists(filanameFolder))
{
Directory.CreateDirectory(filanameFolder);
}
filename  = filanameFolder + uploadFileName;
using (FileStream fs = System.IO.File.Create(filename))
{
file.CopyTo(fs);
fs.Flush();
}
if (file.Name == "profilepicture")
{
uploadFileName = baseUrl + "/uploads/" + uploadFileName;
model.profilepicture = uploadFileName;
}
}
}

								 strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/Register_Profile", model);
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
                _logger.LogError("Error occured in - users / Register_Profile , Error Message : " + ex.Message);
                 Console.WriteLine(ex);
				 strReturnMessage = ex.Message;
			 }
		     ViewData["message"] = strReturnMessage;
			 if(strReturnMessage.Replace("\"", "").Contains("201.1")){
				 TempData["message"] = "Success";
				 
				return "Success";
			 }else{
				  if(strReturnMessage=="401.1")
				  	 	 strReturnMessage = "Authorization Failed";

				  return strReturnMessage;
			 }
 
		   }

				
			  public virtual async Task<IActionResult> EditPlatform(string usersid)
			  {

                    string redirectTo="";
                    if(HttpContext.Session.GetString("englishtotamilrole_JSON") != null){
                            DataTable englishtotamilrole_JSON =HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
                            DataView dv = new DataView(englishtotamilrole_JSON);
                            dv.RowFilter = "controllername='users' AND viewname='list'";

                            if(dv.Count  >0){
                                redirectTo = dv[0]["actionmethodname"] as string;
							 
                            }

                            try{

                                var jsonObjusers = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_users?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
                                if(jsonObjusers.Length > 2)
                                {
                                    jsonObjusers = jsonObjusers.Substring(1, jsonObjusers.Length - 2);
                                    var model = JsonConvert.DeserializeObject<usersModel>(jsonObjusers);
                                    HttpContext.Session.SetSession("englishtotamilusersModel", model);
                                    return View(model);
                                }
                                else
                                {
                    
                                    TempData["message"] = "Data Not Found - Contact Administrator";
                                    return RedirectToAction(redirectTo);
						 
                                }

                            }catch(Exception ex){
                                _logger.LogError("Error occured while fetching data - users / EditPlatform , Error Message : " + ex.Message);
                                Console.WriteLine(ex);
                                TempData["errMessage"] = "Error while fetching data - Contact Administrator";
                                return RedirectToAction(redirectTo);
                            }

                    }
                    TempData["errMessage"] = "Session Expired";
                    return RedirectToAction("Logout", "users");
                }	
			  [HttpPost()]
				public virtual async Task<string> EditPlatform(usersModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					try
					{
							ModelState.Remove("usersid");
                            ModelState.Remove("craftmyapp_actionmethodname");
                             model.craftmyapp_actionmethodname="EditPlatform";
							
							model.userrole =collection["userrole"];
							if(HttpContext.Session.GetString("englishtotamilloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
					return "Session Expired";
							

                            
							if (ModelState.IsValid)
							{
									usersModelValidator validator = new usersModelValidator();
									ValidationResult results = validator.Validate(model);
									if (!results.IsValid)
									{
										var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
										strReturnMessage = errorCollection.ToString();
										foreach (var failure in results.Errors)
										{
											ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
										}
									}
									else
									{
										var files = Request.Form.Files;
foreach (var file in files) 
{
var filename = ContentDispositionHeaderValue
.Parse(file.ContentDisposition)
.FileName
.Trim('"'); 
string fileExtention = "." + filename.Split('.').Last(); 
Random rnd = new Random();
string uploadFileName = System.Text.RegularExpressions.Regex.Replace(filename.Split('.').First(), @"[^0-9a-zA-Z_.]+", "").Replace(" ", String.Empty)+"_"+"users_" +rnd.Next(1, 10000).ToString() + DateTime.Now.ToString("ddMMyyHHmmss")+ fileExtention;
if (fileExtention != ".")
{
var filanameFolder = hostingEnv.WebRootPath +  "/uploads/"; 
if (!Directory.Exists(filanameFolder))
{
Directory.CreateDirectory(filanameFolder);
}
filename  = filanameFolder + uploadFileName;
using (FileStream fs = System.IO.File.Create(filename))
{
file.CopyTo(fs);
fs.Flush();
}
if (file.Name == "profilepicture")
{
uploadFileName = baseUrl + "/uploads/" + uploadFileName;
model.profilepicture = uploadFileName;
}
}
}

                                        var modelCopy = HttpContext.Session.GetSession<usersModel> ("englishtotamilusersModel");
if(model.profilepicture ==  null || model.profilepicture=="")
model.profilepicture = modelCopy.profilepicture;

                                        
										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/Update_Profile", model);
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
                        _logger.LogError("Error occured in - users / EditPlatform , Error Message : " + ex.Message);
Console.WriteLine(ex);
						strReturnMessage = ex.Message;
					}
					ViewData["message"] = strReturnMessage;
					    if(strReturnMessage.Replace("\"", "")=="201.1"){
							TempData["message"] = "Success";
							
							return "Success";
						}else{
							if(strReturnMessage=="401.1")
									strReturnMessage = "Authorization Failed";

							return strReturnMessage;
						}
		
				}

				
			  public virtual async Task<IActionResult> UpdateProfile(string usersid)
			  {

                    string redirectTo="";
                    if(HttpContext.Session.GetString("englishtotamilrole_JSON") != null){
                            DataTable englishtotamilrole_JSON =HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
                            DataView dv = new DataView(englishtotamilrole_JSON);
                            dv.RowFilter = "controllername='users' AND viewname='list'";

                            if(dv.Count  >0){
                                redirectTo = dv[0]["actionmethodname"] as string;
							 
                            }

                            try{

                                var jsonObjusers = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_users?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
                                if(jsonObjusers.Length > 2)
                                {
                                    jsonObjusers = jsonObjusers.Substring(1, jsonObjusers.Length - 2);
                                    var model = JsonConvert.DeserializeObject<usersModel>(jsonObjusers);
                                    HttpContext.Session.SetSession("englishtotamilusersModel", model);
                                    return View(model);
                                }
                                else
                                {
                    
                                    TempData["message"] = "Data Not Found - Contact Administrator";
                                    return RedirectToAction(redirectTo);
						 
                                }

                            }catch(Exception ex){
                                _logger.LogError("Error occured while fetching data - users / UpdateProfile , Error Message : " + ex.Message);
                                Console.WriteLine(ex);
                                TempData["errMessage"] = "Error while fetching data - Contact Administrator";
                                return RedirectToAction(redirectTo);
                            }

                    }
                    TempData["errMessage"] = "Session Expired";
                    return RedirectToAction("Logout", "users");
                }	
			  [HttpPost()]
				public virtual async Task<string> UpdateProfile(usersModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					try
					{
							ModelState.Remove("usersid");
                            ModelState.Remove("craftmyapp_actionmethodname");
                             model.craftmyapp_actionmethodname="UpdateProfile";
							
							model.userrole =collection["userrole"];
							if(HttpContext.Session.GetString("englishtotamilloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
					return "Session Expired";
							

                            
							if (ModelState.IsValid)
							{
									usersModelValidator validator = new usersModelValidator();
									ValidationResult results = validator.Validate(model);
									if (!results.IsValid)
									{
										var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
										strReturnMessage = errorCollection.ToString();
										foreach (var failure in results.Errors)
										{
											ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
										}
									}
									else
									{
										var files = Request.Form.Files;
foreach (var file in files) 
{
var filename = ContentDispositionHeaderValue
.Parse(file.ContentDisposition)
.FileName
.Trim('"'); 
string fileExtention = "." + filename.Split('.').Last(); 
Random rnd = new Random();
string uploadFileName = System.Text.RegularExpressions.Regex.Replace(filename.Split('.').First(), @"[^0-9a-zA-Z_.]+", "").Replace(" ", String.Empty)+"_"+"users_" +rnd.Next(1, 10000).ToString() + DateTime.Now.ToString("ddMMyyHHmmss")+ fileExtention;
if (fileExtention != ".")
{
var filanameFolder = hostingEnv.WebRootPath +  "/uploads/"; 
if (!Directory.Exists(filanameFolder))
{
Directory.CreateDirectory(filanameFolder);
}
filename  = filanameFolder + uploadFileName;
using (FileStream fs = System.IO.File.Create(filename))
{
file.CopyTo(fs);
fs.Flush();
}
if (file.Name == "profilepicture")
{
uploadFileName = baseUrl + "/uploads/" + uploadFileName;
model.profilepicture = uploadFileName;
}
}
}

                                        var modelCopy = HttpContext.Session.GetSession<usersModel> ("englishtotamilusersModel");
if(model.profilepicture ==  null || model.profilepicture=="")
model.profilepicture = modelCopy.profilepicture;

                                        if(model.profilepicture !=  null && model.profilepicture!="")
                                                HttpContext.Session.SetString("englishtotamilprofilepicture", model.profilepicture.ToString());
										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/Update_Profile", model);
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
                        _logger.LogError("Error occured in - users / UpdateProfile , Error Message : " + ex.Message);
Console.WriteLine(ex);
						strReturnMessage = ex.Message;
					}
					ViewData["message"] = strReturnMessage;
					    if(strReturnMessage.Replace("\"", "")=="201.1"){
							TempData["message"] = "Success";
							
							return "Success";
						}else{
							if(strReturnMessage=="401.1")
									strReturnMessage = "Authorization Failed";

							return strReturnMessage;
						}
		
				}

				
			  public virtual async Task<IActionResult> Update_Profile(string usersid)
			  {

                    string redirectTo="";
                    if(HttpContext.Session.GetString("englishtotamilrole_JSON") != null){
                            DataTable englishtotamilrole_JSON =HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
                            DataView dv = new DataView(englishtotamilrole_JSON);
                            dv.RowFilter = "controllername='users' AND viewname='list'";

                            if(dv.Count  >0){
                                redirectTo = dv[0]["actionmethodname"] as string;
							 
                            }

                            try{

                                var jsonObjusers = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_users?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
                                if(jsonObjusers.Length > 2)
                                {
                                    jsonObjusers = jsonObjusers.Substring(1, jsonObjusers.Length - 2);
                                    var model = JsonConvert.DeserializeObject<usersModel>(jsonObjusers);
                                    HttpContext.Session.SetSession("englishtotamilusersModel", model);
                                    return View(model);
                                }
                                else
                                {
                    
                                    TempData["message"] = "Data Not Found - Contact Administrator";
                                    return RedirectToAction(redirectTo);
						 
                                }

                            }catch(Exception ex){
                                _logger.LogError("Error occured while fetching data - users / Update_Profile , Error Message : " + ex.Message);
                                Console.WriteLine(ex);
                                TempData["errMessage"] = "Error while fetching data - Contact Administrator";
                                return RedirectToAction(redirectTo);
                            }

                    }
                    TempData["errMessage"] = "Session Expired";
                    return RedirectToAction("Logout", "users");
                }	
			  [HttpPost()]
				public virtual async Task<string> Update_Profile(usersModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					try
					{
							ModelState.Remove("usersid");
                            ModelState.Remove("craftmyapp_actionmethodname");
                             model.craftmyapp_actionmethodname="Update_Profile";
							
							model.userrole =collection["userrole"];
							if(HttpContext.Session.GetString("englishtotamilloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
					return "Session Expired";
							

                            
							if (ModelState.IsValid)
							{
									usersModelValidator validator = new usersModelValidator();
									ValidationResult results = validator.Validate(model);
									if (!results.IsValid)
									{
										var errorCollection = string.Join(" | ", results.Errors.Select(e => e.ErrorMessage.Replace("{propertyName}",e.PropertyName)));
										strReturnMessage = errorCollection.ToString();
										foreach (var failure in results.Errors)
										{
											ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
										}
									}
									else
									{
										var files = Request.Form.Files;
foreach (var file in files) 
{
var filename = ContentDispositionHeaderValue
.Parse(file.ContentDisposition)
.FileName
.Trim('"'); 
string fileExtention = "." + filename.Split('.').Last(); 
Random rnd = new Random();
string uploadFileName = System.Text.RegularExpressions.Regex.Replace(filename.Split('.').First(), @"[^0-9a-zA-Z_.]+", "").Replace(" ", String.Empty)+"_"+"users_" +rnd.Next(1, 10000).ToString() + DateTime.Now.ToString("ddMMyyHHmmss")+ fileExtention;
if (fileExtention != ".")
{
var filanameFolder = hostingEnv.WebRootPath +  "/uploads/"; 
if (!Directory.Exists(filanameFolder))
{
Directory.CreateDirectory(filanameFolder);
}
filename  = filanameFolder + uploadFileName;
using (FileStream fs = System.IO.File.Create(filename))
{
file.CopyTo(fs);
fs.Flush();
}
if (file.Name == "profilepicture")
{
uploadFileName = baseUrl + "/uploads/" + uploadFileName;
model.profilepicture = uploadFileName;
}
}
}

                                        var modelCopy = HttpContext.Session.GetSession<usersModel> ("englishtotamilusersModel");
if(model.profilepicture ==  null || model.profilepicture=="")
model.profilepicture = modelCopy.profilepicture;

                                        
										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/Update_Profile", model);
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
                        _logger.LogError("Error occured in - users / Update_Profile , Error Message : " + ex.Message);
Console.WriteLine(ex);
						strReturnMessage = ex.Message;
					}
					ViewData["message"] = strReturnMessage;
					    if(strReturnMessage.Replace("\"", "")=="201.1"){
							TempData["message"] = "Success";
							
							return "Success";
						}else{
							if(strReturnMessage=="401.1")
									strReturnMessage = "Authorization Failed";

							return strReturnMessage;
						}
		
				}
public virtual async Task<IActionResult> Suspend_Profile(string usersid)
			{
				string message = "";
				try
				{
						message = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/Suspend_Profile?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));

						 if(message.Replace("\"","")=="201.1")
						{
							TempData["message"] = "Success";

						}else{
							TempData["errMessage"] = message.Replace("\"","");
						}
						
				
				
				}
				catch (Exception ex)
				{
                    _logger.LogError("Error occured in - users / Suspend_Profile , Error Message : " + ex.Message);
Console.WriteLine(ex);
					 TempData["errMessage"] = ex.Message;
					 message = ex.Message;
				}

				string redirectTo="";
						if(HttpContext.Session.GetString("englishtotamilrole_JSON") != null){
					DataTable englishtotamilrole_JSON =HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
						 DataView dv = new DataView(englishtotamilrole_JSON);
						 dv.RowFilter = "controllername='users' AND viewname='list'";

						if(dv.Count  >0){
						    redirectTo = dv[0]["actionmethodname"] as string;
							 
						}

					}
				
				return RedirectToAction(redirectTo);
			}
public virtual async Task<IActionResult> DeletePlatform(string usersid)
			{
				string message = "";
				try
				{
						message = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/Suspend_Profile?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
				}
				catch (Exception ex)
				{
                _logger.LogError("Error occured in - users / DeletePlatform , Error Message : " + ex.Message);
Console.WriteLine(ex);
				message = ex.Message;
				}
				TempData["message"] = message;
				return RedirectToAction("IndexPlatform");
			}

			public virtual IActionResult Home()
			{
				return View();
			}
			
			
			public virtual IActionResult SessionExpired()
		{
			TempData["message"] = "Session Expired , Please login again !";
			return RedirectToAction("Login");
		}
		public virtual IActionResult AuthorizationFailed()
		{
			TempData["message"] = "API Authorization failed ,Please login again !";
			return RedirectToAction("Login");
		}
		public virtual IActionResult RoleAuthorizationFailed()
		{
			TempData["message"] = "Not authorized to view this page !";
			return RedirectToAction("Login");
		}
		[HttpGet()]
			public virtual async Task<string> get_roles()
			{
				 
				 return await ApiClient.Get_ApiValues(getHttpClient(), "api/users/get_roles?roles="+HttpContext.Session.GetString("englishtotamiluserrole"));
				 
			
			}
			

			
            public virtual IActionResult Login()
			{
				return View();
			}
            public virtual IActionResult Logout()
			{
				HttpContext.Session.Clear();
				return RedirectToAction("Login");
			}
            [HttpPost()]
			public virtual async Task<IActionResult> Login(userloginModel model)
			{
				string message = "";
				string strReturnMessage = "";
				try
				{


						userlockoutModel objuserlockoutModel=new userlockoutModel();
						objuserlockoutModel.username=model.username;
						objuserlockoutModel.latlan=model.latlan;
						string  remoteipaddress=_accessor.HttpContext.Connection.RemoteIpAddress.ToString();
						objuserlockoutModel.remoteipaddress=remoteipaddress;
						objuserlockoutModel.clientipaddress=model.clientipaddress;
						
						strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/userlockout/verify_userlockout", objuserlockoutModel);
						if(strReturnMessage !="Allow"){
						ViewData["message"] = strReturnMessage;
						return View(model);
						}
                        model.source="Internal";
						HttpResponseMessage response = await ApiClient.Post_ApiValuesGetRespnse(client,"api/users/checkUserAuthentication_users", model);
						
						
						if (response.IsSuccessStatusCode)
						{
						DataTable dt = await response.Content.ReadAsAsync<DataTable>();
						if (dt.Rows.Count >0)
						{
							HttpContext.Session.SetString("englishtotamilusername", dt.Rows[0]["username"].ToString());
							HttpContext.Session.SetString("englishtotamilloginUserID", dt.Rows[0]["usersid"].ToString());
							
							HttpContext.Session.SetString("englishtotamiltoken", dt.Rows[0]["token"].ToString());
							HttpContext.Session.SetString("englishtotamiluserrole", dt.Rows[0]["userrole"].ToString());
if(dt.Rows[0]["profilepicture"].ToString()!=null && dt.Rows[0]["profilepicture"].ToString()!="")
HttpContext.Session.SetString("englishtotamilprofilepicture", dt.Rows[0]["profilepicture"].ToString());
else
HttpContext.Session.SetString("englishtotamilprofilepicture", baseUrl+"/Icon_set/User.png");



							
							
							message ="Login Success";

							
                                                                            HttpContext.Session.SetString("englishtotamilchoosedtenantname", "");

																			HttpContext.Session.SetString("englishtotamilchoosedtenantid", dt.Rows[0]["tenantid"].ToString());

																			if(dt.Rows[0]["tenantid"].ToString() !="00000000-0000-0000-0000-000000000000")
																			{
																					message ="Authorization Failure. Please try again.";

																			}
																				
																			
																		
																		
																		

							//ROLE SECTION



							HttpResponseMessage response_roles = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_roleAuthorizations?viewactionroles="+dt.Rows[0]["userrole"].ToString());

							
							if (response_roles.IsSuccessStatusCode)
							{
								
								DataTable dt_roles = await response_roles.Content.ReadAsAsync<DataTable>();
								string role_JSON = await response_roles.Content.ReadAsStringAsync();
                                if(dt_roles.Rows.Count ==0){
                                        ViewData["message"]="You are not authorized to access englishtotamil , Please contact administrator";
                                        return View(model); 
                                }
            
								HttpContext.Session.SetSession("englishtotamilroles", dt_roles);
								HttpContext.Session.SetString("englishtotamilrole_JSON", role_JSON);
								

								
							} 
												


							//ROLE SECTION



							//MENU SECTION



							HttpResponseMessage response_menu = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_project_Menu?viewactionroles="+dt.Rows[0]["userrole"].ToString()+"&SubSystem=Admin");
							
							if (response_menu.IsSuccessStatusCode)
							{
								
								DataTable dt_menu = await response_menu.Content.ReadAsAsync<DataTable>();
								string menu_JSON = await response_menu.Content.ReadAsStringAsync();
								HttpContext.Session.SetSession("englishtotamilmenu", dt_menu);
								HttpContext.Session.SetString("englishtotamilmenu_JSON", menu_JSON);
								

								
							} 
												


							//MENU SECTION
					
						}
						else
						{
							 message = await ApiClient.Post_ApiValuesGetString(client,"api/userlockout/ins_userlockout", objuserlockoutModel);
						
							 
						}
						}
						else
						{
							message ="Response Failed";
						}
				}
				catch (Exception ex)
				{
                    _logger.LogError("Error occured in - users / Login , Error Message : " + ex.Message);
                    Console.WriteLine(ex);
					message = ex.Message;
				}
				ViewData["message"] = message;
				if(message=="Login Success"){
                    
					return RedirectToAction("UpdateProfile","users", new {@usersid=HttpContext.Session.GetString("englishtotamilloginUserID")});
					 
				}else{
				   
					return View(model);
				}

			}		//Register_user
		[HttpPost]
        public virtual async Task<String> appregister([FromBody] userloginModel model)
        {
            string message = "";
            string redirecturl = "";

            try
            {
				//IOS , ANDROID and WEB etc
                if (model.source == null || model.source == "")
                {

                    message = "|source is required|";

                }
				//Anything
                if (model.username == null || model.username == "")
                {

                    message += "|username is required|";

                }
				 
				//UUID Of android or IOS 
                if (model.deviceid == null || model.deviceid == "")
                {

                    message += "|deviceid is required|";

                }

                if (model.notificationid == null || model.notificationid == "")
                {

                    message += "|notificationid is required|";

                }


                if (model.accesskey == null || model.accesskey == "")
                {
                    message += "|accesskey is Required|";
                }

                else if (model.accesskey != accesskey)
                {
                    message += "|Invalid accesskey|";
                }
                 
                if (message == "")
                {
                     HttpResponseMessage response = await ApiClient.Post_ApiValuesGetRespnse(getHttpClient(),"api/users/checkUserAuthentication_users", model);
						
                    if (response.IsSuccessStatusCode)
                    {
                        DataTable dt = await response.Content.ReadAsAsync<DataTable>();
                        if (dt.Rows.Count > 0)
                        {

                            message = "Login Success";
                            redirecturl = adminUrl + "/" + "users/toapp?usersid=" + dt.Rows[0]["usersid"].ToString();
                            

                            
                                                                            HttpContext.Session.SetString("englishtotamilchoosedtenantname", "");

																			HttpContext.Session.SetString("englishtotamilchoosedtenantid", dt.Rows[0]["tenantid"].ToString());

																			if(dt.Rows[0]["tenantid"].ToString() !="00000000-0000-0000-0000-000000000000")
																			{
																					message ="Authorization Failure. Please try again.";

																			}
																				
																			
																		
																		
																		


                            //ROLE SECTION
                            HttpResponseMessage response_roles = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_roleAuthorizations?viewactionroles="+dt.Rows[0]["userrole"].ToString());

							
							if (response_roles.IsSuccessStatusCode)
							{
								
								DataTable dt_roles = await response_roles.Content.ReadAsAsync<DataTable>();
								if(dt_roles.Rows.Count ==0){
                                        message="You are not authorized to access englishtotamil , Please contact administrator";
                                         
                                }
            
								 
							}


 

                        }
                        else
                        {
                            message = "user not available";

                        }
                    }
                    else
                    {
                        message = "englishtotamil's API Response Failed";
                    }
                }
                else
                {

                    message = "Validation Failed : " + message;
                }




            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in - users / appregister , Error Message : " + ex.Message);
Console.WriteLine(ex);
                message = ex.Message;
            }

        

            if (message == "Login Success")
            {
                return JsonConvert.SerializeObject(new
                {
                    status = "success",
                    message = "success",
                    redirecturl = redirecturl
                });

            }
            else
            {

                return JsonConvert.SerializeObject(new
                {
                    status = "failed",
                    message = message,
                    redirecturl = ""
                });
            }
        }

		
        public virtual IActionResult applogin()
        {
            return RedirectToAction("Login");
        }

        //Mobile Or UUID FROM Mobile APP
		//uuid or mobile number is username
        [HttpPost]
        public virtual async Task<String> applogin(userloginModel model)
        {
            string message = "";
            string redirecturl = "";

            try
            {

                if (model.source == null || model.source == "")
                {

                    message = "|source required|";

                }

                if (model.username == null || model.username == "")
                {

                    message += "|username required|";

                }

                if (model.accesskey == null || model.accesskey == "")
                {
                    message += "|accesskey Required|";
                }

                else if (model.accesskey != accesskey)
                {

                    Console.WriteLine(model.accesskey);
                    Console.WriteLine(accesskey);

                    message += "|Invalid accesskey|";
                }

           

                if (message == "")
                {
  				 HttpResponseMessage response = await ApiClient.Post_ApiValuesGetRespnse(getHttpClient(),"api/users/checkUserAuthentication_users", model);
				

                    if (response.IsSuccessStatusCode)
                    {
                        DataTable dt = await response.Content.ReadAsAsync<DataTable>();
                        if (dt.Rows.Count > 0)
                        {
                            message = "Login Success";
    
                            redirecturl = adminUrl + "/" + "users/toapp?usersid=" + dt.Rows[0]["usersid"].ToString();
                            

                            
                                                                            HttpContext.Session.SetString("englishtotamilchoosedtenantname", "");

																			HttpContext.Session.SetString("englishtotamilchoosedtenantid", dt.Rows[0]["tenantid"].ToString());

																			if(dt.Rows[0]["tenantid"].ToString() !="00000000-0000-0000-0000-000000000000")
																			{
																					message ="Authorization Failure. Please try again.";

																			}
																				
																			
																		
																		
																		
 
                            HttpResponseMessage response_roles = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_roleAuthorizations?viewactionroles="+dt.Rows[0]["userrole"].ToString());

							
							if (response_roles.IsSuccessStatusCode)
							{
								
								DataTable dt_roles = await response_roles.Content.ReadAsAsync<DataTable>();
								if(dt_roles.Rows.Count ==0){
                                        message="You are not authorized to access englishtotamil , Please contact administrator";
                                         
                                }
            
								 
							}

                         }
                        else
                        {
                            message = "user not available";
  

                        }
                    }
                    else
                    {
                        message = "englishtotamil's API Response Failed";
                    }
                }
                else
                {

                    message = "Validation Failed : " + message;
                }




            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in - users / applogin , Error Message : " + ex.Message);
Console.WriteLine(ex);
                message = ex.Message;
            }

            

            if (message == "Login Success")
            {
                return JsonConvert.SerializeObject(new
                {
                    status = "success",
                    message = "success",
                    redirecturl = redirecturl
                });

            }
            else
            {

                return JsonConvert.SerializeObject(new
                {
                    status = "failed",
                    message = message,
                    redirecturl = ""
                });
            }
        }
 //Go_to_app_with_user_id
        public virtual async Task<IActionResult> toapp(string usersid)
        {
            string message = "";

            userloginModel model = new userloginModel();
            try
            {
                model.username = usersid;
                model.source = "allowbyid";
                HttpResponseMessage response = await ApiClient.Post_ApiValuesGetRespnse(getHttpClient(),"api/users/checkUserAuthentication_users", model);
					
               

                if (response.IsSuccessStatusCode)
                {
                    DataTable dt = await response.Content.ReadAsAsync<DataTable>();
                    if (dt.Rows.Count > 0)
                    {
                         HttpContext.Session.SetString("englishtotamilusername", dt.Rows[0]["username"].ToString());
							HttpContext.Session.SetString("englishtotamilloginUserID", dt.Rows[0]["usersid"].ToString());
							
							HttpContext.Session.SetString("englishtotamiltoken", dt.Rows[0]["token"].ToString());
							HttpContext.Session.SetString("englishtotamiluserrole", dt.Rows[0]["userrole"].ToString());
if(dt.Rows[0]["profilepicture"].ToString()!=null && dt.Rows[0]["profilepicture"].ToString()!="")
HttpContext.Session.SetString("englishtotamilprofilepicture", dt.Rows[0]["profilepicture"].ToString());
else
HttpContext.Session.SetString("englishtotamilprofilepicture", baseUrl+"/Icon_set/User.png");


                        message = "Login Success";

                         

							
                                                                            HttpContext.Session.SetString("englishtotamilchoosedtenantname", "");

																			HttpContext.Session.SetString("englishtotamilchoosedtenantid", dt.Rows[0]["tenantid"].ToString());

																			if(dt.Rows[0]["tenantid"].ToString() !="00000000-0000-0000-0000-000000000000")
																			{
																					message ="Authorization Failure. Please try again.";

																			}
																				
																			
																		
																		
																		

							//ROLE SECTION



							HttpResponseMessage response_roles = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_roleAuthorizations?viewactionroles="+dt.Rows[0]["userrole"].ToString());

							
							if (response_roles.IsSuccessStatusCode)
							{
								
								DataTable dt_roles = await response_roles.Content.ReadAsAsync<DataTable>();
								string role_JSON = await response_roles.Content.ReadAsStringAsync();
                                if(dt_roles.Rows.Count ==0){
                                        ViewData["message"]="You are not authorized to access englishtotamil , Please contact administrator";
                                        return View(model); 
                                }
            
								HttpContext.Session.SetSession("englishtotamilroles", dt_roles);
								HttpContext.Session.SetString("englishtotamilrole_JSON", role_JSON);
								

								
							} 
												


							//ROLE SECTION



							//MENU SECTION



							HttpResponseMessage response_menu = await ApiClient.GET_ApiValuesGetRespnse(client,"api/users/get_project_Menu?viewactionroles="+dt.Rows[0]["userrole"].ToString()+"&SubSystem=Admin");
							
							if (response_menu.IsSuccessStatusCode)
							{
								
								DataTable dt_menu = await response_menu.Content.ReadAsAsync<DataTable>();
								string menu_JSON = await response_menu.Content.ReadAsStringAsync();
								HttpContext.Session.SetSession("englishtotamilmenu", dt_menu);
								HttpContext.Session.SetString("englishtotamilmenu_JSON", menu_JSON);
								

								
							} 
												


							//MENU SECTION
					


                    }
                    else
                    {
                         message = "user not exists";


                    }
                }
                else
                {
                    message = "Response Failed";
                }
            }
            catch (Exception ex)
            {
               _logger.LogError("Error occured in - users / toapp , Error Message : " + ex.Message);
Console.WriteLine(ex);
                message = ex.Message;
            }
            TempData["message"] = message;
            if (message == "Login Success")
            {
                 
                 return RedirectToAction("UpdateProfile","users", new {@usersid=HttpContext.Session.GetString("englishtotamilloginUserID")});
					
            }
            else
            {

                return RedirectToAction("Login");
            }
        }
        public virtual IActionResult forgotpassword()
        {
            return View();
        }
        [HttpPost()]
        public virtual async Task<IActionResult> forgotpassword(userloginModel loginmodel)
        {
            string message = "";
            string pwd = "";
            usersModel model = new usersModel();
            try
            {

                HttpResponseMessage response_Password = await ApiClient.Post_ApiValuesGetRespnse(getHttpClient(), "api/users/get_decryptedPassword", loginmodel);


                if (response_Password.IsSuccessStatusCode)
                {
                    message = await response_Password.Content.ReadAsAsync<string>();

                    loginmodel.userpassword = message;
                    pwd = message;
                }
                loginmodel.source = "Internal";
                HttpResponseMessage response = await ApiClient.Post_ApiValuesGetRespnse(client, "api/users/checkUserAuthentication_users", loginmodel);

                if (response.IsSuccessStatusCode)
                {
                    var jsonObj = await response.Content.ReadAsStringAsync();
                    if (jsonObj.Length > 2)
                    {
                        jsonObj = jsonObj.Substring(1, jsonObj.Length - 2);
                        model = JsonConvert.DeserializeObject<usersModel>(jsonObj);
                        message = "Login Success";
                        model.userpassword = pwd;
                    }
                    else
                    {
                        message = "Login Failed";
                    }
                }
                else
                {
                    message = "Response Failed";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in - users / forgotpassword , Error Message : " + ex.Message);
Console.WriteLine(ex);
                message = ex.Message;
            }
            ViewData["message"] = "User Info not available - Please contact Admin ";
            if (message == "Login Success")
            {

                if (model.emailid != null && model.emailid != "")
                {

                    MailSender maillog = new MailSender();
                    bool mailsent = await maillog.sendMail("users"
                        , "forgotpassword"
                        , model.usersid.ToString()
                        , "Forgot Password"
                        , _mailSettings
                        , "13EF2D93-CD5C-49DB-AE70-8FB33399275C"
                        , client, model.username, model.userpassword);

                    if (mailsent)
                    {
                        ViewData["message"] = "User Info Sent to your registered email";
                    }
                    else
                    {
                        ViewData["message"] = "User Info found - Mail Sending Failed - Please contact Admin ";
                    }


                }
                else
                {
                    ViewData["message"] = "User Info found - Mail Sending Failed - Please contact Admin ";
                }



                return View(loginmodel);
            }
            else
            {
                return View(loginmodel);
            }
;
        }

			public virtual IActionResult List_of_User_Profiles()
			{
				return View();
			}
			public virtual IActionResult IndexPlatform()
					{
						 HttpContext.Session.SetString("englishtotamilchoosedtenantid","");
						return View();
					}	
			[HttpGet()]
			public virtual async Task<string> get_List_of_User_Profiles(string tenantid
)
			{
				
				return await ApiClient.Get_ApiValues(getHttpClient(), "api/users/List_of_User_Profiles?tenantid="+tenantid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID")
);
			}
			 

				
			  public virtual async Task<IActionResult> ChangePassword(string usersid)
			  {
                    string redirectTo="";
            if(HttpContext.Session.GetString("englishtotamilrole_JSON") != null){
                
			DataTable englishtotamilrole_JSON =HttpContext.Session.GetSession<DataTable>("englishtotamilroles");
			DataView dv = new DataView(englishtotamilrole_JSON);
			dv.RowFilter = "controllername='users' AND viewname='list'";

			if(dv.Count  >0){
				redirectTo = dv[0]["actionmethodname"] as string;
							 
			}	 
                    try
                        {

					    var jsonObjusers = await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_users?usersid="+usersid+"&loginUserID="+HttpContext.Session.GetString("englishtotamilloginUserID"));
					 
                     
						    jsonObjusers = jsonObjusers.Substring(1, jsonObjusers.Length - 2);
						    var model = JsonConvert.DeserializeObject<usersModel>(jsonObjusers);
						    HttpContext.Session.SetSession("englishtotamilusersModel", model);

                            usersChangePasswordModel objModel=new usersChangePasswordModel();     
                            objModel.usersid=model.usersid;
						    return View(objModel);

                        }catch(Exception ex){
                            TempData["errMessage"] = "Error while fetching data - Contact Administrator";
                            return RedirectToAction(redirectTo);
                        }
					 

                }
                TempData["errMessage"] = "Session Expired";
                return RedirectToAction("Logout","users");

			  }	
			  [HttpPost()]
				public virtual async Task<string> ChangePassword(usersChangePasswordModel model, IFormCollection collection)
				{
					string strReturnMessage = "";
					try
					{
							ModelState.Remove("usersid");
							 
							if(HttpContext.Session.GetString("englishtotamilloginUserID") != null)
					model.modifieduser =new Guid(HttpContext.Session.GetString("englishtotamilloginUserID"));
					else
					return "Session Expired";
							 
							if (ModelState.IsValid)
							{
									  
										strReturnMessage = await ApiClient.Post_ApiValuesGetString(getHttpClient(),"api/users/ChangePassword", model);
									 
							}
							else
							{
									var errorCollection = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
									strReturnMessage = errorCollection.ToString();
							}
					}
					catch (Exception ex)
					{
                        _logger.LogError("Error occured in - users / ChangePassword , Error Message : " + ex.Message);
                        Console.WriteLine(ex);
						strReturnMessage = ex.Message;
					}
					ViewData["message"] = strReturnMessage;
					    if(strReturnMessage.Replace("\"", "")=="201.1"){
							TempData["message"] = "Success";
							
							return "Success";
						}else{
							if(strReturnMessage=="401.1")
									strReturnMessage = "Authorization Failed";

							return strReturnMessage;
						}
		
				}

				
			  public virtual async Task<string> getById_sp_all_users(string usersid)
			  {
					return await ApiClient.Get_ApiValues(getHttpClient(), "api/users/getById_sp_all_users?usersid="+usersid);
					 
			  }





                    


				}


			}
