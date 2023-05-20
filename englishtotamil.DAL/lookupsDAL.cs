namespace englishtotamil.DAL
{
	using System;
	using System.Text;
	using System.Data;
	using System.Data.Common;
	using Microsoft.Practices.EnterpriseLibrary.Data;
	using englishtotamil.Models;
	using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
	//This code generated from Deliveries Powered by Mahat, Source Machine : 15.206.208.9 , Build Number : Build 14092021 #2021-09-014(Updated on 29102021 12:49) on 05/19/2023 09:16:50
	public class lookupsDAL
	{
		private Database db;	
		public lookupsDAL(string connectionString)
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
		public virtual string ins_lookups(lookupsModel model)
		{
				String ResponseMessage="";
 
					try{
							db = new SqlDatabase(db_connectionstring);

							using(DbCommand dbCommand = db.GetStoredProcCommand("ins_sp_lookups"))
							{
			
								db.AddInParameter(dbCommand,"@entityname",DbType.String,model.entityname);
								db.AddInParameter(dbCommand,"@attributetype",DbType.String,model.attributetype);
								db.AddInParameter(dbCommand,"@fieldname",DbType.String,model.fieldname);
								db.AddInParameter(dbCommand,"@fielddesc",DbType.String,model.fielddesc);
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
					} 

					return ResponseMessage;
 
		}
		public virtual System.Data.DataTable get_lookups()
		{
				DataTable dsDataTable=new DataTable();
				try{
					    db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_lookups"))
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
		public virtual System.Data.DataTable getById_lookups(string id)
		{
				DataTable dsDataTable=new DataTable();
				try{
					    db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("getById_sp_lookups"))
						{

							db.AddInParameter(dbCommand,"@lookupid",DbType.String,id);
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
		public virtual System.Data.DataTable get_lookups_by_entity(string id)
		{
				DataTable dsDataTable=new DataTable();
				try{
					    db = new SqlDatabase(db_connectionstring);
					 
						using(DbCommand dbCommand = db.GetStoredProcCommand("get_sp_lookups_by_entity"))
						{

							db.AddInParameter(dbCommand,"@entityname",DbType.String,id);
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
		public virtual System.Data.DataTable getLookUp_tenant_id()
										  {

													DataTable dsDataTable=new DataTable();
													try{
															db = new SqlDatabase(db_connectionstring);
					 
															using(DbCommand dbCommand = db.GetStoredProcCommand("get_lookUptenant_id"))
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
