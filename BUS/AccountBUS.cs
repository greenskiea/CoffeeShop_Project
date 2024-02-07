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

        public List<DTO.Account> GetName(string username)
        {
            List<DTO.Account> accountList = new List<DTO.Account>();

            try
            {
                DataTable dataTable = accountDAO.GetName(username);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DTO.Account account = new DTO.Account
                        {
                            Name = row["Name"].ToString(),
                            Type = row["Type"].ToString(),
                        };

                        accountList.Add(account);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return accountList;
        }

        public List<DTO.Account> GetAllStaff()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = accountDAO.getAllStaff();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            List<Account> staffList = new List<Account>();
            if(dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    Account account = new Account();
                    string idString = row["User_ID"].ToString();
                    account.Id = int.Parse(idString);
                    account.Username = row["Username"].ToString();
                    account.Password = row["Password"].ToString();
                    account.Type = row["Type"].ToString();
                    account.Email = row["Email"].ToString();
                    account.Name = row["Name"].ToString();
                    account.Address = row["Address"].ToString();
                    account.PhoneNumber = row["Phone"].ToString();
                    account.Personal_ID = row["Personal_ID"].ToString();
                    account.DOB = row["DOB"].ToString();
                    string genderString = row["Gender"].ToString();
                    account.Gender = int.Parse(genderString);
                    staffList.Add(account);
                }
            }
            return staffList;
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

        public bool InsertAccount(string Username, string Password, string Email, string Type, string Name, string Personal_ID, string Address, string Phone, string DOB, int Gender)
        {
            try
            {
                return accountDAO.InsertAccount(Username, Password, Email, Type, Name, Personal_ID, Address, Phone, DOB, Gender);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteAccount(string User_ID)
        {
            try
            {
                return accountDAO.DeleteAccount(User_ID);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool UpdateAccount(int Id, string Username, string Password, string Email, string Type, string Name, string Personal_ID, string Address, string Phone, string DOB, int Gender)
        {
            try
            {
                return accountDAO.Update(Id, Username, Password, Email, Type, Name, Personal_ID, Address, Phone, DOB, Gender);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
