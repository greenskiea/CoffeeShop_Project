﻿using PTPMUD_Project.DAO;
using PTPMUD_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.BUS
{
    internal class TableFoodBUS
    {
        private TableFoodDAO tableFoodDAO;
        public TableFoodBUS()
        {
            tableFoodDAO = new TableFoodDAO();
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        public List<DTO.TableFood> getALLTable()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = tableFoodDAO.GetTableList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            List<TableFood> list = new List<TableFood>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TableFood table = new TableFood();
                    table.idTable = Int32.Parse(dr["Food_Table_ID"].ToString());
                    table.tableName = dr["Food_Table_Name"].ToString();
                    table.status = dr["Status"].ToString();
                    table.note = dr["note"].ToString();
                    list.Add(table);

                }
            }
            return list;
        }

        public void SwitchTable(int id1, int id2)
        {
            tableFoodDAO.switchTable(id1, id2);
        }

        public string GetStatusByID(int id)
        {
            return tableFoodDAO.GetStatusByID(id);  
        }

        public bool InserTable(string tableName, string status, string note)
        {
            return tableFoodDAO.inserTable(tableName, status, note);
        }

        public bool UpdateTable(int idTable, string tableName, string status, string note)
        {
            return tableFoodDAO.updateTable(idTable, tableName, status, note);
        }
        public bool DeleteTable(string idTable)
        {
            return tableFoodDAO.DeleteTable(idTable);
        }

        public bool SetNoteTableFood(string note, int id)
        {
            return tableFoodDAO.setNoteTableFood(note, id);
        }
    }
}
