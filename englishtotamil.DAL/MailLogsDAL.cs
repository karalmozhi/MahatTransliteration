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
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:17:01
			public class MailLogsDAL
			{
				 public virtual string db_connectionstring{get;set;}
				public MailLogsDAL(string connectionString)
				{
					db_connectionstring=connectionString;
				}
				  

			    public virtual System.Data.DataTable MailSender(string mailfor,string entityid,string createduser)
								{

									DataTable dsDataTable = new DataTable();

									try
									{

										Database db = new SqlDatabase(db_connectionstring);

										using (DbCommand dbCommand = db.GetStoredProcCommand("MailSender"))
										{



											db.AddInParameter(dbCommand, "@mailfor", DbType.String, mailfor);
											db.AddInParameter(dbCommand, "@entityid", DbType.String, entityid);
											db.AddInParameter(dbCommand, "@createduser", DbType.String, createduser);

					
											dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];

											if (dbCommand.Connection.State != ConnectionState.Closed)
											{
												dbCommand.Connection.Dispose();
											}

										}


									}
									catch
									{
										throw;
									}
									return dsDataTable;




								}
public virtual string Create_MailLog(MailLogsModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							Database db = new SqlDatabase(db_connectionstring);
					
							using(DbCommand dbCommand = db.GetStoredProcCommand("Create_MailLog"))
							{
								
													db.AddInParameter(dbCommand,"@MailLogsid",DbType.Guid,model.MailLogsid);

db.AddInParameter(dbCommand,"@entityname",DbType.String,model.entityname);

db.AddInParameter(dbCommand,"@entityid",DbType.String,model.entityid);

db.AddInParameter(dbCommand,"@mailfor",DbType.String,model.mailfor);

db.AddInParameter(dbCommand,"@mailsubject",DbType.String,model.mailsubject);

db.AddInParameter(dbCommand,"@mailto",DbType.String,model.mailto);

db.AddInParameter(dbCommand,"@mailbody",DbType.String,model.mailbody);

db.AddInParameter(dbCommand,"@issent",DbType.Boolean,model.issent);
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
public virtual System.Data.DataTable getById_MailLogs(string MailLogsid)
					 {
						DataTable dsDataTable=new DataTable();
						try{
								Database db = new SqlDatabase(db_connectionstring);
					 
								using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_MailLogs"))
								{

									db.AddInParameter(dbCommand,"@MailLogsid",DbType.String,MailLogsid);
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
			 public virtual string  Update_MailLog(MailLogsModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("Update_MailLog"))
							{
													db.AddInParameter(dbCommand,"@MailLogsid",DbType.Guid,model.MailLogsid);

db.AddInParameter(dbCommand,"@entityname",DbType.String,model.entityname);

db.AddInParameter(dbCommand,"@entityid",DbType.String,model.entityid);

db.AddInParameter(dbCommand,"@mailfor",DbType.String,model.mailfor);

db.AddInParameter(dbCommand,"@mailsubject",DbType.String,model.mailsubject);

db.AddInParameter(dbCommand,"@mailto",DbType.String,model.mailto);

db.AddInParameter(dbCommand,"@mailbody",DbType.String,model.mailbody);

db.AddInParameter(dbCommand,"@issent",DbType.Boolean,model.issent);
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
public virtual string  Remove_MailLog(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{
							 Database db = new SqlDatabase(db_connectionstring);
							 	
								using(DbCommand dbCommand = db.GetStoredProcCommand("Remove_MailLog"))
								{

										db.AddInParameter(dbCommand,"@MailLogsid",DbType.String,id);
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
public virtual System.Data.DataTable MailLogs_List(string entityname
)
			  { 
					DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
					 

							using(DbCommand dbCommand = db.GetStoredProcCommand("MailLogs_List"))
							{
							
								db.AddInParameter(dbCommand,"@entityname",DbType.String,entityname);

								
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
			   
			 
public virtual System.Data.DataTable get_all_MailLogs(string tenantid)
			  { 

				    DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_all_MailLogs"))
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
public virtual System.Data.DataSet getById_sp_all_MailLogs(string MailLogsid)
			 {
				DataSet dsDataSet=new DataSet();
				try{
					    Database db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_all_MailLogs"))
						{

							db.AddInParameter(dbCommand,"@MailLogsid",DbType.String,MailLogsid);
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
			  public virtual string  verify_MailLogs(string MailLogsid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("verify_MailLogs"))
							{
								db.AddInParameter(dbCommand,"@MailLogsid",DbType.String,MailLogsid);
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
