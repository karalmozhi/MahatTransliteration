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
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:59
			public class AlertTemplatesDAL
			{
				 public virtual string db_connectionstring{get;set;}
				public AlertTemplatesDAL(string connectionString)
				{
					db_connectionstring=connectionString;
				}
				  

			    public virtual string Create_Alert_Templates(AlertTemplatesModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							Database db = new SqlDatabase(db_connectionstring);
					
							using(DbCommand dbCommand = db.GetStoredProcCommand("Create_Alert_Templates"))
							{
								
													db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.Guid,model.AlertTemplatesid);

db.AddInParameter(dbCommand,"@entityname",DbType.String,model.entityname);

db.AddInParameter(dbCommand,"@entityaction",DbType.String,model.entityaction);

db.AddInParameter(dbCommand,"@sendasbatch",DbType.Boolean,model.sendasbatch);

db.AddInParameter(dbCommand,"@alerttype",DbType.String,model.alerttype);

db.AddInParameter(dbCommand,"@alertsubject",DbType.String,model.alertsubject);

db.AddInParameter(dbCommand,"@alertcopyto",DbType.String,model.alertcopyto);

db.AddInParameter(dbCommand,"@alertcarboncopyto",DbType.String,model.alertcarboncopyto);

db.AddInParameter(dbCommand,"@alertcontent",DbType.String,model.alertcontent);
db.AddInParameter(dbCommand,"@createduser",DbType.Guid,model.createduser);	
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
public virtual System.Data.DataTable getById_AlertTemplates(string AlertTemplatesid)
					 {
						DataTable dsDataTable=new DataTable();
						try{
								Database db = new SqlDatabase(db_connectionstring);
					 
								using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_AlertTemplates"))
								{

									db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.String,AlertTemplatesid);
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
			 public virtual string  Update_Alert_Templates(AlertTemplatesModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("Update_Alert_Templates"))
							{
													db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.Guid,model.AlertTemplatesid);

db.AddInParameter(dbCommand,"@entityname",DbType.String,model.entityname);

db.AddInParameter(dbCommand,"@entityaction",DbType.String,model.entityaction);

db.AddInParameter(dbCommand,"@sendasbatch",DbType.Boolean,model.sendasbatch);

db.AddInParameter(dbCommand,"@alerttype",DbType.String,model.alerttype);

db.AddInParameter(dbCommand,"@alertsubject",DbType.String,model.alertsubject);

db.AddInParameter(dbCommand,"@alertcopyto",DbType.String,model.alertcopyto);

db.AddInParameter(dbCommand,"@alertcarboncopyto",DbType.String,model.alertcarboncopyto);

db.AddInParameter(dbCommand,"@alertcontent",DbType.String,model.alertcontent);
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
					}
					
					return ResponseMessage;

			   }
public virtual string  Remove_Alert_Templates(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{
							 Database db = new SqlDatabase(db_connectionstring);
							 	
								using(DbCommand dbCommand = db.GetStoredProcCommand("Remove_Alert_Templates"))
								{

										db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.String,id);
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
public virtual System.Data.DataTable Alert_Templates_List(string entityname
,string entityaction
)
			  { 
					DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
					 

							using(DbCommand dbCommand = db.GetStoredProcCommand("Alert_Templates_List"))
							{
							
								db.AddInParameter(dbCommand,"@entityname",DbType.String,entityname);
db.AddInParameter(dbCommand,"@entityaction",DbType.String,entityaction);

								
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
			   
			 
public virtual System.Data.DataTable get_all_AlertTemplates(string tenantid)
			  { 

				    DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_all_AlertTemplates"))
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
public virtual System.Data.DataSet getById_sp_all_AlertTemplates(string AlertTemplatesid)
			 {
				DataSet dsDataSet=new DataSet();
				try{
					    Database db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_all_AlertTemplates"))
						{

							db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.String,AlertTemplatesid);
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
			  public virtual string  verify_AlertTemplates(string AlertTemplatesid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("verify_AlertTemplates"))
							{
								db.AddInParameter(dbCommand,"@AlertTemplatesid",DbType.String,AlertTemplatesid);
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
