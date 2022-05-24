using PROJET_FINAL___API.Logics.Models;
using System;
using Xunit;

namespace Project_Test
{
    public class UnitTestCommerce
    {
        [Fact]
        public void TestCommerceSetdescription()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            CommerceModel unCommerce = new CommerceModel();
            string description = "allo";

            //Act 
            unCommerce.Description = "allo";

            //Assert
            Assert.Equal(description, unCommerce.Description);

            //Test avec de mauvaises valeurs...

            //Arrange
            unCommerce = new CommerceModel();

            //Act et Assert
            Assert.Throws<Exception>(() => unCommerce.Description = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestCommerceSetAdresse()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            CommerceModel unCommerce = new CommerceModel();
            string adresse = "325 rue St-Pierre";

            //Act 
            unCommerce.Adresse = "325 rue St-Pierre";

            //Assert
            Assert.Equal(adresse, unCommerce.Adresse);

            //Test avec de mauvaises valeurs...

            //Arrange
            unCommerce = new CommerceModel();

            //Act et Assert
            Assert.Throws<Exception>(() => unCommerce.Adresse = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }

        [Fact]
        public void TestCommerceSetTelephone()
        {
            //Test avec de bonnes valeurs...

            //Arrange
            CommerceModel unCommerce = new CommerceModel();
            string telephone = "067 919-0839";

            //Act 
            unCommerce.Telephone = "067 919-0839";

            //Assert
            Assert.Equal(telephone, unCommerce.Telephone);

            //Test avec de mauvaises valeurs...

            //Arrange
            unCommerce = new CommerceModel();

            //Act et Assert
            Assert.Throws<Exception>(() => unCommerce.Telephone = "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
        }
    }
}
