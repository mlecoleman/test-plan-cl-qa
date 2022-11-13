﻿using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class SemiTruckTests
    {

        //Verify that the SemiTruck constructor creates a new SemiTruck
        //object which is also a Vehicle and has 18 wheels. Verify that the
        //Cargo property for the newly created SemiTruck is a List of
        //CargoItems which is empty, but not null.
        [Fact]
        public void NewSemiTruckIsAVehicleAndHas18TiresAndEmptyCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();

            //act

            //assert
            using (new AssertionScope())
            {
            semiTruck.NumberOfTires.Should().Be(18);
            semiTruck.Cargo.Should().BeEmpty();
            semiTruck.Should().BeAssignableTo<Vehicle>();
            }
        }

        //Verify that adding a CargoItem using LoadCargo does successfully add
        //that CargoItem to the Cargo. Confirm both the existence of the new
        //CargoItem in the Cargo and also that the count of Cargo increased to 1.
        [Fact]
        public void LoadCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            //act
            CargoItem cargoItem = new CargoItem
                {
                    Name = "Rosebud",
                    Description = "Sled",
                    Quantity = 1
                };
            semiTruck.LoadCargo(cargoItem);
            //assert
            using (new AssertionScope())
            {
            semiTruck.Cargo.Should().HaveCount(1);
            semiTruck.Cargo.Should().SatisfyRespectively(
                first =>
                {
                    first.Name.Should().Be("Rosebud");
                    first.Description.Should().Be("Sled");
                    first.Quantity.Should().Be(1);
                }
            );
            }
        }

        //Verify that unloading a cargo item that is in the Cargo does
        //remove it from the Cargo and return the matching CargoItem
        [Fact]
        public void UnloadCargoWithValidCargoTest()
        {
            //arrange
            SemiTruck semiTruck = new SemiTruck();
            //act
            CargoItem boxOfPants = new CargoItem
                {
                    Name = "Box",
                    Description = "Box of Pants",
                    Quantity = 1
                };
            semiTruck.LoadCargo(boxOfPants);
            CargoItem boxOfNotPants = new CargoItem
                {
                    Name = "Box of Not Pants",
                    Description = "Who cares, it's not pants",
                    Quantity = 1
                };
            semiTruck.LoadCargo(boxOfNotPants);
            semiTruck.UnloadCargo("Box of Not Pants");
            //assert
            using (new AssertionScope())
            {
            semiTruck.Cargo.Should().HaveCount(1);
            semiTruck.Cargo.Should().SatisfyRespectively(
                first =>
                {
                    first.Name.Should().Be("Box");
                    first.Description.Should().Be("Box of Pants");
                    first.Quantity.Should().Be(1);
                }
            );
            }
        }

        //Verify that attempting to unload a CargoItem that does not
        //appear in the Cargo throws a System.ArgumentException
        [Fact]
        public void UnloadCargoWithInvalidCargoTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that getting cargo items by name returns all items
        //in Cargo with that name.
        [Fact]
        public void GetCargoItemsByNameWithValidName()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Carto list for an item that does not
        //exist returns an empty list
        [Fact]
        public void GetCargoItemsByNameWithInvalidName()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Cargo list by description for an item
        //that does exist returns all matched items that contain that description.
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithValidDescription()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that searching the Carto list by description for an item
        //that does not exist returns an empty list
        [Fact]
        public void GetCargoItemsByPartialDescriptionWithInvalidDescription()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that the method returns the sum of all quantities of all
        //items in the Cargo
        [Fact]
        public void GetTotalNumberOfItemsReturnsSumOfAllQuantities()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}
