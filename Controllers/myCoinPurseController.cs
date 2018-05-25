using myCoinPurseApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace myCoinPurseApi.Controllers
{
    [RoutePrefix("api/MyCoinPurse")]
    public class MyCoinPurseController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        /// <summary>
        /// This gets a household
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetHousehold")]
        public async Task<Household> GetHousehold(int hhId)
        {
            return await db.GetHousehold(hhId);
        }

        /// <summary>
        /// This gets a household
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetHousehold/json")]
        public async Task<IHttpActionResult> GetHouseholdJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetHousehold(hhId));
            return Ok(json);
        }

        /// <summary>
        /// This gets the accounts of household
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetAccounts")]
        public async Task<List<PersonalAccount>> GetAccounts(int hhId)
        {
            return await db.GetAccounts(hhId);
        }

        /// <summary>
        /// This gets all accounts of a household
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetAccounts/json")]
        public async Task<IHttpActionResult> GetAccountsJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccounts(hhId));
            return Ok(json);
        }

        /// <summary>
        /// This gets the balance of a given account
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        [Route("GetAccountsBalance")]
        public async Task<decimal> GetAccountsBalance(int accId)
        {
            return await db.GetAccountsBalance(accId);
        }

        /// <summary>
        /// This gets the balance of a given account
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
         [Route("GetAccountsBalance/json")]
         public async Task<IHttpActionResult> GetAccountsBalanceJson(int accId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountsBalance(accId));
            return Ok(json);
        }

        /// <summary>
        /// This gets the details of a given account
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<PersonalAccount> GetAccountDetails(int accId)
        {
            return await db.GetAccountDetails(accId);
        }

        /// <summary>
        /// This gets the details of a given account
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        [Route("GetAccountDetails/json")]
        public async Task<IHttpActionResult> GetAccountDetailsJson(int accId)
        {
            var json = JsonConvert.SerializeObject(await db.GetAccountDetails(accId));
            return Ok(json);
        }
         
        /// <summary>
        /// This gets the balance of a given budget
        /// </summary>
        /// <param name="budId"></param>
        /// <returns></returns>
        [Route("GetBudgetBalance")]
        public async Task<decimal> GetBudgetBalance(int budId)
        {
            return await db.GetBudgetBalance(budId);
        }

        /// <summary>
        /// This gets the budget balance of a given budget
        /// </summary>
        /// <param name="budId"></param>
        /// <returns></returns>
        [Route("GetBudgetBalance/json")]
        public async Task<IHttpActionResult> GetBudgetBalanceJson(int budId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetBalance(budId));
            return Ok(json);
        }

        /// <summary>
        /// This gets the details of a budget
        /// </summary>
        /// <param name="budId"></param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<List<BudgetItem>> GetBudgetDetails(int budId)
        {
            return await db.GetBudgetDetails(budId);
        }

        /// <summary>
        /// This gets the details of a Budget
        /// </summary>
        /// <param name="budId"></param>
        /// <returns></returns>
        [Route("GetBudgetDetails/json")]
        public async Task<IHttpActionResult> GetBudgetDetailsJson(int budId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgetDetails(budId));
            return Ok(json);
        }

        /// <summary>
        /// This gets all Budgets of a household
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetBudgets")]
        public async Task<List<Budget>> GetBudgets(int hhId)
        {
            return await db.GetBudgets(hhId);
        }

        /// <summary>
        ///This gets all budgets of a Household 
        /// </summary>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("GetBudgets/json")]
        public async Task<IHttpActionResult> GetBudgetsJson(int hhId)
        {
            var json = JsonConvert.SerializeObject(await db.GetBudgets(hhId));
            return Ok(json);
        }

        /// <summary>
        /// This gets all transactions of an account
        /// 
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        [Route("GetTransactions")]
        public async Task<List<Transaction>> GetTransactions(int accId)
        {
            return await db.GetTransactions(accId);
        }

        /// <summary>
        /// This gets all transactions of an account
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        [Route("GetTransactions/json")]
        public async Task<IHttpActionResult> GetTransactionsJson(int accId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactions(accId));
            return Ok(json);
        }

        /// <summary>
        /// This gets the details of a given transaction
        /// </summary>
        /// <param name="trxId"></param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int trxId)
        {
            return await db.GetTransactionDetails(trxId);
        }

        /// <summary>
        /// This gets the details of a given Transaction
        /// </summary>
        /// <param name="trxId"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetTransactionDetailsJson(int trxId)
        {
            var json = JsonConvert.SerializeObject(await db.GetTransactionDetails(trxId));
            return Ok(json);
        }

        /// <summary>
        /// This adds an account to a User and a Household
        /// </summary>
        /// <param name="hhId"></param>
        /// <param name="name"></param>
        /// <param name="balance"></param>
        /// <param name="recBalance"></param>
        /// <param name="createdById"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [Route("AddAccount")]
        [AcceptVerbs("GET", "POST")]
        public async Task<int> AddAccount(int hhId, string name, decimal balance, decimal recBalance, string createdById, bool isDeleted)
        {
            return await db.AddAccount(hhId, name, balance, recBalance, createdById, isDeleted);
        }

        /// <summary>
        /// This adds a Budget to a household
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hhId"></param>
        /// <returns></returns>
        [Route("AddBudget")]
        [AcceptVerbs("GET", "POST")]
        public async Task<int> AddBudget(string name, int hhId)
        {
            return await db.AddBudget(name, hhId);
        }
        
        /// <summary>
        /// This Adds a Budget Item to a Budget
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="catId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [Route("AddBudgetItem")]
        [AcceptVerbs("GET", "POST")]
        public async Task<int> AddBudgetItem(int budgetId, int catId, decimal amount)
        {
            return await db.AddBudgetItem(budgetId, catId, amount);
        }

        /// <summary>
        /// This Adds a Household and Automatically joins the User to the Household
        /// </summary>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("AddHousehold")]
        [AcceptVerbs("GET", "POST")]
        public async Task<int> AddHousehold(string name, string userId)
        {
            return await db.AddHouseHold(name, userId);
        }

        /// <summary>
        /// This adds a transaction.
        /// </summary>
        /// <param name="accId"></param>
        /// <param name="descrip"></param>
        /// <param name="amount"></param>
        /// <param name="type"></param>
        /// <param name="isVoid"></param>
        /// <param name="catId"></param>
        /// <param name="enteredById"></param>
        /// <param name="reconciled"></param>
        /// <param name="reconciledAmount"></param>
        /// <param name="isDeleted"></param>
        /// <returns></returns>
        [Route("AddTransaction")]
        [AcceptVerbs("GET", "POST")]
        public async Task<int> AddTransaction(int accId, string descrip, decimal amount, bool type, bool isVoid, int catId,
            string enteredById, bool reconciled, decimal reconciledAmount, bool isDeleted)
        {
            return await db.AddTransaction(accId, descrip, amount, type, isVoid, catId, enteredById, reconciled, reconciledAmount, isDeleted);
        }
    }
}
