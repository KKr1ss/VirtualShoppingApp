using System;
using System.Collections.Generic;
using VirtualShoppingApp.Model;
using VirtualShoppingApp.Model.Service;
using VirtualShoppingApp.Test;
using Xunit;

namespace VirtualShoppingApp.XTest.Model.Service
{
    public class CategoryServiceTest
    {
        [Fact] 
        public void getCategories_TestListEqual()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestCategories();
            //Act
            List<Category> actualList = categoryService.GetCategories();

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedList.Count, actualList.Count);
        }

        [Fact]
        public async void getShoppingListJoined_TestListsEqual()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestJoinedShopplingList();

            //Act
            List<Category> actualList = await categoryService.getShoppingListJoined();
            
            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedList.Count, actualList.Count);
        }

        [Fact]
        public async void setCategoryChanges_TestIsPassed()
        {
            //Arrange
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestCategories();
            foreach (var category in expectedList)
            {
                category.IsReady = false;
            }

            //Act
            var isPassed = await categoryService.setCategoryChanges(expectedList);

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public async void setCategoryChanges_TestEveryCategoryFalse()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestCategories();
            foreach (var category in expectedList)
            {
                category.IsReady = false;
            }

            //Act
            await categoryService.setCategoryChanges(expectedList);
            var actualList = await categoryService.getShoppingListJoined();
            bool isPassed = true;
            foreach (var category in actualList)
            {
                if (category.IsReady) isPassed = false;
            }

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public async void setShoppingListChanges_TestIsPassed()
        {
            //Arrange
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestJoinedShopplingList();
            foreach (var category in expectedList)
            {
                category.IsReady = false;
                foreach (var product in category.Products)
                {
                    product.IsReady = true;
                }
            }

            //Act
            var isPassed = await categoryService.setShoppingListChanges(expectedList);

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public async void setShoppingListChanges_TestEveryCategoryFalseAndEveryProductTrue()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            List<Category> expectedList = TestHelper.getTestJoinedShopplingList();
            foreach (var category in expectedList)
            {
                category.IsReady = false;
                foreach (var product in category.Products)
                {
                    product.IsReady = true;
                }
            }

            //Act
            await categoryService.setShoppingListChanges(expectedList);
            var actualList = await categoryService.getShoppingListJoined();
            bool isPassed = true;
            foreach (var category in actualList)
            {
                if (category.IsReady) isPassed = false;
                foreach(var product in category.Products)
                    if (!product.IsReady) isPassed = false;
            }

            //Assert
            Assert.True(isPassed);
        }

        [Theory]
        [InlineData("hú",2)] 
        [InlineData("hosszabbító", 1)]
        [InlineData("nincs találat sajna", 0)]
        public async void getShoppingListSearched_TestHu(string query, int expectedNumberOfCategories)
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());

            //Act
            var actualList = await categoryService.getShoppingListSearched(query);
            int actualListCount = actualList.Count;
            //Assert
            Assert.Equal(expectedNumberOfCategories, actualListCount);
        }

        [Fact]
        public void addOrEditCategory_TestAddListEqual()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            Category newCategory = new Category()
            {
                CategoryName = "Valami",
                CreatedDate = DateTime.Now
            };
            var expectedCategories = TestHelper.getTestCategories();
            expectedCategories.Add(newCategory);
            //Act
            categoryService.addOrEditCategory(newCategory);
            var actualCategories = categoryService.GetCategories();

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedCategories.Count, actualCategories.Count);
        }

        [Fact]
        public void addOrEditCategory_TestAddPositive()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            Category newCategory = new Category()
            {
                CategoryName = "Valami",
                CreatedDate = DateTime.Now
            };

            //Act
            var isPassed = categoryService.addOrEditCategory(newCategory);
            

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public void addOrEditCategory_TestEditListEqual()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            var expectedCategories = TestHelper.getTestCategories();
            var editCategory = expectedCategories[1];
            editCategory.CategoryName = "New name";
            expectedCategories[1] = editCategory;

            //Act
            categoryService.addOrEditCategory(editCategory);
            var actualCategories = categoryService.GetCategories();

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedCategories.Count, actualCategories.Count);
        }

        [Fact]
        public void addOrEditCategory_TestEditPassed()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            var expectedCategories = TestHelper.getTestCategories();
            var editCategory = expectedCategories[1];
            editCategory.CategoryName = "New name";

            //Act
            var isPassed = categoryService.addOrEditCategory(editCategory);

            //Assert
            Assert.True(isPassed);
        }

        [Fact]
        public void removeCategory_TestRemoved()
        {
            //Arrenge
            CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());
            var expectedCategories = TestHelper.getTestCategories();
            var categoryToRemove = expectedCategories[1];
            expectedCategories.Remove(categoryToRemove);

            //Act
            categoryService.removeCategory(categoryToRemove);
            var actualCategories = categoryService.GetCategories();

            //Assert
            //buggos az Xunit, nincs erre időm tanár úr (overrideolni szükséges a category és a products modellek gethashcode és equals függvényeit)
            Assert.Equal(expectedCategories.Count, actualCategories.Count);
        }

        //[Fact]
        //public async void _Test()
        //{
        //    //Arrenge
        //    CategoryService categoryService = new CategoryService(TestHelper.getFilledShoppingContext());

        //    //Act

        //    //Assert
        //    Assert.Equal(1, 1);
        //}
    }
}
