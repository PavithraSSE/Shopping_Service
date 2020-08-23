using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingProcessor;
using ShoppingProcessor.Interface;
using System.Dynamic;

namespace ShoppingService.Controllers
{
    [Route("api")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingModel _ShoppingModel;
        public ShoppingController(IShoppingModel shoppingMdl)
        {
            _ShoppingModel = shoppingMdl;
        }

        [HttpGet]
        public string Get(int id)
        {
            return "Service is Ready";
        }

        [HttpPost]
        [Route("ItemsByName")]
        public async Task<dynamic> Get_ItemsByName([FromBody]CategoryRQ categoryRQ)
        {
            dynamic response = new ExpandoObject();
            int nameLength = categoryRQ.CategoryName.Length;
            if (nameLength >= 3 && nameLength <= 12)
            {
                response = await _ShoppingModel.GetItemsDetailsByName(categoryRQ);
            }
            else
                return "Invalid Input. Accepted string length is min = 3 and max = 12";
            return response;
        }

        [HttpDelete]
        [Route("DeleteByName")]
        public async Task<string> Delete_CategoryByName(string Name)
        {
            bool IsDeleted = await _ShoppingModel.DeleteCategorByName(Name);
            if (IsDeleted)
                return Name + " Category Details Deleted Successfully";
            else
                return Name + " Category Details Not Deleted Successfully";
        }
    }
}