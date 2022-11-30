using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sample.DTO
{
    [DataContract]
    public class CountryMasterDTO
    {
        #region Private Fields
        private Int32 _COUNTRY_ID;
        private String _COUNTRY_NAME;
        private String _COUNTRY_ACTIVE;
        private String _SYSTEM_ID;
        private UserMasterDTO _UserMaster;
        private Int32 _LOGIN_ID;
        #endregion

        #region Public Fields
        [DataMember]
        public Int32 COUNTRY_ID
        {
            get { return _COUNTRY_ID; }
            set { _COUNTRY_ID = value; }
        }

        [DataMember]
        public String COUNTRY_NAME
        {
            get { return _COUNTRY_NAME; }
            set { _COUNTRY_NAME = value; }
        }

        [DataMember]
        public String COUNTRY_ACTIVE
        {
            get { return _COUNTRY_ACTIVE; }
            set { _COUNTRY_ACTIVE = value; }
        }

        [DataMember]
        public String SYSTEM_ID
        {
            get { return _SYSTEM_ID; }
            set { _SYSTEM_ID = value; }
        }

        [DataMember]
        public UserMasterDTO UserMaster
        {
            get { return _UserMaster; }
            set { _UserMaster = value; }
        }

        [DataMember]
        public Int32 LOGIN_ID
        {
            get { return _LOGIN_ID; }
            set { _LOGIN_ID = value; }
        }
        #endregion
    }
}
