namespace englishtotamil.DAL{
					using System;
					using System.Text;
					using System.Data;
					using System.Data.Common;
					using Microsoft.Practices.EnterpriseLibrary.Data;
					using englishtotamil.Models;
					using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
					using EncrypDecrypt;
					//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:50
					public class userlockoutDAL
					{
					private Database db;		
					public userlockoutDAL(string connectionString)
					{
						db_connectionstring=connectionString;
					}
				 
					private string _connectionstring;
					public virtual string db_connectionstring
					{
						get
						{
							return _connectionstring;
						}
						set
						{
							_connectionstring=value;
						}
					}



					public virtual string  ins_userlockout(userlockoutModel model)
					{ 
						string ResponseMessage="";
						try{

							 		db = new SqlDatabase(db_connectionstring);
							  

									using(DbCommand  dbCommand = db.GetStoredProcCommand("ins_sp_userlockout"))
									{

										db.AddInParameter(dbCommand,"@username",DbType.String,model.username);
										db.AddInParameter(dbCommand,"@latlan",DbType.String,model.latlan);
										db.AddInParameter(dbCommand,"@remoteipaddress",DbType.String,model.remoteipaddress);
										db.AddInParameter(dbCommand,"@clientipaddress",DbType.String,model.clientipaddress);


										db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
										db.ExecuteNonQuery(dbCommand);
										ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

									
									}

							 
								
						 }
						 catch(Exception ex)
						 {
								ResponseMessage=ex.Message;
								
						 }
							 

						return ResponseMessage;

					}



					public virtual string  verify_userlockout(userlockoutModel model)
					{ 

							string ResponseMessage="";
							
							try{

									 db = new SqlDatabase(db_connectionstring);
							 	 
									using(DbCommand dbCommand = db.GetStoredProcCommand("verify_sp_userlockout"))
									{

										db.AddInParameter(dbCommand,"@username",DbType.String,model.username);


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

					public virtual string  upd_userlockout(userlockoutModel model)
					{ 
						string ResponseMessage="";
						try{

							 		db = new SqlDatabase(db_connectionstring);
							 
									using(DbCommand dbCommand = db.GetStoredProcCommand("upd_sp_userlockout"))
									{

										db.AddInParameter(dbCommand,"@lockoutid",DbType.String,model.lockoutid);
										db.AddInParameter(dbCommand,"@loginUser",DbType.String,model.loginUser);


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

					public virtual System.Data.DataTable get_userlockout()
					{

									DataTable dsDataTable=new DataTable();
									try{
										 db = new SqlDatabase(db_connectionstring);
										 
											
											using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_userlockout"))
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



					}


					}
					
