using Bank_Data_API.Model;
using Bank_Data_API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Bank_Data_API.Controllers
{
    [Route("bank")]
    [ApiController]
    public class BankDataController : ControllerBase
    {
        private readonly IBankService bankService;

        public BankDataController(IBankService bankService) => this.bankService = bankService;

        [HttpGet]
        public async Task<List<BankData>> Get()
        {
            return await bankService.BankListAsync();
        }

        [HttpGet("{bankid:length(24)}")]
        public async Task<ActionResult<BankData>> Get(string bankid)
        {
            var bankdatas = await bankService.GetBankByIdAsync(bankid);

            if (bankdatas is null)
            {
                return NotFound();
            }
            return bankdatas;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BankData bankdata)
        {
            await bankService.AddBankAsync(bankdata);
            return CreatedAtAction(nameof(Get), new { id = bankdata._id }, bankdata);
        }
        [HttpPut("{bankid:length(24)}")]
        public async Task<IActionResult>Update(string bankid,BankData bankdata)
        {
            var bankdatas = await bankService.GetBankByIdAsync(bankid);
            if(bankdatas is null)
            {
                return NotFound();
            }
            bankdata._id = bankdatas._id;
            await bankService.UpdateBankAsync(bankid, bankdata);

            return Ok();
        }
        [HttpDelete("{bankid:length(24)}")]
        public async Task<IActionResult> Delete(String bankid)
        {
            var bankdatas = await bankService.GetBankByIdAsync(bankid);
            if( bankdatas is null)
            {
                return NotFound();
            }
            await bankService.DeleteBankAsync(bankid);
            return Ok();
        }
            
        

    }
}
