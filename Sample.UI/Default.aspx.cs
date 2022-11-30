using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sample.DTO;
using Sample.DATA;

namespace Sample.UI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CountryMasterDTO objCountryMasterDTO = new CountryMasterDTO();
                objCountryMasterDTO.COUNTRY_NAME = "India";
                objCountryMasterDTO.COUNTRY_ID= 1;
                objCountryMasterDTO.COUNTRY_ACTIVE= "Y";
                objCountryMasterDTO.LOGIN_ID = 1;
                objCountryMasterDTO.SYSTEM_ID = "test";
                objCountryMasterDTO.UserMaster = new UserMasterDTO();
                objCountryMasterDTO.UserMaster.USER_ID = 1;
                
                int intCountryID=new CountryMasterService().InsertCountryMaster(objCountryMasterDTO, "SampleDB");

            }
            catch 
            {
                throw;
            }
        }
    }
}
