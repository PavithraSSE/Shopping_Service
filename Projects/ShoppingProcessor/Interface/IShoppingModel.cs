using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProcessor.Interface
{
    public interface IShoppingModel
    {
        Task<dynamic> GetItemsDetailsByName(CategoryRQ categoryRQ);

        Task<bool> DeleteCategorByName(string Name);
    }
}
