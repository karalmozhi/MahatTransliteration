namespace englishtotamil.DAL{
			using System;
			using System.Text;
			using System.Data;
			using System.Data.Common;
			using Microsoft.Practices.EnterpriseLibrary.Data;
			using englishtotamil.Models;
			using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
			using EncrypDecrypt;
			using Newtonsoft.Json;
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:57
			public class usersDAL
			{
				 public virtual string db_connectionstring{get;set;}
				public usersDAL(string connectionString)
				{
					db_connectionstring=connectionString;
				}
				  

			    public virtual System.Data.DataTable getById_alloweddevices(string usersid)
			 {
					DataTable dsDataTable=new DataTable();
					try
					{
						 Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_users_alloweddevices"))
							{
								db.AddInParameter(dbCommand,"@usersid",DbType.String,usersid);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}

							}

						
					}catch{
						throw;
					}

					return dsDataTable;


			 }

public virtual string Register_Profile(usersModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							Database db = new SqlDatabase(db_connectionstring);
					
							using(DbCommand dbCommand = db.GetStoredProcCommand("Register_Profile"))
							{
								RandomStringGenerator objRandom =new RandomStringGenerator();
				string user_passwordkey = objRandom.CreateRandomPassword(8);
				string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
				model.userpassword=user_password;
				model.passwordkey=user_passwordkey;
													db.AddInParameter(dbCommand,"@usersid",DbType.Guid,model.usersid);
db.AddInParameter(dbCommand,"@tenantid",DbType.Guid,model.tenantid);

db.AddInParameter(dbCommand,"@firstname",DbType.String,model.firstname);

db.AddInParameter(dbCommand,"@lastname",DbType.String,model.lastname);

db.AddInParameter(dbCommand,"@profilepicture",DbType.String,model.profilepicture);

db.AddInParameter(dbCommand,"@username",DbType.String,model.username);

db.AddInParameter(dbCommand,"@userpassword",DbType.String,model.userpassword);

db.AddInParameter(dbCommand,"@emailid",DbType.String,model.emailid);

db.AddInParameter(dbCommand,"@mobilenumber",DbType.String,model.mobilenumber);

db.AddInParameter(dbCommand,"@userrole",DbType.String,model.userrole);
db.AddInParameter(dbCommand, "@passwordkey", DbType.String, model.passwordkey);
db.AddInParameter(dbCommand,"@createduser",DbType.Guid,model.createduser);if(model.alloweddevices !=null  && model.alloweddevices.Count >0)
db.AddInParameter(dbCommand,"@alloweddevices",DbType.String,JsonConvert.SerializeObject(model.alloweddevices));
	
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();
								if (dbCommand.Connection.State != ConnectionState.Closed)
                    			{
										 dbCommand.Connection.Dispose();
								}

							}
						

					}catch(Exception ex){
						ResponseMessage=ex.Message;
						Console.WriteLine(ex);
					} 
					
					return ResponseMessage;

			   }
public virtual System.Data.DataTable getById_users(string usersid)
					 {
						DataTable dsDataTable=new DataTable();
						try{
								Database db = new SqlDatabase(db_connectionstring);
					 
								using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_users"))
								{

									db.AddInParameter(dbCommand,"@usersid",DbType.String,usersid);
									dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
											if (dbCommand.Connection.State != ConnectionState.Closed)
                    						{
												 dbCommand.Connection.Dispose();
											}

								}
					 
						}catch{
								throw;
						}
						return dsDataTable;
					 }
			 public virtual string  Update_Profile(usersModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("Update_Profile"))
							{
													db.AddInParameter(dbCommand,"@usersid",DbType.Guid,model.usersid);
db.AddInParameter(dbCommand,"@tenantid",DbType.Guid,model.tenantid);

db.AddInParameter(dbCommand,"@firstname",DbType.String,model.firstname);

db.AddInParameter(dbCommand,"@lastname",DbType.String,model.lastname);

db.AddInParameter(dbCommand,"@profilepicture",DbType.String,model.profilepicture);

db.AddInParameter(dbCommand,"@username",DbType.String,model.username);

db.AddInParameter(dbCommand,"@emailid",DbType.String,model.emailid);

db.AddInParameter(dbCommand,"@mobilenumber",DbType.String,model.mobilenumber);

db.AddInParameter(dbCommand,"@userrole",DbType.String,model.userrole);
db.AddInParameter(dbCommand,"@modifieduser",DbType.Guid,model.modifieduser);if(model.alloweddevices !=null  && model.alloweddevices.Count >0)
db.AddInParameter(dbCommand,"@alloweddevices",DbType.String,JsonConvert.SerializeObject(model.alloweddevices));
	
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}
							}
						 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }
public virtual string  Suspend_Profile(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{
							 Database db = new SqlDatabase(db_connectionstring);
							 	
								using(DbCommand dbCommand = db.GetStoredProcCommand("Suspend_Profile"))
								{

										db.AddInParameter(dbCommand,"@usersid",DbType.String,id);
										db.AddInParameter(dbCommand,"@modifieduser",DbType.String,loginUserID);
										db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
										db.ExecuteNonQuery(dbCommand);
										ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

										if (dbCommand.Connection.State != ConnectionState.Closed)
										{
											dbCommand.Connection.Dispose();
										}

								}
							 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }

			public virtual string get_decryptedPassword(string userName)
        {

            string decryptedPassword = "";
            DataTable pwdandKey = checkUserKey_users(userName);
            if (pwdandKey.Rows.Count > 0)
            {
                string user_password = pwdandKey.Rows[0]["userpassword"].ToString();
                string user_passwordKey = pwdandKey.Rows[0]["passwordkey"].ToString();
                decryptedPassword = PwdEncrypDecrypt.Decrypt(user_passwordKey, user_password);
                //password= decryptedPassword; 

            }

            return decryptedPassword;
        }
			public virtual System.Data.DataTable get_roleAuthorizations(string viewactionroles)
			{
					DataTable dsDataTable=new DataTable();
					 
					try
					{
						    Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_roleauthorizations"))
							{
								db.AddInParameter(dbCommand,"@viewactionroles",DbType.String,viewactionroles);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
										dbCommand.Connection.Dispose();
								}
							}

						
					}
					catch{
						throw;
					} 
					return dsDataTable;	
				
			}
			public virtual System.Data.DataTable get_project_Menu(string viewactionroles,string subsystem)
			{

				   DataTable dsDataTable=new DataTable();
					try
					{
							 Database db = new SqlDatabase(db_connectionstring);
						
						    using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_project_Menu"))
							{
								db.AddInParameter(dbCommand,"@viewactionroles",DbType.String,viewactionroles);
								db.AddInParameter(dbCommand,"@subsystem",DbType.String,subsystem);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
										dbCommand.Connection.Dispose();
								}
							}

						
					}
					catch{
						throw;
					}
					return dsDataTable;	
				
			}
			public virtual System.Data.DataTable get_roles(string roles)
			{ 
 				   DataTable dsDataTable=new DataTable();
					try
					{
						    Database db = new SqlDatabase(db_connectionstring);
						 
						    using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_roles"))
							{
								db.AddInParameter(dbCommand,"@roles",DbType.String,roles);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
										dbCommand.Connection.Dispose();
								}
							}

						 
					}
					catch{
						throw;
					}
					return dsDataTable;	
			}
			public virtual System.Data.DataTable checkUserKey_users(string username)
			{
				   DataTable dsDataTable=new DataTable();
					try
					{
						 	Database db = new SqlDatabase(db_connectionstring);
						
						    using(DbCommand dbCommand = db.GetStoredProcCommand("checkUserKey_sp_users"))
							{
								db.AddInParameter(dbCommand,"@username",DbType.String,username);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
										dbCommand.Connection.Dispose();
								}
							}

						 
					}
					catch{
						throw;
					}
					return dsDataTable;	

					 
			}

			
			public virtual System.Data.DataTable checkUserAuthentication_users(userloginModel model)
				{ 
					DataTable dsDataTable=new DataTable();
					if(model.source=="Internal"){				
								DataTable pwdandKey = checkUserKey_users(model.username);
									if(pwdandKey.Rows.Count > 0)
									{
										string user_password = pwdandKey.Rows[0]["userpassword"].ToString();
										string user_passwordkey = pwdandKey.Rows[0]["passwordkey"].ToString(); 
										string decryptedPassword = PwdEncrypDecrypt.Decrypt(user_passwordkey, user_password); 
					
										if (model.userpassword == decryptedPassword)
										{
											model.userpassword = user_password;
										}
										else
										{
											return dsDataTable;
										}
									}
					}

				   
					try
					{
							if(model.userpassword !=null && model.mobilenumber !=null)
							{
								RandomStringGenerator objRandom =new RandomStringGenerator();
								string user_passwordkey = objRandom.CreateRandomPassword(8);
								string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
								model.userpassword=user_password;
								 
							}
						    Database db = new SqlDatabase(db_connectionstring);
						 
						    using(DbCommand dbCommand = db.GetStoredProcCommand("checkuser_sp_users"))
							{
								db.AddInParameter(dbCommand,"@username",DbType.String,model.username);
								db.AddInParameter(dbCommand,"@userpassword",DbType.String,model.userpassword);
								db.AddInParameter(dbCommand,"@source",DbType.String,model.source);
								db.AddInParameter(dbCommand,"@devicename",DbType.String,model.devicename);
								db.AddInParameter(dbCommand,"@deviceid",DbType.String,model.deviceid);
								db.AddInParameter(dbCommand,"@notificationid",DbType.String,model.notificationid);
								db.AddInParameter(dbCommand,"@mobilenumber",DbType.String,model.mobilenumber);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];

									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}
							}

						 
					}
					catch{
						throw;
					}
					return dsDataTable;	

			}
public virtual System.Data.DataTable List_of_User_Profiles(string tenantid
)
			  { 
					DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
					 

							using(DbCommand dbCommand = db.GetStoredProcCommand("List_of_User_Profiles"))
							{
							
								db.AddInParameter(dbCommand,"@tenantid",DbType.String,tenantid);

								
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];

									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}
							}

						 

					}catch{
						throw;
					}


					return dsDataTable;	


					 

			   }
			   
			 
public virtual System.Data.DataTable get_all_users(string tenantid)
			  { 

				    DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_all_users"))
							{
								
								
								
								db.AddInParameter(dbCommand,"@tenantid",DbType.String,tenantid);
								dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];

									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}

							}
						

					}catch{
						throw;
					}
					return dsDataTable;	


					 

			   }
	public virtual string ChangePassword(usersChangePasswordModel  model)
	                                            { 
		                                            String ResponseMessage="";

		                                            try{
		                                            Database db = new SqlDatabase(db_connectionstring);

		                                            using(DbCommand dbCommand = db.GetStoredProcCommand("ChangePassword"))
		                                            {
		                                            RandomStringGenerator objRandom =new RandomStringGenerator();
		                                            string user_passwordkey = objRandom.CreateRandomPassword(8);
		                                            string user_password = PwdEncrypDecrypt.Encrypt(user_passwordkey,model.userpassword);
		                                            model.userpassword=user_password;
		                                            model.passwordkey=user_passwordkey;

		                                            db.AddInParameter(dbCommand,"@usersid",DbType.Guid,model.usersid);
		                                            db.AddInParameter(dbCommand,"@userpassword",DbType.String,model.userpassword);


		                                            db.AddInParameter(dbCommand,"@passwordkey",DbType.String,model.passwordkey);

		                                            db.AddInParameter(dbCommand,"@modifieduser",DbType.Guid,model.modifieduser);


		                                            db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
		                                            db.ExecuteNonQuery(dbCommand);
		                                            ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();
		                                            if (dbCommand.Connection.State != ConnectionState.Closed)
		                                            {
		                                            dbCommand.Connection.Dispose();
		                                            }
		                                            }


		                                            }catch(Exception ex){
		                                            ResponseMessage=ex.Message;
																	Console.WriteLine(ex);
		                                            } 

		                                            return ResponseMessage;

	                                            }
public virtual System.Data.DataSet getById_sp_all_users(string usersid)
			 {
				DataSet dsDataSet=new DataSet();
				try{
					    Database db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_all_users"))
						{

							db.AddInParameter(dbCommand,"@usersid",DbType.String,usersid);
							dsDataSet = db.ExecuteDataSet(dbCommand);
									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}

						}
					 
				}catch{
						throw;
				}
				return dsDataSet;
			 }
			  public virtual string  verify_users(string usersid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("verify_users"))
							{
								db.AddInParameter(dbCommand,"@usersid",DbType.String,usersid);
								db.AddInParameter(dbCommand,"@verifiedby",DbType.String,verifiedby);
								db.AddInParameter(dbCommand,"@verifiedstatus",DbType.String,verifiedstatus);
								db.AddInParameter(dbCommand,"@reviewcomments",DbType.String,reviewcomments); 	
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

									if (dbCommand.Connection.State != ConnectionState.Closed)
                    				{
										 dbCommand.Connection.Dispose();
									}
							}
						 

					}catch(Exception ex){
						ResponseMessage=ex.Message;
					}
					
					return ResponseMessage;

			   }








			}


			}
