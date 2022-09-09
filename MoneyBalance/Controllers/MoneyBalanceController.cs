using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyBalance.Models;

namespace MoneyBalance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoneyBalanceController : ControllerBase
    {
        private readonly MoneyBalanceContext _context;

        public MoneyBalanceController(MoneyBalanceContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<MoneyBalanceDTO>>> GetAll()
        {
            return Ok(await _context.MoneyBalances.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<MoneyBalanceDTO>> GetMoneyBalance (int id)
        {
            var result = await _context.MoneyBalances.FindAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<MoneyBalanceDTO>> NewBalanceMoney(MoneyBalanceDTO moneyBalanceDTO)
        {
            var md = new Money_Balance
            {
                Balance = moneyBalanceDTO.Balance,
                Expenses = moneyBalanceDTO.Expenses,
                Salary = moneyBalanceDTO.Salary,
                Saved = moneyBalanceDTO.Saved
            };

            _context.MoneyBalances.Add(md);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMoneyBalance),new {id = md.Id},md);

           
        }

    }
}
