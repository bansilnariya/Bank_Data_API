using Bank_Data_API.Model;

namespace Bank_Data_API.Service
{
    public interface IBankService
    {
        public Task<List<BankData>> BankListAsync();
        public Task<BankData> GetBankByIdAsync(string bankid);

        public Task AddBankAsync(BankData bankdata);
        public Task UpdateBankAsync(string bankid,BankData bankdata);
        public Task DeleteBankAsync(string bankid);
    }
}
