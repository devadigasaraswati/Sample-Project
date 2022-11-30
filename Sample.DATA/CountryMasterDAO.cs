using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Sample.DTO;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CountryMasterDAO
/// </summary>
namespace Sample.DATA
{
    internal class CountryMasterDAO
    {
        IDbConnection objConn;
        public CountryMasterDAO(IDbConnection _conn)
        { objConn = _conn; }

        #region InsertCountryMaster
        public int InsertCountryMaster(CountryMasterDTO objCountryMasterDTO, IDbTransaction _trans)
        {
            IDbCommand _oCmd = new SqlCommand();
            _oCmd.Connection = objConn;
            _oCmd.Transaction = _trans;
            _oCmd.CommandText = "INSERT INTO COUNTRYMASTER(COUNTRY_ID, COUNTRY_NAME, COUNTRY_ACTIVE, SYSTEM_ID, LOGIN_ID, USER_ID) " +
                "VALUES(@COUNTRY_ID, @COUNTRY_NAME, @COUNTRY_ACTIVE,@SYSTEM_ID, @LOGIN_ID, @USER_ID)";

            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ID", objCountryMasterDTO.COUNTRY_ID));  //change 
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", objCountryMasterDTO.COUNTRY_NAME));
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ACTIVE", objCountryMasterDTO.COUNTRY_ACTIVE));
            _oCmd.Parameters.Add(new SqlParameter("@SYSTEM_ID", objCountryMasterDTO.SYSTEM_ID));
            _oCmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objCountryMasterDTO.LOGIN_ID));
            _oCmd.Parameters.Add(new SqlParameter("@USER_ID", objCountryMasterDTO.UserMaster.USER_ID));
            _oCmd.ExecuteNonQuery();
            _oCmd.Dispose();
            return objCountryMasterDTO.COUNTRY_ID;  //return new id generated on every insert
        }
        #endregion

        #region UpdateCountryMaster
        public void UpdateCountryMaster(CountryMasterDTO objCountryMasterDTO, IDbTransaction _trans)
        {
            IDbCommand _oCmd = new SqlCommand();
            _oCmd.Connection = objConn;
            _oCmd.Transaction = _trans;

            _oCmd.CommandText = "UPDATE COUNTRYMASTER SET COUNTRY_NAME=@COUNTRY_NAME, COUNTRY_ACTIVE=@COUNTRY_ACTIVE, SYSTEM_ID=@SYSTEM_ID, " +
                " LOGIN_ID=@LOGIN_ID, USER_ID=@USER_ID WHERE COUNTRY_ID=@COUNTRY_ID";

            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ID", objCountryMasterDTO.COUNTRY_ID));
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", objCountryMasterDTO.COUNTRY_NAME));
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ACTIVE", objCountryMasterDTO.COUNTRY_ACTIVE));
            _oCmd.Parameters.Add(new SqlParameter("@SYSTEM_ID", objCountryMasterDTO.SYSTEM_ID));
            _oCmd.Parameters.Add(new SqlParameter("@LOGIN_ID", objCountryMasterDTO.LOGIN_ID));
            _oCmd.Parameters.Add(new SqlParameter("@USER_ID", objCountryMasterDTO.UserMaster.USER_ID));
            _oCmd.ExecuteNonQuery();
            _oCmd.Dispose();
        }
        #endregion

        #region DeleteCountryMaster
        public int DeleteCountryMaster(int intCOUNTRY_ID, IDbTransaction _trans)
        {
            IDbCommand _oCmd = new SqlCommand();
            _oCmd.Connection = objConn;
            _oCmd.Transaction = _trans;
            _oCmd.CommandText = "DELETE FROM COUNTRYMASTER WHERE COUNTRY_ID=@COUNTRY_ID";
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ID", intCOUNTRY_ID));
            intCOUNTRY_ID = _oCmd.ExecuteNonQuery();
            _oCmd.Dispose();
            return intCOUNTRY_ID;
        }
        #endregion

        #region GetCountryMasterById
        public DataTable GetCountryMasterById(int intCOUNTRY_ID)
        {
            IDbCommand _oCmd = new SqlCommand();
            _oCmd.Connection = objConn;

            _oCmd.CommandText = "SELECT * FROM COUNTRYMASTER WHERE COUNTRY_ID=@COUNTRY_ID";

            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ID", intCOUNTRY_ID));
            DbDataAdapter oDataAdapter = new SqlDataAdapter((SqlCommand)_oCmd);

            DataTable oDataTable = new DataTable("GetCountryMasterById");
            oDataAdapter.Fill(oDataTable);
            return oDataTable;

            //if (oDataTable.Rows.Count == 0)
            //    return null;
            //else
            //{
            //CountryMasterDTO objCountryMasterDTO = new CountryMasterDTO();
            //objCountryMasterDTO.COUNTRY_ID = Convert.ToInt32(oDataTable.Rows[0]["COUNTRY_ID"]);
            //objCountryMasterDTO.COUNTRY_NAME = Convert.ToString(oDataTable.Rows[0]["COUNTRY_NAME"]);
            //objCountryMasterDTO.COUNTRY_ACTIVE = Convert.ToString(oDataTable.Rows[0]["COUNTRY_ACTIVE"]);
            //objCountryMasterDTO.SYSTEM_ID = Convert.ToString(oDataTable.Rows[0]["SYSTEM_ID"]);
            //    return objCountryMasterDTO;
            //}
        }
        #endregion

        #region GetCountryMasterByAll
        public DataTable GetCountryMasterByAll(string strCOUNTRY_NAME, string strCOUNTRY_ACTIVE)
        {
            IDbCommand _oCmd = new SqlCommand();
            _oCmd.Connection = objConn;
            _oCmd.CommandText = "SELECT A.*,(CASE WHEN A.COUNTRY_NAME LIKE @COUNTRY_NAME+'%' THEN 0 ELSE 1 END) AS SL" +
                " FROM COUNTRYMASTER A " +
                " WHERE (COUNTRY_ACTIVE=@COUNTRY_ACTIVE OR @COUNTRY_ACTIVE='') " +
                " AND (COUNTRY_NAME LIKE '%'+@COUNTRY_NAME+'%')" +
                " ORDER BY SL,COUNTRY_NAME";

            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_ACTIVE", strCOUNTRY_ACTIVE));
            _oCmd.Parameters.Add(new SqlParameter("@COUNTRY_NAME", strCOUNTRY_NAME));
            DbDataAdapter oDataAdapter = new SqlDataAdapter((SqlCommand)_oCmd);
            DataTable oDataTable = new DataTable("GetCountryMasterByAll");
            oDataAdapter.Fill(oDataTable);
            return oDataTable;
        }
        #endregion
    }
}