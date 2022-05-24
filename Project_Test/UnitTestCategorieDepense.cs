using PROJET_FINAL___API.Logics.Models;
using System;
using Xunit;

namespace Project_Test
{
    public class UnitTestCategorieDepense
    {
        [Fact]
        public void TestCategorieDepenseSetdescription()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            CategorieDepenseModel uneCategorieDepense = new CategorieDepenseModel();
            string description = "allo";

            //Act 
            uneCategorieDepense.Description = "allo";

            //Assert
            Assert.Equal(description, uneCategorieDepense.Description);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneCategorieDepense = new CategorieDepenseModel();

            //Act et Assert
            Assert.Throws<Exception>(() => uneCategorieDepense.Description = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestCategorieDepenseSetPourcentage()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            CategorieDepenseModel uneCategorieDepense = new CategorieDepenseModel();
            double pourcentage = 10;

            //Act 
            uneCategorieDepense.Pourcentage = 10;

            //Assert
            Assert.Equal(pourcentage, uneCategorieDepense.Pourcentage);

            //Test avec de mauvaises valeurs...

            //Arrange
            uneCategorieDepense = new CategorieDepenseModel();
            pourcentage = -10;

            //Act et Assert
            Assert.Throws<Exception>(() => uneCategorieDepense.Pourcentage = pourcentage);
        }

    }
}
