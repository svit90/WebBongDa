﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="wcweb")]
	public partial class DataBongDaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataBongDaDataContext() : 
				base(global::Library.Properties.Settings.Default.wcwebConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataBongDaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBongDaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBongDaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataBongDaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.[_062021_bongda_Get_All_FCTeam]")]
		public ISingleResult<_062021_bongda_Get_All_FCTeamResult> _062021_bongda_Get_All_FCTeam()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<_062021_bongda_Get_All_FCTeamResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.[_0620_wc_GetStaff_ByRowId]")]
		public ISingleResult<_0620_wc_GetStaff_ByRowIdResult> _0620_wc_GetStaff_ByRowId([global::System.Data.Linq.Mapping.ParameterAttribute(Name="StaffRowId", DbType="VarChar(MAX)")] string staffRowId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), staffRowId);
			return ((ISingleResult<_0620_wc_GetStaff_ByRowIdResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.[_062021_bongda_Get_Match_Details]")]
		public ISingleResult<_062021_bongda_Get_Match_DetailsResult> _062021_bongda_Get_Match_Details([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Mode", DbType="NVarChar(100)")] string mode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MacthId", DbType="Int")] System.Nullable<int> macthId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), mode, macthId);
			return ((ISingleResult<_062021_bongda_Get_Match_DetailsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.[_062021_bongda_Get_Match]")]
		public ISingleResult<_062021_bongda_Get_MatchResult> _062021_bongda_Get_Match([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Mode", DbType="NVarChar(100)")] string mode, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MacthId", DbType="Int")] System.Nullable<int> macthId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), mode, macthId);
			return ((ISingleResult<_062021_bongda_Get_MatchResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.[_062021_bongda_Get_After_Match]")]
		public ISingleResult<_062021_bongda_Get_After_MatchResult> _062021_bongda_Get_After_Match([global::System.Data.Linq.Mapping.ParameterAttribute(Name="MacthId", DbType="Int")] System.Nullable<int> macthId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), macthId);
			return ((ISingleResult<_062021_bongda_Get_After_MatchResult>)(result.ReturnValue));
		}
	}
	
	public partial class _062021_bongda_Get_All_FCTeamResult
	{
		
		private int _FBT_ID;
		
		private string _FBT_NAME;
		
		private string _FBT_FLAG;
		
		private string _FBT_NOTE;
		
		private System.Nullable<int> _FLAG_ACTIVE;
		
		public _062021_bongda_Get_All_FCTeamResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FBT_ID", DbType="Int NOT NULL")]
		public int FBT_ID
		{
			get
			{
				return this._FBT_ID;
			}
			set
			{
				if ((this._FBT_ID != value))
				{
					this._FBT_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FBT_NAME", DbType="NVarChar(200)")]
		public string FBT_NAME
		{
			get
			{
				return this._FBT_NAME;
			}
			set
			{
				if ((this._FBT_NAME != value))
				{
					this._FBT_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FBT_FLAG", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string FBT_FLAG
		{
			get
			{
				return this._FBT_FLAG;
			}
			set
			{
				if ((this._FBT_FLAG != value))
				{
					this._FBT_FLAG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FBT_NOTE", DbType="NVarChar(200)")]
		public string FBT_NOTE
		{
			get
			{
				return this._FBT_NOTE;
			}
			set
			{
				if ((this._FBT_NOTE != value))
				{
					this._FBT_NOTE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE
		{
			get
			{
				return this._FLAG_ACTIVE;
			}
			set
			{
				if ((this._FLAG_ACTIVE != value))
				{
					this._FLAG_ACTIVE = value;
				}
			}
		}
	}
	
	public partial class _0620_wc_GetStaff_ByRowIdResult
	{
		
		private int _STAFF_ID;
		
		private string _STAFF_NAME;
		
		private string _STAFF_NAME_OTHER;
		
		private System.Nullable<System.DateTime> _STAFF_BIRTH;
		
		private string _STAFF_EMAIL;
		
		private string _STAFF_PASS_CRM;
		
		private string _STAFF_PASS_EMAIL;
		
		private string _STAFF_PERMISSION;
		
		private string _STAFF_AVATAR_LINK;
		
		private string _STAFF_PHONE;
		
		private string _STAFF_NOTE;
		
		private string _STAFF_POSITION;
		
		private string _EMAIL_HEADER;
		
		private string _SIGNATURE_EMAIL;
		
		private string _STAFF_OFFICE;
		
		private string _STAFF_GROUP;
		
		private string _STAFF_GROUP_ON;
		
		private System.Nullable<int> _FLAG_ACTIVE;
		
		private System.Nullable<System.DateTime> _INSERT_DATE;
		
		private System.Nullable<System.DateTime> _UPDATE_DATE;
		
		private string _PRODUCT_SALE;
		
		private string _STAFF_TEAM;
		
		private System.Guid _ROWID;
		
		private string _RE_LINK;
		
		private string _APP_PASS;
		
		private string _TWOSTEP_ENROLL;
		
		private string _STAFF_GENDER;
		
		private System.Nullable<System.DateTime> _DATE_SYNC;
		
		private int _USER_ID;
		
		private string _USER_NAME;
		
		private string _USER_EMAIL;
		
		private string _USER_PASS;
		
		private string _USER_MONEY;
		
		private System.Nullable<int> _FLAG_ACTIVE1;
		
		private string _NOTE1;
		
		public _0620_wc_GetStaff_ByRowIdResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_ID", DbType="Int NOT NULL")]
		public int STAFF_ID
		{
			get
			{
				return this._STAFF_ID;
			}
			set
			{
				if ((this._STAFF_ID != value))
				{
					this._STAFF_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_NAME", DbType="NVarChar(200)")]
		public string STAFF_NAME
		{
			get
			{
				return this._STAFF_NAME;
			}
			set
			{
				if ((this._STAFF_NAME != value))
				{
					this._STAFF_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_NAME_OTHER", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string STAFF_NAME_OTHER
		{
			get
			{
				return this._STAFF_NAME_OTHER;
			}
			set
			{
				if ((this._STAFF_NAME_OTHER != value))
				{
					this._STAFF_NAME_OTHER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_BIRTH", DbType="DateTime")]
		public System.Nullable<System.DateTime> STAFF_BIRTH
		{
			get
			{
				return this._STAFF_BIRTH;
			}
			set
			{
				if ((this._STAFF_BIRTH != value))
				{
					this._STAFF_BIRTH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_EMAIL", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string STAFF_EMAIL
		{
			get
			{
				return this._STAFF_EMAIL;
			}
			set
			{
				if ((this._STAFF_EMAIL != value))
				{
					this._STAFF_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_PASS_CRM", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string STAFF_PASS_CRM
		{
			get
			{
				return this._STAFF_PASS_CRM;
			}
			set
			{
				if ((this._STAFF_PASS_CRM != value))
				{
					this._STAFF_PASS_CRM = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_PASS_EMAIL", DbType="NVarChar(200)")]
		public string STAFF_PASS_EMAIL
		{
			get
			{
				return this._STAFF_PASS_EMAIL;
			}
			set
			{
				if ((this._STAFF_PASS_EMAIL != value))
				{
					this._STAFF_PASS_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_PERMISSION", DbType="NVarChar(50)")]
		public string STAFF_PERMISSION
		{
			get
			{
				return this._STAFF_PERMISSION;
			}
			set
			{
				if ((this._STAFF_PERMISSION != value))
				{
					this._STAFF_PERMISSION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_AVATAR_LINK", DbType="NVarChar(MAX)")]
		public string STAFF_AVATAR_LINK
		{
			get
			{
				return this._STAFF_AVATAR_LINK;
			}
			set
			{
				if ((this._STAFF_AVATAR_LINK != value))
				{
					this._STAFF_AVATAR_LINK = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_PHONE", DbType="NVarChar(50)")]
		public string STAFF_PHONE
		{
			get
			{
				return this._STAFF_PHONE;
			}
			set
			{
				if ((this._STAFF_PHONE != value))
				{
					this._STAFF_PHONE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_NOTE", DbType="NVarChar(MAX)")]
		public string STAFF_NOTE
		{
			get
			{
				return this._STAFF_NOTE;
			}
			set
			{
				if ((this._STAFF_NOTE != value))
				{
					this._STAFF_NOTE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_POSITION", DbType="NVarChar(50)")]
		public string STAFF_POSITION
		{
			get
			{
				return this._STAFF_POSITION;
			}
			set
			{
				if ((this._STAFF_POSITION != value))
				{
					this._STAFF_POSITION = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL_HEADER", DbType="NVarChar(MAX)")]
		public string EMAIL_HEADER
		{
			get
			{
				return this._EMAIL_HEADER;
			}
			set
			{
				if ((this._EMAIL_HEADER != value))
				{
					this._EMAIL_HEADER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SIGNATURE_EMAIL", DbType="NVarChar(MAX)")]
		public string SIGNATURE_EMAIL
		{
			get
			{
				return this._SIGNATURE_EMAIL;
			}
			set
			{
				if ((this._SIGNATURE_EMAIL != value))
				{
					this._SIGNATURE_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_OFFICE", DbType="NVarChar(50)")]
		public string STAFF_OFFICE
		{
			get
			{
				return this._STAFF_OFFICE;
			}
			set
			{
				if ((this._STAFF_OFFICE != value))
				{
					this._STAFF_OFFICE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_GROUP", DbType="NVarChar(50)")]
		public string STAFF_GROUP
		{
			get
			{
				return this._STAFF_GROUP;
			}
			set
			{
				if ((this._STAFF_GROUP != value))
				{
					this._STAFF_GROUP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_GROUP_ON", DbType="NVarChar(50)")]
		public string STAFF_GROUP_ON
		{
			get
			{
				return this._STAFF_GROUP_ON;
			}
			set
			{
				if ((this._STAFF_GROUP_ON != value))
				{
					this._STAFF_GROUP_ON = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE
		{
			get
			{
				return this._FLAG_ACTIVE;
			}
			set
			{
				if ((this._FLAG_ACTIVE != value))
				{
					this._FLAG_ACTIVE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_INSERT_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> INSERT_DATE
		{
			get
			{
				return this._INSERT_DATE;
			}
			set
			{
				if ((this._INSERT_DATE != value))
				{
					this._INSERT_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPDATE_DATE", DbType="DateTime")]
		public System.Nullable<System.DateTime> UPDATE_DATE
		{
			get
			{
				return this._UPDATE_DATE;
			}
			set
			{
				if ((this._UPDATE_DATE != value))
				{
					this._UPDATE_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRODUCT_SALE", DbType="NVarChar(50)")]
		public string PRODUCT_SALE
		{
			get
			{
				return this._PRODUCT_SALE;
			}
			set
			{
				if ((this._PRODUCT_SALE != value))
				{
					this._PRODUCT_SALE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_TEAM", DbType="NVarChar(50)")]
		public string STAFF_TEAM
		{
			get
			{
				return this._STAFF_TEAM;
			}
			set
			{
				if ((this._STAFF_TEAM != value))
				{
					this._STAFF_TEAM = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROWID", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ROWID
		{
			get
			{
				return this._ROWID;
			}
			set
			{
				if ((this._ROWID != value))
				{
					this._ROWID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RE_LINK", DbType="NVarChar(MAX)")]
		public string RE_LINK
		{
			get
			{
				return this._RE_LINK;
			}
			set
			{
				if ((this._RE_LINK != value))
				{
					this._RE_LINK = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APP_PASS", DbType="NVarChar(MAX)")]
		public string APP_PASS
		{
			get
			{
				return this._APP_PASS;
			}
			set
			{
				if ((this._APP_PASS != value))
				{
					this._APP_PASS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TWOSTEP_ENROLL", DbType="NVarChar(MAX)")]
		public string TWOSTEP_ENROLL
		{
			get
			{
				return this._TWOSTEP_ENROLL;
			}
			set
			{
				if ((this._TWOSTEP_ENROLL != value))
				{
					this._TWOSTEP_ENROLL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STAFF_GENDER", DbType="NVarChar(10)")]
		public string STAFF_GENDER
		{
			get
			{
				return this._STAFF_GENDER;
			}
			set
			{
				if ((this._STAFF_GENDER != value))
				{
					this._STAFF_GENDER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DATE_SYNC", DbType="DateTime")]
		public System.Nullable<System.DateTime> DATE_SYNC
		{
			get
			{
				return this._DATE_SYNC;
			}
			set
			{
				if ((this._DATE_SYNC != value))
				{
					this._DATE_SYNC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ID", DbType="Int NOT NULL")]
		public int USER_ID
		{
			get
			{
				return this._USER_ID;
			}
			set
			{
				if ((this._USER_ID != value))
				{
					this._USER_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME", DbType="NVarChar(200)")]
		public string USER_NAME
		{
			get
			{
				return this._USER_NAME;
			}
			set
			{
				if ((this._USER_NAME != value))
				{
					this._USER_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_EMAIL", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string USER_EMAIL
		{
			get
			{
				return this._USER_EMAIL;
			}
			set
			{
				if ((this._USER_EMAIL != value))
				{
					this._USER_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_PASS", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string USER_PASS
		{
			get
			{
				return this._USER_PASS;
			}
			set
			{
				if ((this._USER_PASS != value))
				{
					this._USER_PASS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_MONEY", DbType="NVarChar(150)")]
		public string USER_MONEY
		{
			get
			{
				return this._USER_MONEY;
			}
			set
			{
				if ((this._USER_MONEY != value))
				{
					this._USER_MONEY = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE1", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE1
		{
			get
			{
				return this._FLAG_ACTIVE1;
			}
			set
			{
				if ((this._FLAG_ACTIVE1 != value))
				{
					this._FLAG_ACTIVE1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOTE1", DbType="NVarChar(MAX)")]
		public string NOTE1
		{
			get
			{
				return this._NOTE1;
			}
			set
			{
				if ((this._NOTE1 != value))
				{
					this._NOTE1 = value;
				}
			}
		}
	}
	
	public partial class _062021_bongda_Get_Match_DetailsResult
	{
		
		private int _MTCH_ID;
		
		private string _MTCH_DATE;
		
		private string _MTCH_HH;
		
		private string _MTCH_MM;
		
		private int _TEAM_1;
		
		private int _TEAM_2;
		
		private int _TYSO_1;
		
		private int _TYSO_2;
		
		private string _KEO_1;
		
		private string _KEO_2;
		
		private string _MTCH_NOTE;
		
		private System.Nullable<int> _FLAG_ACTIVE;
		
		private int _MTCHD_ID;
		
		private int _MTCH_ID1;
		
		private string _USER_EMAIL;
		
		private System.Nullable<int> _TEAM_ID;
		
		private string _MTCHD_NOTE;
		
		private System.Nullable<int> _FLAG_ACTIVE1;
		
		private string _Voted;
		
		private int _USER_ID;
		
		private string _USER_NAME;
		
		private string _USER_EMAIL1;
		
		private string _USER_PASS;
		
		private string _USER_MONEY;
		
		private System.Nullable<int> _FLAG_ACTIVE2;
		
		private string _NOTE1;
		
		public _062021_bongda_Get_Match_DetailsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_ID", DbType="Int NOT NULL")]
		public int MTCH_ID
		{
			get
			{
				return this._MTCH_ID;
			}
			set
			{
				if ((this._MTCH_ID != value))
				{
					this._MTCH_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_DATE", DbType="NVarChar(200)")]
		public string MTCH_DATE
		{
			get
			{
				return this._MTCH_DATE;
			}
			set
			{
				if ((this._MTCH_DATE != value))
				{
					this._MTCH_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_HH", DbType="NVarChar(10)")]
		public string MTCH_HH
		{
			get
			{
				return this._MTCH_HH;
			}
			set
			{
				if ((this._MTCH_HH != value))
				{
					this._MTCH_HH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_MM", DbType="NVarChar(10)")]
		public string MTCH_MM
		{
			get
			{
				return this._MTCH_MM;
			}
			set
			{
				if ((this._MTCH_MM != value))
				{
					this._MTCH_MM = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAM_1", DbType="Int NOT NULL")]
		public int TEAM_1
		{
			get
			{
				return this._TEAM_1;
			}
			set
			{
				if ((this._TEAM_1 != value))
				{
					this._TEAM_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAM_2", DbType="Int NOT NULL")]
		public int TEAM_2
		{
			get
			{
				return this._TEAM_2;
			}
			set
			{
				if ((this._TEAM_2 != value))
				{
					this._TEAM_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TYSO_1", DbType="Int NOT NULL")]
		public int TYSO_1
		{
			get
			{
				return this._TYSO_1;
			}
			set
			{
				if ((this._TYSO_1 != value))
				{
					this._TYSO_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TYSO_2", DbType="Int NOT NULL")]
		public int TYSO_2
		{
			get
			{
				return this._TYSO_2;
			}
			set
			{
				if ((this._TYSO_2 != value))
				{
					this._TYSO_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KEO_1", DbType="NVarChar(50)")]
		public string KEO_1
		{
			get
			{
				return this._KEO_1;
			}
			set
			{
				if ((this._KEO_1 != value))
				{
					this._KEO_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KEO_2", DbType="NVarChar(50)")]
		public string KEO_2
		{
			get
			{
				return this._KEO_2;
			}
			set
			{
				if ((this._KEO_2 != value))
				{
					this._KEO_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_NOTE", DbType="NVarChar(MAX)")]
		public string MTCH_NOTE
		{
			get
			{
				return this._MTCH_NOTE;
			}
			set
			{
				if ((this._MTCH_NOTE != value))
				{
					this._MTCH_NOTE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE
		{
			get
			{
				return this._FLAG_ACTIVE;
			}
			set
			{
				if ((this._FLAG_ACTIVE != value))
				{
					this._FLAG_ACTIVE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCHD_ID", DbType="Int NOT NULL")]
		public int MTCHD_ID
		{
			get
			{
				return this._MTCHD_ID;
			}
			set
			{
				if ((this._MTCHD_ID != value))
				{
					this._MTCHD_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_ID1", DbType="Int NOT NULL")]
		public int MTCH_ID1
		{
			get
			{
				return this._MTCH_ID1;
			}
			set
			{
				if ((this._MTCH_ID1 != value))
				{
					this._MTCH_ID1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_EMAIL", DbType="NVarChar(MAX)")]
		public string USER_EMAIL
		{
			get
			{
				return this._USER_EMAIL;
			}
			set
			{
				if ((this._USER_EMAIL != value))
				{
					this._USER_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAM_ID", DbType="Int")]
		public System.Nullable<int> TEAM_ID
		{
			get
			{
				return this._TEAM_ID;
			}
			set
			{
				if ((this._TEAM_ID != value))
				{
					this._TEAM_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCHD_NOTE", DbType="NVarChar(200)")]
		public string MTCHD_NOTE
		{
			get
			{
				return this._MTCHD_NOTE;
			}
			set
			{
				if ((this._MTCHD_NOTE != value))
				{
					this._MTCHD_NOTE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE1", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE1
		{
			get
			{
				return this._FLAG_ACTIVE1;
			}
			set
			{
				if ((this._FLAG_ACTIVE1 != value))
				{
					this._FLAG_ACTIVE1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Voted", DbType="NVarChar(50)")]
		public string Voted
		{
			get
			{
				return this._Voted;
			}
			set
			{
				if ((this._Voted != value))
				{
					this._Voted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ID", DbType="Int NOT NULL")]
		public int USER_ID
		{
			get
			{
				return this._USER_ID;
			}
			set
			{
				if ((this._USER_ID != value))
				{
					this._USER_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME", DbType="NVarChar(200)")]
		public string USER_NAME
		{
			get
			{
				return this._USER_NAME;
			}
			set
			{
				if ((this._USER_NAME != value))
				{
					this._USER_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_EMAIL1", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string USER_EMAIL1
		{
			get
			{
				return this._USER_EMAIL1;
			}
			set
			{
				if ((this._USER_EMAIL1 != value))
				{
					this._USER_EMAIL1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_PASS", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string USER_PASS
		{
			get
			{
				return this._USER_PASS;
			}
			set
			{
				if ((this._USER_PASS != value))
				{
					this._USER_PASS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_MONEY", DbType="NVarChar(150)")]
		public string USER_MONEY
		{
			get
			{
				return this._USER_MONEY;
			}
			set
			{
				if ((this._USER_MONEY != value))
				{
					this._USER_MONEY = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE2", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE2
		{
			get
			{
				return this._FLAG_ACTIVE2;
			}
			set
			{
				if ((this._FLAG_ACTIVE2 != value))
				{
					this._FLAG_ACTIVE2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOTE1", DbType="NVarChar(MAX)")]
		public string NOTE1
		{
			get
			{
				return this._NOTE1;
			}
			set
			{
				if ((this._NOTE1 != value))
				{
					this._NOTE1 = value;
				}
			}
		}
	}
	
	public partial class _062021_bongda_Get_MatchResult
	{
		
		private int _MTCH_ID;
		
		private string _MTCH_DATE;
		
		private string _MTCH_HH;
		
		private string _MTCH_MM;
		
		private int _TEAM_1;
		
		private int _TEAM_2;
		
		private int _TYSO_1;
		
		private int _TYSO_2;
		
		private string _KEO_1;
		
		private string _KEO_2;
		
		private string _MTCH_NOTE;
		
		private System.Nullable<int> _FLAG_ACTIVE;
		
		private int _idTeam1;
		
		private string _nameTeam1;
		
		private string _flagTeam1;
		
		private int _idTeam2;
		
		private string _nameTeam2;
		
		private string _flagTeam2;
		
		public _062021_bongda_Get_MatchResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_ID", DbType="Int NOT NULL")]
		public int MTCH_ID
		{
			get
			{
				return this._MTCH_ID;
			}
			set
			{
				if ((this._MTCH_ID != value))
				{
					this._MTCH_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_DATE", DbType="NVarChar(200)")]
		public string MTCH_DATE
		{
			get
			{
				return this._MTCH_DATE;
			}
			set
			{
				if ((this._MTCH_DATE != value))
				{
					this._MTCH_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_HH", DbType="NVarChar(10)")]
		public string MTCH_HH
		{
			get
			{
				return this._MTCH_HH;
			}
			set
			{
				if ((this._MTCH_HH != value))
				{
					this._MTCH_HH = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_MM", DbType="NVarChar(10)")]
		public string MTCH_MM
		{
			get
			{
				return this._MTCH_MM;
			}
			set
			{
				if ((this._MTCH_MM != value))
				{
					this._MTCH_MM = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAM_1", DbType="Int NOT NULL")]
		public int TEAM_1
		{
			get
			{
				return this._TEAM_1;
			}
			set
			{
				if ((this._TEAM_1 != value))
				{
					this._TEAM_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAM_2", DbType="Int NOT NULL")]
		public int TEAM_2
		{
			get
			{
				return this._TEAM_2;
			}
			set
			{
				if ((this._TEAM_2 != value))
				{
					this._TEAM_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TYSO_1", DbType="Int NOT NULL")]
		public int TYSO_1
		{
			get
			{
				return this._TYSO_1;
			}
			set
			{
				if ((this._TYSO_1 != value))
				{
					this._TYSO_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TYSO_2", DbType="Int NOT NULL")]
		public int TYSO_2
		{
			get
			{
				return this._TYSO_2;
			}
			set
			{
				if ((this._TYSO_2 != value))
				{
					this._TYSO_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KEO_1", DbType="NVarChar(50)")]
		public string KEO_1
		{
			get
			{
				return this._KEO_1;
			}
			set
			{
				if ((this._KEO_1 != value))
				{
					this._KEO_1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KEO_2", DbType="NVarChar(50)")]
		public string KEO_2
		{
			get
			{
				return this._KEO_2;
			}
			set
			{
				if ((this._KEO_2 != value))
				{
					this._KEO_2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_NOTE", DbType="NVarChar(MAX)")]
		public string MTCH_NOTE
		{
			get
			{
				return this._MTCH_NOTE;
			}
			set
			{
				if ((this._MTCH_NOTE != value))
				{
					this._MTCH_NOTE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FLAG_ACTIVE", DbType="Int")]
		public System.Nullable<int> FLAG_ACTIVE
		{
			get
			{
				return this._FLAG_ACTIVE;
			}
			set
			{
				if ((this._FLAG_ACTIVE != value))
				{
					this._FLAG_ACTIVE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idTeam1", DbType="Int NOT NULL")]
		public int idTeam1
		{
			get
			{
				return this._idTeam1;
			}
			set
			{
				if ((this._idTeam1 != value))
				{
					this._idTeam1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nameTeam1", DbType="NVarChar(200)")]
		public string nameTeam1
		{
			get
			{
				return this._nameTeam1;
			}
			set
			{
				if ((this._nameTeam1 != value))
				{
					this._nameTeam1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_flagTeam1", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string flagTeam1
		{
			get
			{
				return this._flagTeam1;
			}
			set
			{
				if ((this._flagTeam1 != value))
				{
					this._flagTeam1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idTeam2", DbType="Int NOT NULL")]
		public int idTeam2
		{
			get
			{
				return this._idTeam2;
			}
			set
			{
				if ((this._idTeam2 != value))
				{
					this._idTeam2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nameTeam2", DbType="NVarChar(200)")]
		public string nameTeam2
		{
			get
			{
				return this._nameTeam2;
			}
			set
			{
				if ((this._nameTeam2 != value))
				{
					this._nameTeam2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_flagTeam2", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string flagTeam2
		{
			get
			{
				return this._flagTeam2;
			}
			set
			{
				if ((this._flagTeam2 != value))
				{
					this._flagTeam2 = value;
				}
			}
		}
	}
	
	public partial class _062021_bongda_Get_After_MatchResult
	{
		
		private int _USER_ID;
		
		private string _USER_NAME;
		
		private string _USER_MONEY;
		
		private string _USER_EMAIL;
		
		private System.Nullable<double> _KQCC1;
		
		private System.Nullable<double> _KQCC2;
		
		private int _MTCHD_ID;
		
		private int _MTCH_ID;
		
		private string _TIENCUOC;
		
		private System.Nullable<double> _KETQUAATRUB;
		
		private string _TEAMDACHON;
		
		private string _WLMONEY;
		
		public _062021_bongda_Get_After_MatchResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_ID", DbType="Int NOT NULL")]
		public int USER_ID
		{
			get
			{
				return this._USER_ID;
			}
			set
			{
				if ((this._USER_ID != value))
				{
					this._USER_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_NAME", DbType="NVarChar(200)")]
		public string USER_NAME
		{
			get
			{
				return this._USER_NAME;
			}
			set
			{
				if ((this._USER_NAME != value))
				{
					this._USER_NAME = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_MONEY", DbType="NVarChar(150)")]
		public string USER_MONEY
		{
			get
			{
				return this._USER_MONEY;
			}
			set
			{
				if ((this._USER_MONEY != value))
				{
					this._USER_MONEY = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USER_EMAIL", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string USER_EMAIL
		{
			get
			{
				return this._USER_EMAIL;
			}
			set
			{
				if ((this._USER_EMAIL != value))
				{
					this._USER_EMAIL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KQCC1", DbType="Float")]
		public System.Nullable<double> KQCC1
		{
			get
			{
				return this._KQCC1;
			}
			set
			{
				if ((this._KQCC1 != value))
				{
					this._KQCC1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KQCC2", DbType="Float")]
		public System.Nullable<double> KQCC2
		{
			get
			{
				return this._KQCC2;
			}
			set
			{
				if ((this._KQCC2 != value))
				{
					this._KQCC2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCHD_ID", DbType="Int NOT NULL")]
		public int MTCHD_ID
		{
			get
			{
				return this._MTCHD_ID;
			}
			set
			{
				if ((this._MTCHD_ID != value))
				{
					this._MTCHD_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MTCH_ID", DbType="Int NOT NULL")]
		public int MTCH_ID
		{
			get
			{
				return this._MTCH_ID;
			}
			set
			{
				if ((this._MTCH_ID != value))
				{
					this._MTCH_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TIENCUOC", DbType="NVarChar(200)")]
		public string TIENCUOC
		{
			get
			{
				return this._TIENCUOC;
			}
			set
			{
				if ((this._TIENCUOC != value))
				{
					this._TIENCUOC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KETQUAATRUB", DbType="Float")]
		public System.Nullable<double> KETQUAATRUB
		{
			get
			{
				return this._KETQUAATRUB;
			}
			set
			{
				if ((this._KETQUAATRUB != value))
				{
					this._KETQUAATRUB = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEAMDACHON", DbType="VarChar(5)")]
		public string TEAMDACHON
		{
			get
			{
				return this._TEAMDACHON;
			}
			set
			{
				if ((this._TEAMDACHON != value))
				{
					this._TEAMDACHON = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WLMONEY", DbType="NVarChar(201)")]
		public string WLMONEY
		{
			get
			{
				return this._WLMONEY;
			}
			set
			{
				if ((this._WLMONEY != value))
				{
					this._WLMONEY = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
