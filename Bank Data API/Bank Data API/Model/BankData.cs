using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;


namespace Bank_Data_API.Model
{
    public class BankData
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = string.Empty;

        [BsonElement("bank_name")]
        public string Bank_Name { get; set; } = string.Empty;

        public string Bank_Branch_Name { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Bank_Brnch_Code { get; set; } = string.Empty;

        public string Back_Ifsc_Code { get; set; } = string.Empty;

    }
}
