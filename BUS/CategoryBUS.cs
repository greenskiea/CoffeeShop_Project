using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PTPMUD_Project.BUS
{
    internal class CategoryBUS
    {
        private CategoryDAO categoryDAO;
        public CategoryBUS()
        {
            categoryDAO = new CategoryDAO();
        }
        public List<DTO.Category> getALLCategory()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = categoryDAO.GetCateList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<Category> list = new List<Category>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Category cate = new Category();
                    cate.categoryID = Int32.Parse(dr["Category_ID"].ToString());
                    cate.categoryName = dr["Category_Name"].ToString();
                   
                    list.Add(cate);

                }
            }
            return list;
        }
        public Category GetCategoryByID(int id)
        {
            return categoryDAO.getCategoryByID(id);
        }

        public bool InsertCategory(string CategoryName)
        {
            try
            {
                return categoryDAO.InsertCategory(CategoryName);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool UpdateCategory(int Id, string CategoryName)
        {
            try
            {
                return categoryDAO.UpdateCategory(Id, CategoryName);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeleteCategory(string Id)
        {
            try
            {
                return categoryDAO.DeleteCategory(Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
    }
}
