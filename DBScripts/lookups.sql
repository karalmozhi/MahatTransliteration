CREATE TABLE [system_logging](
			[system_logging_guid] [uniqueidentifier] ROWGUIDCOL  NOT NULL DEFAULT (newid()),
			[entered_date] [datetime] NOT NULL DEFAULT GETDATE(),
			[log_application] [varchar](200) NULL,
			[log_date] [varchar](100) NULL,
			[log_level] [varchar](100) NULL,
			[log_logger] [varchar](8000) NULL,
			[log_message] [varchar](8000) NULL,
			[log_machine_name] [varchar](8000) NULL,
			[log_user_name] [varchar](8000) NULL,
			[log_call_site] [varchar](8000) NULL,
			[log_thread] [varchar](100) NULL,
			[log_exception] [varchar](8000) NULL,
			[log_stacktrace] [varchar](8000) NULL,
			[ipaddress] [varchar](256) NULL,
			[Log_code] [varchar](128) NULL,
			CONSTRAINT [PK_system_logging] PRIMARY KEY CLUSTERED 
			(
			[system_logging_guid] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
			) ON [PRIMARY];
CREATE TABLE [projectstructure](
								[projectelementname] [nvarchar](128) NULL,
								[elementtype] [nvarchar](128) NULL,
								[parentnode] [nvarchar](128) NULL,
								[subsystem] [nvarchar](128) NULL,
								[structureorder] [int] NULL,
								[assignedentityname] [nvarchar](128) NULL,
								[displayicon] [nvarchar](128) NULL
							);
CREATE TABLE [roles](
										[rolesid] [uniqueidentifier] NOT NULL,
									[rolename] [nvarchar](128) NULL,
									[rolegroupname] [nvarchar](128) NULL,
									[parentname] [nvarchar](128) NULL,
									[rolehierarchynumber] [nvarchar](128) NULL
								);
CREATE TABLE [roleauthorization](
									[roleauthorizationid] [uniqueidentifier] NOT NULL,
									[controllername] [nvarchar](128) NULL,
									[actionname] [nvarchar](128) NULL,
									[viewname] [nvarchar](128) NULL,
									[viewactionroles] [nvarchar](256) NULL,
									[actiondisplayname] [nvarchar](256) NULL,
									[actionmethodname] [nvarchar](256) NULL
								);
CREATE TABLE [userlockout](
								[username] [nvarchar](150) NOT NULL,
								[lastupdateddate] [datetime] NOT NULL,
								[lockremovedby] [nvarchar](250) NULL,
								[latlan] [nvarchar](150) NULL,
								[remoteipaddress] [nvarchar](150) NULL,
								[clientipaddress] [nvarchar](150) NULL,
								[isdeleted] [bit] NULL,
								[lockoutid] [uniqueidentifier] NULL
							) ON [PRIMARY];
CREATE TABLE [lookups](
							[lookupid] [uniqueidentifier] NOT NULL,
							[entityname] [nvarchar](256) NULL,
							[attributetype] [nvarchar](256) NULL,
							[fieldname] [nvarchar](256) NULL,
							[fielddesc] [nvarchar](1024) NULL,
							[createduser] [uniqueidentifier] NULL,
							[createddate] [datetime] NULL,
							[modifieduser] [uniqueidentifier] NULL,
							[modifieddate] [datetime] NULL,
							[isdeleted] [bit] NULL,
							CONSTRAINT [PK__lookups__EF7CFD2ACFFD5FDF] PRIMARY KEY CLUSTERED 
							(
							[lookupid] ASC
							)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
							) ON [PRIMARY];
CREATE TABLE history(
												table_name varchar(50) NULL
												,log_date datetime NULL
												,log_xml xml  NULL
												);
CREATE TABLE access_logs
										(
											access_logsid uniqueidentifier NOT NULL,
											users_id varchar(256),
											logged_date datetime NOT NULL DEFAULT GETDATE(),
											expiry_date datetime NOT NULL DEFAULT GETDATE(),
											user_token nvarchar(4000),
											external_users_id varchar(256),
											external_entity_name varchar(256),
											latlan varchar(256),
											clientipaddress varchar(256),
											devicename varchar(256),
											browsername varchar(256),
											createddate datetime NOT NULL DEFAULT GETDATE(),
											modifieduser uniqueidentifier,
											modifieddate datetime,
											isdeleted bit DEFAULT 0,
											createduser uniqueidentifier NOT NULL,
											logout_date datetime,
											CONSTRAINT access_logs_pkey PRIMARY KEY (access_logsid)
										);
CREATE TABLE access_logs_details
										(
												 access_logsid uniqueidentifier NOT NULL
												,action_method_name nvarchar(256)
												,api_response nvarchar(1024)
												,accessed_date datetime NOT NULL DEFAULT GETDATE()
										);
CREATE TABLE api_access_logs
										(
										api_access_logsid uniqueidentifier NOT NULL,
										users_id varchar(256),
										logged_date datetime NOT NULL DEFAULT GETDATE(),
										user_token nvarchar(4000),
										api_url varchar(256),
										request_type varchar(256),
										request_json ntext,
										response_json ntext,
										createddate datetime NOT NULL DEFAULT GETDATE(),
										modifieduser uniqueidentifier,
										modifieddate datetime,
										isdeleted bit DEFAULT 0,
										createduser uniqueidentifier NOT NULL,
										CONSTRAINT api_access_logspkey PRIMARY KEY (api_access_logsid)
										);

