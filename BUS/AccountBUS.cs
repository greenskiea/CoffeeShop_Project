using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.BUS
{
    internal class AccountBUS
    {
        public AccountDAO accountDAO;

        public AccountBUS()
        {
            accountDAO = new AccountDAO();
        }

        public List<DTO.Account> getAccount()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = accountDAO.getAccount();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            List<Account> list = new List<Account>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Account account = new Account();
                    account.Username = row["Username"].ToString();
                    account.Password = row["Password"].ToString();
                    list.Add(account);
                }
            }
            return list;
        }

        public bool IsValidUser(string username, string password)
        {
            try
            {
                return accountDAO.IsValidUser(username, password);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
