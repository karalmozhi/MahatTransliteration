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

					public class External_System_DAL
					{
						private Database db;	
						public External_System_DAL(string connectionString)
						{
							db_connectionstring = connectionString;
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
						_connectionstring = value;
						}
						}
 
					public virtual string Create_access_logs(access_logsModel model)
					{
						String ResponseMessage = "";

						try
						{
							db = new SqlDatabase(db_connectionstring);
							using(DbCommand  dbCommand = db.GetStoredProcCommand("Create_access_logs"))
							{
							
  
								db.AddInParameter(dbCommand,"@access_logsid", DbType.Guid, model.access_logsid);

								db.AddInParameter(dbCommand,"@users_id", DbType.String, model.users_id);

								db.AddInParameter(dbCommand,"@logged_date", DbType.DateTime, model.logged_date);

								db.AddInParameter(dbCommand,"@expiry_date", DbType.DateTime, model.expiry_date);

								db.AddInParameter(dbCommand,"@user_token", DbType.String, model.user_token);


								db.AddInParameter(dbCommand,"@latlan", DbType.String, model.latlan);

								db.AddInParameter(dbCommand,"@clientipaddress", DbType.String, model.clientipaddress);

								db.AddInParameter(dbCommand,"@devicename", DbType.String, model.devicename);

								db.AddInParameter(dbCommand,"@browsername", DbType.String, model.browsername);


								db.AddInParameter(dbCommand,"@external_entity_name", DbType.String, model.external_entity_name);

								db.AddInParameter(dbCommand,"@external_users_id", DbType.String, model.external_users_id);

								db.AddInParameter(dbCommand,"@createduser", DbType.Guid, model.createduser);
								 
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
								dbCommand.Connection.Dispose();
								}

 
						}


						}
						catch (Exception ex)
						{
						ResponseMessage = ex.Message;
						}

						return ResponseMessage;

					}
public virtual string create_access_logs_details(access_logsdetailsModel model)
					{
						String ResponseMessage = "";

						try
						{
							db = new SqlDatabase(db_connectionstring);
							using(DbCommand  dbCommand = db.GetStoredProcCommand("create_access_logs_details"))
							{
							
  
								db.AddInParameter(dbCommand,"@access_logsid", DbType.Guid , model.access_logsid);

								db.AddInParameter(dbCommand,"@action_method_name", DbType.String, model.action_method_name);

								db.AddInParameter(dbCommand,"@api_response", DbType.String, model.api_response);
 								 
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
								dbCommand.Connection.Dispose();
								}

 
						}


						}
						catch (Exception ex)
						{
						ResponseMessage = ex.Message;
						}

						return ResponseMessage;

					}

					public virtual string Create_api_access_logs(access_logsModel model)
					{

						String ResponseMessage = "";

						try
						{
							db = new SqlDatabase(db_connectionstring);
							using(DbCommand  dbCommand = db.GetStoredProcCommand("Create_api_access_logs"))
							{
							
  
								db.AddInParameter(dbCommand,"@api_access_logsid", DbType.Guid, model.access_logsid);

								db.AddInParameter(dbCommand,"@users_id", DbType.String, model.users_id);

								db.AddInParameter(dbCommand,"@logged_date", DbType.DateTime, model.logged_date);

								db.AddInParameter(dbCommand,"@user_token", DbType.String, model.user_token);

								db.AddInParameter(dbCommand,"@request_type", DbType.String, model.request_type);

								db.AddInParameter(dbCommand,"@api_url", DbType.String, model.api_url);


								if (model.request_json != "")
									db.AddInParameter(dbCommand,"@request_json", DbType.String, model.request_json);
								else
									db.AddInParameter(dbCommand,"@request_json", DbType.String, DBNull.Value);


								if (model.response_json !="")
									db.AddInParameter(dbCommand,"@response_json", DbType.String, model.response_json);
								else
									db.AddInParameter(dbCommand,"@response_json", DbType.String, DBNull.Value);

								db.AddInParameter(dbCommand,"@createduser", DbType.Guid, model.createduser);
																 
								db.AddOutParameter(dbCommand,"@returnMessage",DbType.String,4000);
								db.ExecuteNonQuery(dbCommand);
								ResponseMessage = db.GetParameterValue(dbCommand, "@returnMessage").ToString();

								if (dbCommand.Connection.State != ConnectionState.Closed)
								{
								dbCommand.Connection.Dispose();
								}

 
						}


						}
						catch (Exception ex)
						{
						ResponseMessage = ex.Message;
						}

						return ResponseMessage;
 
					}

					public virtual bool get_active_token(string pvar_users_id, string pvar_external_entity_name, ref string pvar_user_token, ref string pvar_external_users_id)
        {
            bool is_token_active = false;

            DataTable dsDataTable = new DataTable();
           
            try
            {

                     db = new SqlDatabase(db_connectionstring);


                    using (DbCommand dbCommand = db.GetStoredProcCommand("get_active_token"))
                    {

                        db.AddInParameter(dbCommand, "@users_id", DbType.String, pvar_users_id);
                        db.AddInParameter(dbCommand, "@external_entity_name", DbType.String, pvar_external_entity_name);

                        dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
                        if (dbCommand.Connection.State != ConnectionState.Closed)
                        {
                            dbCommand.Connection.Dispose();
                        }
                    }


  

            }
            catch (Exception ex)
            {
                throw;
            }
            if (dsDataTable.Rows.Count > 0)
            {
                is_token_active = true;
                pvar_user_token = dsDataTable.Rows[0]["user_token"].ToString();
                pvar_external_users_id = dsDataTable.Rows[0]["external_users_id"].ToString();
            }

            return is_token_active;


        }

		public virtual String[] get_users_by_token(string user_token)
        {
            String[] userdetails = new String[2];

            DataTable dsDataTable = new DataTable();
           
            try
            {

                     db = new SqlDatabase(db_connectionstring);


                    using (DbCommand dbCommand = db.GetStoredProcCommand("get_users_by_token"))
                    {

                        db.AddInParameter(dbCommand, "@user_token", DbType.String, user_token);
          
                        dsDataTable = db.ExecuteDataSet(dbCommand).Tables[0];
                        if (dbCommand.Connection.State != ConnectionState.Closed)
                        {
                            dbCommand.Connection.Dispose();
                        }
                    }


  

            }
            catch (Exception ex)
            {
                throw;
            }
            if (dsDataTable.Rows.Count > 0)
            {
                userdetails[0] = dsDataTable.Rows[0]["users_id"].ToString();
                userdetails[1] = dsDataTable.Rows[0]["access_logsid"].ToString();
                 
            }

            return userdetails;


        }


					}
 
					}
					
