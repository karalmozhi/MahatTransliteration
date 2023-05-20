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
			//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:58
			public class tenantDAL
			{
				 public virtual string db_connectionstring{get;set;}
				public tenantDAL(string connectionString)
				{
					db_connectionstring=connectionString;
				}
				  

			    public virtual string Create_tenant(tenantModel model)
			  { 
				  String ResponseMessage="";
					 
					try{
							Database db = new SqlDatabase(db_connectionstring);
					
							using(DbCommand dbCommand = db.GetStoredProcCommand("Create_tenant"))
							{
								
													db.AddInParameter(dbCommand,"@tenantid",DbType.Guid,model.tenantid);

db.AddInParameter(dbCommand,"@businessname",DbType.String,model.businessname);

db.AddInParameter(dbCommand,"@businessemail",DbType.String,model.businessemail);

db.AddInParameter(dbCommand,"@businessphone",DbType.String,model.businessphone);

db.AddInParameter(dbCommand,"@businesswebsite",DbType.String,model.businesswebsite);

db.AddInParameter(dbCommand,"@organizationlogo",DbType.String,model.organizationlogo);

db.AddInParameter(dbCommand,"@numberofemployees",DbType.Int32,model.numberofemployees);

db.AddInParameter(dbCommand,"@addressline1",DbType.String,model.addressline1);

db.AddInParameter(dbCommand,"@addressline2",DbType.String,model.addressline2);

db.AddInParameter(dbCommand,"@city",DbType.String,model.city);

db.AddInParameter(dbCommand,"@state",DbType.String,model.state);

db.AddInParameter(dbCommand,"@zip",DbType.String,model.zip);

db.AddInParameter(dbCommand,"@country",DbType.String,model.country);
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
public virtual System.Data.DataTable getById_tenant(string tenantid)
					 {
						DataTable dsDataTable=new DataTable();
						try{
								Database db = new SqlDatabase(db_connectionstring);
					 
								using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_tenant"))
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
			 public virtual string  Update_tenant(tenantModel model)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("Update_tenant"))
							{
													db.AddInParameter(dbCommand,"@tenantid",DbType.Guid,model.tenantid);

db.AddInParameter(dbCommand,"@businessname",DbType.String,model.businessname);

db.AddInParameter(dbCommand,"@businessemail",DbType.String,model.businessemail);

db.AddInParameter(dbCommand,"@businessphone",DbType.String,model.businessphone);

db.AddInParameter(dbCommand,"@businesswebsite",DbType.String,model.businesswebsite);

db.AddInParameter(dbCommand,"@organizationlogo",DbType.String,model.organizationlogo);

db.AddInParameter(dbCommand,"@numberofemployees",DbType.Int32,model.numberofemployees);

db.AddInParameter(dbCommand,"@addressline1",DbType.String,model.addressline1);

db.AddInParameter(dbCommand,"@addressline2",DbType.String,model.addressline2);

db.AddInParameter(dbCommand,"@city",DbType.String,model.city);

db.AddInParameter(dbCommand,"@state",DbType.String,model.state);

db.AddInParameter(dbCommand,"@zip",DbType.String,model.zip);

db.AddInParameter(dbCommand,"@country",DbType.String,model.country);
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
public virtual string  Remove_tenant(string id,string loginUserID)
			  { 
				  String ResponseMessage="";
					try{
							 Database db = new SqlDatabase(db_connectionstring);
							 	
								using(DbCommand dbCommand = db.GetStoredProcCommand("Remove_tenant"))
								{

										db.AddInParameter(dbCommand,"@tenantid",DbType.String,id);
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
public virtual System.Data.DataTable ViewList_tenant()
			  { 
					DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
					 

							using(DbCommand dbCommand = db.GetStoredProcCommand("ViewList_tenant"))
							{
							
								
								
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
			   
			 
public virtual System.Data.DataTable get_all_tenant(string tenantid)
			  { 

				    DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_all_tenant"))
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
public virtual System.Data.DataTable get_project_tenant()
			  { 
					DataTable dsDataTable=new DataTable(); 

					try{

						 Database db = new SqlDatabase(db_connectionstring);
					 

							using(DbCommand dbCommand = db.GetStoredProcCommand("get_project_tenant"))
							{
							   
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
			   
			 
public virtual System.Data.DataSet getById_sp_all_tenant(string tenantid)
			 {
				DataSet dsDataSet=new DataSet();
				try{
					    Database db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_all_tenant"))
						{

							db.AddInParameter(dbCommand,"@tenantid",DbType.String,tenantid);
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
			  public virtual string  verify_tenant(string tenantid,string verifiedby,string verifiedstatus,string reviewcomments)
			 { 
				 String ResponseMessage="";
					try{
						 	Database db = new SqlDatabase(db_connectionstring);
						
							using(DbCommand dbCommand = db.GetStoredProcCommand("verify_tenant"))
							{
								db.AddInParameter(dbCommand,"@tenantid",DbType.String,tenantid);
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
