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
    internal class PromotionBUS
    {
        private PromotionDAO promotionDAO;

        public PromotionBUS()
        {
            promotionDAO = new PromotionDAO();
        }

        public List<DTO.Promotion> getAllPromotion()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = promotionDAO.getAllPromotion();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            List<Promotion> promotionList = new List<Promotion>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Promotion promotion = new Promotion();
                    promotion.PromotionID = Convert.ToInt32(row["Promotion_ID"]);
                    promotion.PromotionName = row["Promotion_Name"].ToString();
                    promotion.DiscountValue = Convert.ToSingle(row["Discount_Value"]);
                    if (row["DateFrom_Discount"] != DBNull.Value)
                    {
                        promotion.DateFrom_Discount = ((DateTime)row["DateFrom_Discount"]).Date;
                    }
                    if(row["DateTo_Discount"] != DBNull.Value)
                    {
                        promotion.DateTo_Discount = ((DateTime)row["DateTo_Discount"]).Date;
                    }    
                   
                    promotionList.Add(promotion);
                }
            }
            return promotionList;
        }

        public bool InsertPromotion(string Name, float Value,DateTime DFD,DateTime DTD)
        {
            try
            {
                return promotionDAO.InsertPromotion(Name, Value, DFD, DTD);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool UpdatePromotion(int Id, string PromotionName, float Value, DateTime DFD, DateTime DTD)
        {
            try
            {
                return promotionDAO.UpdatePromotion(Id, PromotionName, Value, DFD, DTD);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool DeletePromotion (string Id)
        {
            try
            {
                return promotionDAO.DeletePromotion(Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public float GetPriceDiscountByIDFood(int id)
        {
            return promotionDAO.getPriceDiscountByIDFood(id);
        }

        public DateTime? GetDateFrom(int id)
        {
            return promotionDAO.getDateFrom(id);
        }

        public DateTime? GetDateTo(int id)
        {
            return promotionDAO.getDateTo(id);
        }
    }
}
