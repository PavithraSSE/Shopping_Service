using ShoppingProcessor.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ShoppingDAL;
using System.Data.SqlClient;

namespace ShoppingProcessor
{
    public class ShoppingModel: IShoppingModel
    {
        public async Task<dynamic> GetItemsDetailsByName(CategoryRQ categoryRQ)
        {
            List<CategoryRS> lstCategoryRS = new List<CategoryRS>();
            if (!string.IsNullOrEmpty(categoryRQ.CategoryName))
                lstCategoryRS = Get_CategoryDetails(categoryRQ.CategoryName);
            return lstCategoryRS;
        }
        public async Task<bool> DeleteCategorByName(string Name)
        {
            bool IsDeleted = false;
            if (!string.IsNullOrEmpty(Name))
                IsDeleted = DeleteCategoryDetails(Name);
            return IsDeleted;
        }

        public List<CategoryRS> Get_CategoryDetails(string Name)
        {
            List<CategoryRS> lstcategoryRS = new List<CategoryRS>();
            try
            {
                DataTable dt = new DataTable();
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@CategoryName", Name));
                dt = DBconnection.FillDataTable(SPNames.GetItemsByName, sqlParameters.ToArray());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CategoryRS categoryRS = new CategoryRS();
                    categoryRS.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                    categoryRS.SubCategoryName = dt.Rows[i]["SubCategoryName"].ToString();
                    categoryRS.ItemName = dt.Rows[i]["ItemName"].ToString();
                    categoryRS.ItemDescription = dt.Rows[i]["Description"].ToString();
                    lstcategoryRS.Add(categoryRS);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return lstcategoryRS;
        }

        public bool DeleteCategoryDetails(string Name)
        {
            bool IsDeleted = false;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@CategoryName", Name));
            IsDeleted = DBconnection.ExecuteNonQuery(SPNames.DeleteItemByName, sqlParameters.ToArray());
            return IsDeleted;
        }
    }
}
