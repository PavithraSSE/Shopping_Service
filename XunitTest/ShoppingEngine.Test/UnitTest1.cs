using System;
using System.Collections;
using Xunit;
using ShoppingProcessor;
using System.Collections.Generic;
using ShoppingProcessor.Interface;
using ShoppingDAL;
using Microsoft.Extensions.Configuration;
using System.Dynamic;
using ShoppingService.Controllers;

namespace ShoppingEngine.Test
{
    public class UnitTest1:IClassFixture<ShoppingModel>
    {
        private readonly IShoppingModel _ShoppingModel;
        public UnitTest1(ShoppingModel shoppingModel)
        {
            _ShoppingModel = shoppingModel;
            var config = new ConfigurationBuilder().AddJsonFile("TestConfig.json").Build();
            DBconnection DBconnection = new DBconnection(config["ConnectionString"]);
        }
        [Theory]
        [MemberData(nameof(Get_ItemsByName_SampleData))]
        public void Test_ItemsByNameController(CategoryRQ categoryRQ, List<CategoryRS> ExpectedResult)
        {
            dynamic response = new ExpandoObject();
            var controller = new ShoppingController(_ShoppingModel);
            response = controller.Get_ItemsByName(categoryRQ);
            List<CategoryRS>  actualResult = (List<CategoryRS>)response;
            Assert.Equal(ExpectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(Get_DeleteItemByName_SampleData))]
        public void Test_DeleteItemsByNameController(string Name, string ExpectedResult)
        {
            dynamic response = new ExpandoObject();
            var controller = new ShoppingController(_ShoppingModel);
            response = controller.Delete_CategoryByName(Name);
            string actualResult = (string)response;
            Assert.Equal(ExpectedResult, actualResult);
        }

        [Theory]
        [MemberData(nameof(DeleteCategorByName_SampleData))]
        public void Test_DeleteCategorByName(string Name, bool ExpectedResult)
        {
            dynamic response = new ExpandoObject();
            response = _ShoppingModel.DeleteCategorByName(Name);
            bool actualResult = (bool)response;
            Assert.Equal(ExpectedResult, actualResult);
        }

        public static IEnumerable<object[]> Get_ItemsByName_SampleData()
        {
            CategoryRQ categoryRQ = new CategoryRQ();
            categoryRQ.CategoryName = "Dress";
            List<CategoryRS> categoryRS = new List<CategoryRS>();

            CategoryRS categoryRS1 = new CategoryRS();
            categoryRS1.CategoryName = "Dress";
            categoryRS1.SubCategoryName = "Sarees";
            categoryRS1.ItemName = "Silk Sarees";
            categoryRS1.ItemDescription = "Hard and Softsilks are available";
            categoryRS.Add(categoryRS1);

            CategoryRS categoryRS2 = new CategoryRS();
            categoryRS2.CategoryName = "Dress";
            categoryRS2.SubCategoryName = "Sarees";
            categoryRS2.ItemName = "Cotton Sarees";
            categoryRS2.ItemDescription = "Pure and semi cotton sarees are available";
            categoryRS.Add(categoryRS2);

            CategoryRS categoryRS3 = new CategoryRS();
            categoryRS3.CategoryName = "Dress";
            categoryRS3.SubCategoryName = "Tops";
            categoryRS3.ItemName = "Leggin Tops";
            categoryRS3.ItemDescription = "All colors are available";
            categoryRS.Add(categoryRS3);

            CategoryRS categoryRS4 = new CategoryRS();
            categoryRS4.CategoryName = "Dress";
            categoryRS4.SubCategoryName = "Tops";
            categoryRS4.ItemName = "Jean Tops";
            categoryRS4.ItemDescription = "All colors are available";
            categoryRS.Add(categoryRS4);

            CategoryRS categoryRS5 = new CategoryRS();
            categoryRS5.CategoryName = "Dress";
            categoryRS5.SubCategoryName = "Jeans";
            categoryRS5.ItemName = "Ladies Jeans";
            categoryRS5.ItemDescription = "All Types are available";
            categoryRS.Add(categoryRS5);

            CategoryRS categoryRS6 = new CategoryRS();
            categoryRS6.CategoryName = "Dress";
            categoryRS6.SubCategoryName = "Jeans";
            categoryRS6.ItemName = "Boys Jeans";
            categoryRS6.ItemDescription = "All Types are available";
            categoryRS.Add(categoryRS6);


            yield return new object[] { categoryRQ, categoryRS };
        }

        public static IEnumerable<object[]> Get_DeleteItemByName_SampleData()
        {
            string Name = "Beauty";
            string expectedResult = "Beauty Category Details Deleted Successfully";
            yield return new object[] { Name, expectedResult };
        }

        public static IEnumerable<object[]> DeleteCategorByName_SampleData()
        {
            string Name = "Grocery";
            bool expectedResult = true;
            yield return new object[] { Name, expectedResult };
        }
    }
}
