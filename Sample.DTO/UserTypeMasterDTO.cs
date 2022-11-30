using System;
using System.Runtime.Serialization;

namespace Sample.DTO
{
    [DataContract]
    public class UserTypeMasterDTO
    {
        #region Private Fields
        private Int32 _USERTYPE_ID;
        private String _USERTYPE_ROLE;
        private Int32 _MENU_ID;
        private String _USERTYPE_ACTIVE;
        private String _SYSTEM_ID;
        private Int32 _LOGIN_ID;
        private UserMasterDTO _UserMaster;
        #endregion

        #region Public Fields

        [DataMember]
        public Int32 USERTYPE_ID
        {
            get { return _USERTYPE_ID; }
            set { _USERTYPE_ID = value; }
        }

        [DataMember]
        public String USERTYPE_ROLE
        {
            get { return _USERTYPE_ROLE; }
            set { _USERTYPE_ROLE = value; }
        }

        [DataMember]
        public Int32 MENU_ID
        {
            get { return _MENU_ID; }
            set { _MENU_ID = value; }
        }

        [DataMember]
        public String USERTYPE_ACTIVE
        {
            get { return _USERTYPE_ACTIVE; }
            set { _USERTYPE_ACTIVE = value; }
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

        [DataMember]
        public UserMasterDTO UserMaster
        {
            get { return _UserMaster; }
            set { _UserMaster = value; }
        }
        #endregion
    }
}
