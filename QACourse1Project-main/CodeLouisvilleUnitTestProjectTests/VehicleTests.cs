using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTests
    {

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
        {
            //arrange
            //act
            Vehicle vehicle = new Vehicle();
            
            //assert
            using (new AssertionScope())
            {
            vehicle.NumberOfTires.Should().Be(0);
            vehicle.GasTankCapacity.Should().Be(0);
            vehicle.Make.Should().Be("");
            vehicle.Model.Should().Be("");
            vehicle.MilesPerGallon.Should().Be(0);
            }
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            //arrange
            //act
            Vehicle tricycle = new Vehicle(3, 0, "Radio", "Flyer", 0);

            //assert
            using (new AssertionScope())
            {
            tricycle.NumberOfTires.Should().Be(3);
            tricycle.GasTankCapacity.Should().Be(0);
            tricycle.Make.Should().Be("Radio");
            tricycle.Model.Should().Be("Flyer");
            tricycle.MilesPerGallon.Should().Be(0);
            }
        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax()
        {
            //arrange
            Vehicle mower = new Vehicle (4, 2.4, "John Deere", "S100", 6);

            //act
            mower.AddGas();

            //assert
            mower.GasLevel.Should().Be("100%");
        }

        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
            //arrange
            Vehicle trike = new Vehicle (3, 6, "Harley", "Freewheeler", 33);

            //act
            trike.AddGas(3);

            //assert
            trike.GasLevel.Should().Be("50%");
        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GasLevelPercentageIsCorrectForAmountOfGas(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string �Cannot drive, out of gas.�.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string �Cannot drive due to flat tire.�.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */
        [Theory]
        [InlineData("MysteryParamValue")]
        public void DriveNegativeTests(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        [Theory]
        [InlineData("MysteryParamValue")]
        public void DrivePositiveTests(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}