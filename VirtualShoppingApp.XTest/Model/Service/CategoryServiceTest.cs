using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShoppingApp.Model.Service;
using Xunit;

namespace VirtualShoppingApp.Test.Model.Service
{
    public class CategoryServiceTest
    {
        [Fact]
        public async void getShoppingListJoined_TestListNumber()
        {
            //Arrenge
            CategoryService storeService = new CategoryService(TestHelper.getFilledShoppingContext());
            int expectedListCount = 3;
            //Act
            var categoriesJoined = await storeService.getShoppingListJoined();
            int actualListCount = categoriesJoined.Count;
            //Assert
            Assert.Equal(actualListCount, expectedListCount);
        }
    }
}
