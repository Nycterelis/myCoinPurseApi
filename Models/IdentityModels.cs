using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace myCoinPurseApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //SQL=======================Get Household============================

        //====================================================================

        public async Task<Household> GetHousehold(int hhId)
        {
            return await Database.SqlQuery<Household>("GetHousehold @hhId",
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        //SQL=====================Get Accounts================================

        //====================================================================
        public async Task<List<PersonalAccount>> GetAccounts(int hhId)
        {
            return await Database.SqlQuery<PersonalAccount>("GetAccounts @hhid",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        //SQL=======================Get Account Balance========================

        //=====================================================================
        public async Task<decimal> GetAccountsBalance(int accId)
        {
            return await Database.SqlQuery<decimal>("GetAccountsBalance @accId",
                new SqlParameter("accId", accId)).FirstOrDefaultAsync();
        }

        //SQL========================Get Account Details========================

        //======================================================================
        public async Task<PersonalAccount> GetAccountDetails(int accId)
        {
            return await Database.SqlQuery<PersonalAccount>("GetAccountDetails @accId",
                new SqlParameter("accId", accId)).FirstOrDefaultAsync();
        }

        //SQL=========================Get Budget Balance========================

        //======================================================================
        public async Task<decimal> GetBudgetBalance(int budId)
        {
            return await Database.SqlQuery<decimal>("GetBudgetBalance @budId",
                new SqlParameter("budId", budId)).FirstOrDefaultAsync();
        }

        //SQL=========================Get Budget Details========================

        //======================================================================
        public async Task<List<BudgetItem>> GetBudgetDetails(int budId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetDetails @budId",
                new SqlParameter("budId", budId)).ToListAsync();
        }

        //SQL=========================Get Budget================================

        //======================================================================
        public async Task<List<Budget>> GetBudgets(int hhId)
        {
            return await Database.SqlQuery<Budget>("GetBudgets @hhId",
                new SqlParameter("hhId", hhId)).ToListAsync();
        }

        //SQL=========================Get Transactions==========================

        //======================================================================
        public async Task<List<Transaction>> GetTransactions(int accId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactions @accId",
                new SqlParameter("accId", accId)).ToListAsync();
        }

        //SQL=========================Get Transaction Details===================

        //======================================================================
        public async Task<Transaction> GetTransactionDetails(int trxId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @trxId",
                new SqlParameter("trxId", trxId)).FirstOrDefaultAsync();
        }

        //SQL=========================POST PROCEDURES===========================
        //======================================================================

        //SQL=========================Add Account===============================

        //======================================================================
        public async Task<int> AddAccount(int hhId, string name, decimal balance, decimal recBalance, string createdById, bool isDeleted)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @hhId, @name, @balance, @recBalance, @createdById, @isDeleted",
                new SqlParameter("hhId", hhId),
                new SqlParameter("name", name),
                new SqlParameter("balance", balance),
                new SqlParameter("recBalance", recBalance),
                new SqlParameter("createdById", createdById),
                new SqlParameter("isDeleted", isDeleted));
        }

        //SQL=========================Add Budget================================

        //======================================================================
        public async Task<int> AddBudget(string name, int hhId)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @name, @hhId",
                new SqlParameter("name", name),
                new SqlParameter("hhId", hhId));
        }

        //SQL=========================Add Budget Item===========================

        //======================================================================
        public async Task<int> AddBudgetItem(int budgetId, int catId, decimal amount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudgetitem @budgetId, @catId, @amount",
                new SqlParameter("budgetId", budgetId),
                new SqlParameter("catId", catId),
                new SqlParameter("amount", amount));
        }
        //SQL=========================Add Household=============================

        //======================================================================
        public async Task<int> AddHouseHold(string name, string userId)
        {
            return await Database.ExecuteSqlCommandAsync("AddHousehold @name, @userId",
                new SqlParameter("name", name),
                new SqlParameter("userId", userId));
        }

        //SQL=========================Add Transaction===========================

        //======================================================================
        public async Task<int> AddTransaction(int accId, string descrip, decimal amount, bool type, bool isVoid, int catId,
            string enteredById, bool reconciled, decimal reconciledAmount, bool isDeleted)
        {
            return await Database.ExecuteSqlCommandAsync(
                "AddTransaction @accId, @descrip, @amount, @type, @isVoid, @catId, @enteredById, @reconciled, @reconciledAmount, @isDeleted",
                new SqlParameter("accId", accId),
                new SqlParameter("descrip", descrip),
                new SqlParameter("amount", amount),
                new SqlParameter("type", type),
                new SqlParameter("isVoid", isVoid),
                new SqlParameter("catId", catId),
                new SqlParameter("enteredById", enteredById),
                new SqlParameter("reconciled", reconciled),
                new SqlParameter("reconciledAmount", reconciledAmount),
                new SqlParameter("isDeleted", isDeleted));
        }
    }
}