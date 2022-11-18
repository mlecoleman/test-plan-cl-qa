using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;

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
            Vehicle weinermobile = new Vehicle();

            //act
            
            //assert
            using (new AssertionScope())
            {
            weinermobile.NumberOfTires.Should().Be(0);
            weinermobile.GasTankCapacity.Should().Be(0);
            weinermobile.Make.Should().Be("");
            weinermobile.Model.Should().Be("");
            weinermobile.MilesPerGallon.Should().Be(0);
            }
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            //arrange
            Vehicle tricycle = new Vehicle(3, 0, "Radio", "Flyer", 0);

            //act

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
            Vehicle waynesCar = new Vehicle (4, 21, "AMC", "Pacer", 18);
            
            //act
            Action action = () => waynesCar.AddGas(22);
            
            //assert
            action.Should().Throw<GasOverfillException>()
                  .WithMessage("Unable to add 22 gallons to tank because it would exceed the capacity of 21 gallons");
        }   

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("0%", 0)]
        [InlineData("25%", 2.5)]
        [InlineData("50%", 5)]
        [InlineData("75%", 7.5)]
        [InlineData("100%", 10)]
        // [InlineData("MysteryParamValue")]
        public void GasLevelPercentageIsCorrectForAmountOfGas(string percentGasInTank, float gasToAdd)
        {
            //arrange
            Vehicle chittychittybangbang = new Vehicle (4, 10, "Chitty prime", "GEN 11", 30);

            //act
            chittychittybangbang.AddGas(gasToAdd);

            //assert
            chittychittybangbang.GasLevel.Should().Be(percentGasInTank);
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
        [InlineData(1, 0, "Cannot drive, out of gas.", false)]
        [InlineData(1, 5, "Cannot drive due to flat tire.", true)]
        public void DriveNegativeTests(double miles, float gasToAdd, string statusString, bool HasFlatTire)
        {
            //arrange
            Vehicle clownCar = new Vehicle (4, 100, "Lou", "Jacobs", 1);
            clownCar.AddGas(gasToAdd);
            clownCar.HasFlatTire = true;

            //assert
            clownCar.Drive(miles).Should().Be(statusString);
            
        }
        [Theory]
        [InlineData(10, 100, "Drove 10 miles using 10 gallons of gas.", "90%", 90, 10)]
        [InlineData(100, 100, "Drove 100 miles, then ran out of gas.", "0%", 0, 100)]
        public void DrivePositiveTests(double miles, float gasToAdd, string statusString, string percentGasInTank, double milesRemaining, double totalMileage)
        {
            //arrange
            Vehicle mcFlysCar = new Vehicle (4, 100, "DeLorean", "Time Machine", 1);

            //act
            mcFlysCar.AddGas(gasToAdd);

            //assert
            using (new AssertionScope())
            {
                mcFlysCar.Drive(miles).Should().Be(statusString);
                mcFlysCar.GasLevel.Should().Be(percentGasInTank);
                mcFlysCar.MilesRemaining.Should().Be(milesRemaining);
                mcFlysCar.Mileage.Should().Be(totalMileage);
            }
        }
        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            //arrange
            Vehicle batMobile = new Vehicle (4, 100, "Lincoln", "Futura", 1);
        
            //act
            //assert
            Func<Task> act = async () => { await batMobile.ChangeTireAsync(); };
            await act.Should().ThrowAsync<NoTireToChangeException>()
                     .WithMessage("No flat tire to change");
        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            Vehicle boatCar = new Vehicle (4, 100, "Amphicar", "Model 770", 1);
            boatCar.HasFlatTire = true;
            
            //act
            Func<Task> act = async () => { await boatCar.ChangeTireAsync(); };

            //assert
            using (new AssertionScope())
            {
            await act.Should().NotThrowAsync();
            boatCar.HasFlatTire.Should().Be(false);
            }
        }

        /*
        BONUS: Write a unit test that verifies that a flat
        tire will occur after a certain number of miles.
        BONUS: Refactor the GotFlatTire method to make it unit-testable. Write a theory unit test with two cases that verifies that GotFlatTire can be both true and false. This will require you to pass a value for the optional parameter in this method. If you do not attempt this bonus, you may leave GotFlatTire alone.

        */
        [Theory]
        [InlineData(99, 8, 0)]
        [InlineData(99, 8, 1)]
        public void GetFlatTireAfterCertainNumberOfMilesTest(double milesToDrive, int rngSeed, int tires)
        {
            //arrange
            Vehicle coupeUtilityVehicle = new Vehicle (tires, 100, "Chevrolet", "El Camino", 1);
            //act
            coupeUtilityVehicle.AddGas();
            coupeUtilityVehicle.Drive(milesToDrive);
            bool flatTire = coupeUtilityVehicle.GotFlatTire(milesToDrive, rngSeed);
            //assert
            if (tires == 0)
            {
                flatTire.Should().Be(false);
            }
            else if (tires == 4)
            {
                flatTire.Should().Be(true);
            }
        }
    }
}