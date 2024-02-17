using Bank_Data_API.Model;
using Bank_Data_API.Setting;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using ZstdSharp.Unsafe;

namespace Bank_Data_API.Service
{
    public class BankDataService:IBankService
    {
        private readonly IMongoCollection<BankData> bankCollection;

        public BankDataService(IOptions<BankDBSettings> bankdatabasesetting)
        {
            var mongoClient = new MongoClient(
                bankdatabasesetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(bankdatabasesetting.Value.DatabaseName);

            bankCollection = mongoDatabase.GetCollection<BankData>(bankdatabasesetting.Value.BankCollection);

        }

        public async Task<List<BankData>> BankListAsync()
        {
             return await bankCollection.Find(_=> true).ToListAsync();
        }
        public async Task<BankData> GetBankByIdAsync(string bankid)
        {
           return await bankCollection.Find(x=>x._id == bankid).FirstOrDefaultAsync();

        }
        public async Task AddBankAsync(BankData bankdata)
        {
            await bankCollection.InsertOneAsync(bankdata);
        }
        public async Task UpdateBankAsync(string bankid,BankData bankdata)
        {
            await bankCollection.ReplaceOneAsync(x=>x._id==bankid, bankdata);
        }
        public async Task DeleteBankAsync(string bankid)
        {
            await bankCollection.DeleteOneAsync(x=>x._id==bankid);
        }
    }
}
