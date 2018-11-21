using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpcabServer.Model
{
    public class User
    {
        //must match with mongo id schema
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string FatherName { get; set; }

        public string HusbandName { get; set; }

        public string MotherName { get; set; }

        public string DOB { get; set; }
        
        public string MaritalStatus { get; set; }

        public string SpouseName { get; set; }

        public string Inviter { get; set; }

        public string BloodGroup { get; set; }

        public string Occupation { get; set; }

        public string PermanentAddress { get; set; }

        public string PermanentAddressVillage{ get; set; }

        public string PermanentAddressHouse{ get; set; }

        public string PermanentAddressRoad{ get; set; }

        public string PermanentAddressSector{ get; set; }

        public string PermanentAddressBlock{ get; set; }

        public string PermanentAddressSubdistrict{ get; set; }

        public string PermanentAddressDristrict{ get; set; }

        public string PermanentAddressPostOffice{ get; set; }

        public string PermanentAddressPostalCode{ get; set; }

        public string PermanentAddressCountry{ get; set; }

        public string PermanentAddressNationality{ get; set; }

        public string PermanentAddressNID{ get; set; }

        public string PresentAddressVillage{ get; set; }

        public string PresentAddressHouse{ get; set; }

        public string PresentAddressRoad{ get; set; }

        public string PresentAddressSector{ get; set; }

        public string PresentAddressBlock{ get; set; }

        public string PresentAddressSubDistrict{ get; set; }

        public string PresentAddressDistrict{ get; set; }

        public string PresentAddressPostOffice{ get; set; }

        public string PresentAddressPostalCode{ get; set; }

        public string PresentAddressCountry{ get; set; }

        public string PresentAddressZone{ get; set; }

        public string Zone { get; set; }

        public string SubDistrict { get; set; }

        public string District { get; set; }

        public string Country { get; set; }

        public string Nationality { get; set; }

        public string NID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
