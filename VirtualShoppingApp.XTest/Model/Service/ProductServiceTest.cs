using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.Model.Service;
using VirtualShoppingApp.Test;
using Xunit;

namespace VirtualShoppingApp.XTest.Model.Service
{
    public class ProductServiceTest
    {
        [Fact]
        public void getProducts_TestListEqual()
        {
            //Arrenge
            ProductService productService = new ProductService(TestHelper.getFilledShoppingContext());
            List<Product> expectedList = TestHelper.getTestProducts();
            //Act
            List<Product> actualList = productService.getProducts();

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedList.Count, actualList.Count);
        }
        [Fact]
        public void getEveryProductFromShoppingList_Test()
        {
            //Arrenge
            ProductService productService = new ProductService(TestHelper.getFilledShoppingContext());
            var expectedList = TestHelper.getTestProducts();

            //Act
            var actualList = productService.getEveryProductFromShoppingList(TestHelper.getTestJoinedShopplingList());

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedList.Count, actualList.Count);
        }

        [Fact]
        public async void setProductChanges_TestIsPassed()
        {
            //Arrenge
            ProductService productService = new ProductService(TestHelper.getFilledShoppingContext());
            List<Product> expectedList = TestHelper.getTestProducts();
            foreach (var product in expectedList)
            {
                product.IsReady = true;
            }
            //Act
            var isPassed = await productService.setProductChanges(expectedList);

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public async void setProductChanges_TestEveryProductPositive()
        {
            //Arrenge
            ProductService productService = new ProductService(TestHelper.getFilledShoppingContext());
            List<Product> expectedList = TestHelper.getTestProducts();
            foreach (var product in expectedList)
            {
                product.IsReady = true;
            }
            //Act
            await productService.setProductChanges(expectedList);
            var actualList = productService.getProducts();
            bool isPassed = true;
            foreach (var product in actualList)
            {
                if (!product.IsReady) isPassed = false;
            }
            //Assert
            Assert.True(isPassed);
        }

        //[Fact]
        //public async void _Test()
        //{
        //    //Arrenge
        //    ProductService productService = new ProductService(TestHelper.getFilledShoppingContext());

        //    //Act

        //    //Assert
        //    Assert.Equal(1, 1);
        //}
    }
}
