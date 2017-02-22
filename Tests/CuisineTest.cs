using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantCuisine
{
    public class CuisineTest : IDisposable
    {
        public CuisineTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=restaurantdb_test;Integrated Security=SSPI;";
        }

        // FACTS go here
        [Fact]
        public void Test_CuisineEmptyAtFirst()
        {
            //Arrange
            int result = Cuisine.GetAll().Count;

            //Act

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_IdentityTest_ReturnTrueIfCuisinessAreIdentitical()
        {
            Cuisine cuisine1 = new Cuisine("Italian");
            Cuisine cuisine2 = new Cuisine("Italian");

            Assert.Equal(cuisine1, cuisine2);
        }

        [Fact]
        public void Save_SavesCuisineInDatabase_ReturnNewId()
        {
            Cuisine testCuisine = new Cuisine("Italian");
            testCuisine.Save();

            Cuisine retrievedCuisine = Cuisine.GetAll()[0];

            Assert.Equal(testCuisine, retrievedCuisine);
        }

        [Fact]
        public void Find_LocateCuisineInDatabase_ReturnDesiredCuisine()
        {
            Cuisine testCuisine = new Cuisine("Italian");
            testCuisine.Save();

            Cuisine retrievedCuisine = Cuisine.Find(testCuisine.GetId());

            Assert.Equal(testCuisine, retrievedCuisine);
        }
        
        [Fact]
        public void Test_GetRestaurants_RetrievesAllRestaurantsWithCuisine()
        {

        }

        public void Dispose()
        {
            Cuisine.DeleteAll();
        }
    }
}