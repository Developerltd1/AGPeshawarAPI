using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer
{
    public class UserData
    {

        public string Applicant_name { get; set; }
        public string Relation_type { get; set; } //null
        public string Relation_name { get; set; }
        public string Cnic { get; set; }
        public string Cnic_image { get; set; }
        public string Cnic_image_back { get; set; }
        public string Ownership_type { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Status { get; set; }
        public string No_of_family_members { get; set; }
        public string No_of_men { get; set; }
        public string No_of_women { get; set; }
        public string No_of_children { get; set; }
        public string Current_monthly_income { get; set; }
        public string Source_of_income { get; set; }
        public string Contact { get; set; }
        public string Remarks { get; set; }
        public List<string> Evidence { get; set; }
        public List<string> EvidenceCompress { get; set; }
        public string Evidence_Join { get; set; }
        public List<string> Selection_criteria { get; set; }
        public string Selection_criteria_Join { get; set; }
        public string Address { get; set; }

        //public string Latitude { get; set; }
        //public string Longitude { get; set; }
        //public string Ref_id { get; set; } //null
        public string Signature_pic { get; set; }
        public string User_id { get; set; }
        public string Role_id { get; set; }
        public string Mobile_created_at { get; set; }
        public string Mobile_updated_at { get; set; }
        public string Sent_server { get; set; }

        public UserData()
        {
            EvidenceCompress = new List<string>();
        }
    }
    public class GetUserDataList
    {
     

        public string UserDetailId { get; set; }
        public string Applicant_name { get; set; }
        public string Relation_type { get; set; }
        public string Relation_name { get; set; }
        public string Cnic { get; set; }
        public string Cnic_image { get; set; }
        public string Cnic_image_back { get; set; }
        
        public string Ownership_type { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string Status { get; set; }
        public string No_of_family_members { get; set; }
        public string No_of_men { get; set; }
        public string No_of_women { get; set; }
        public string No_of_children { get; set; }
        public string Current_monthly_income { get; set; }
        public string Source_of_income { get; set; }
        public string Contact { get; set; }
        public string Remarks { get; set; }
        public string Evidence_Join { get; set; }
        public string Selection_criteria_Join { get; set; }
        public string Address { get; set; }
        public string Signature_pic { get; set; }
        public string User_id { get; set; }
        public string Role_id { get; set; }
        public string Mobile_created_at { get; set; }
        public string Mobile_updated_at { get; set; }
        public string Sent_server { get; set; }

    }
    public class StatusModel
    {
        public bool status { get; set; }
        public string statusDetail { get; set; }
    }
}
