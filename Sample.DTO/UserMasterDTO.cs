using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Sample.DTO
{
    [DataContract]
    public class UserMasterDTO
    {
        #region Private Fields
        private Int32 _USER_ID;
        private String _USER_NAME;
        private String _USER_PASSWORD;
        private UserTypeMasterDTO _UserType;
        private String _USER_ACTIVE;
        private String _SYSTEM_ID;
        private Int32 _LOGIN_ID;
        #endregion

        #region Public Fields
        [DataMember]
        public Int32 USER_ID
        {
            get { return _USER_ID; }
            set { _USER_ID = value; }
        }

        [DataMember]
        public String USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }

        [DataMember]
        public String USER_PASSWORD
        {
            get { return _USER_PASSWORD; }
            set { _USER_PASSWORD = value; }
        }

        [DataMember]
        public UserTypeMasterDTO UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }

        [DataMember]
        public String USER_ACTIVE
        {
            get { return _USER_ACTIVE; }
            set { _USER_ACTIVE = value; }
        }

        [DataMember]
        public String SYSTEM_ID
        {
            get { return _SYSTEM_ID; }
            set { _SYSTEM_ID = value; }
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
