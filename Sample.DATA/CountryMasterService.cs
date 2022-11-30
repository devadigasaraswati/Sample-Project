using System;
using System.Data;using System.Data.SqlClient;
using Sample.DTO;using Sample.Library;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryMasterService" in code, svc and config file together.
namespace Sample.DATA
{
    public class CountryMasterService
    {
        #region InsertCountryMaster
        public int InsertCountryMaster(CountryMasterDTO objCountryMasterDTO, string strDatabase)
        {
            IDbConnection _conn = null;
            IDbTransaction _trans = null;
            int intCOUNTRY_ID = 0;
            try
            {
                _conn = new SqlConnection(Functions.ReadConfigValue(strDatabase));
                _conn.Open();
                _trans = _conn.BeginTransaction();
                intCOUNTRY_ID = new CountryMasterDAO(_conn).InsertCountryMaster(objCountryMasterDTO, _trans);
                _trans.Commit();
            }
            catch (Exception exception)
            {
                if (_trans != null)
                    _trans.Rollback();
                throw exception;
            }
            finally
            {
                if (_trans != null)
                {
                    _trans.Dispose();
                }
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.Dispose();
                }
            }
            return intCOUNTRY_ID;
        }
        #endregion

        #region UpdateCountryMaster
        public void UpdateCountryMaster(CountryMasterDTO objCountryMasterDTO, string strDatabase)
        {
            IDbConnection _conn = null;
            IDbTransaction _trans = null;
            try
            {
                _conn = new SqlConnection(Functions.ReadConfigValue(strDatabase));
                _conn.Open();
                _trans = _conn.BeginTransaction();
                new CountryMasterDAO(_conn).UpdateCountryMaster(objCountryMasterDTO, _trans);
                _trans.Commit();
            }
            catch (Exception exception)
            {
                if (_trans != null)
                    _trans.Rollback();
                throw exception;
            }
            finally
            {
                if (_trans != null)
                {
                    _trans.Dispose();
                }
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.Dispose();
                }
            }
        }
        #endregion

        #region DeleteCountryMaster
        public int DeleteCountryMaster(int intCOUNTRY_ID, string strDatabase)
        {
            IDbConnection _conn = null;
            IDbTransaction _trans = null;
            try
            {
                _conn = new SqlConnection(Functions.ReadConfigValue(strDatabase));
                _conn.Open();
                _trans = _conn.BeginTransaction();
                int intCount = new CountryMasterDAO(_conn).DeleteCountryMaster(intCOUNTRY_ID, _trans);
                _trans.Commit();
                return intCount;
            }
            catch (Exception exception)
            {
                if (_trans != null)
                    _trans.Rollback();
                throw exception;
            }
            finally
            {
                if (_trans != null)
                {
                    _trans.Dispose();
                }
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.Dispose();
                }
            }
        }
        #endregion

        #region GetCountryMasterById
        public DataTable GetCountryMasterById(int intCOUNTRY_ID, string strDatabase)
        {
            IDbConnection _conn = null;
            try
            {
                _conn = new SqlConnection(Functions.ReadConfigValue(strDatabase));
                return new CountryMasterDAO(_conn).GetCountryMasterById(intCOUNTRY_ID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.Dispose();
                }
            }
        }
        #endregion

        #region GetCountryMasterByAll
        public DataTable GetCountryMasterByAll(string strCOUNTRY_NAME, string strCOUNTRY_ACTIVE, string strDatabase)
        {
            IDbConnection _conn = null;
            try
            {
                _conn = new SqlConnection(Functions.ReadConfigValue(strDatabase));
                return new CountryMasterDAO(_conn).GetCountryMasterByAll(strCOUNTRY_NAME, strCOUNTRY_ACTIVE);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (_conn != null)
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                    _conn.Dispose();
                }
            }
        }
        #endregion
    }
}