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
}
#pragma warning restore 1591
