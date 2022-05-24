using PROJET_FINAL___API.Controllers;
using PROJET_FINAL___API.Logics.DTOs;
using PROJET_FINAL___API.Logics.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project_Test
{
    public class UnitTestControleurGarderie
    {
        [Fact]
        public void Test1ObtenirListeGarderie()
        {
            // Arrange
            GarderieController controller = new GarderieController();
            int garderieCount = 5;
            string garderieNom1 = "ZouzouCare";

            // Act
            List<GarderieDTO> liste = controller.ObtenirListeGarderie();

            // Assert
            Assert.NotNull(liste);
            Assert.Equal(garderieCount, liste.Count);
            Assert.Equal(garderieNom1, liste[0].Nom);
        }

        [Fact]
        public void Test2AjouterCegep()
        {
            //Test avec une garderie valide...
            // Arrange
            GarderieController controller = new GarderieController();
            int garderieCount = 6;
            string garderieNom5 = "Garderie au pays magique";

            // Act
            controller.AjouterGarderie(new GarderieDTO("Garderie au pays magique", "aaa rue aaa", "Sherbooke", "F5G 5A5", "9999999998"));
            List<GarderieDTO> liste = controller.ObtenirListeGarderie();

            // Assert
            Assert.NotNull(liste);
            Assert.Equal(garderieCount, liste.Count);
            Assert.Equal(garderieNom5, liste[5].Nom);

            //Test avec un Cégep existant...
            // Arrange
            controller = new GarderieController();
            garderieCount = 6;
            garderieNom5 = "Garderie au pays magique";

            // Act
            controller.AjouterGarderie(new GarderieDTO("Garderie au pays magique", "aaa rue aaa", "Sherbooke", "Québec", "999-999-9999"));
            liste = controller.ObtenirListeGarderie();

            // Assert
            Assert.NotNull(liste);
            Assert.Equal(garderieCount, liste.Count);
            Assert.Equal(garderieNom5, liste[5].Nom);

            //Clean
            controller.SupprimerGarderie("Garderie au pays magique");
        }
    }
}
