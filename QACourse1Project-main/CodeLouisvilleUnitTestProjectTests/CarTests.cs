using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTests
    {
        /*
        Constructor: verify that newly created Car instances are also Vehicles and have 4 tires.
        */
        [Fact]
        public void NewCarIsAVehicleAndHas4Tires()
        {
            //arrange
            Car ptLooser = new Car();

            //act
            
            //assert
            using (new AssertionScope())
            {
            ptLooser.NumberOfTires.Should().Be(4);
            ptLooser.GasTankCapacity.Should().Be(0);
            ptLooser.Make.Should().Be("");
            ptLooser.Model.Should().Be("");
            ptLooser.MilesPerGallon.Should().Be(0);
            ptLooser.Should().BeAssignableTo<Vehicle>();
            }
        }

        /*
        Test that a Make of Honda and a Model of Civic is valid. Test that a Make of Honda and a Model of Camry is not.
        */
        [Theory]
        [InlineData("Honda", "Civic", true)]
        [InlineData("Honda", "Camry", false)]
        public async Task IsValidModelForMakeAsync(string carmake, string carmodel, bool makemodel)
        {
            //arrange
            Car car = new Car(0, carmake, carmodel, 0);

            //act
            bool validMakeModel = await car.IsValidModelForMakeAsync();
            
            //assert
            validMakeModel.Should().Be(makemodel);
        }

        /*  
        * Negative Test: passing a value for year that is before 1995 throws a System.ArgumentException.
        * Positive Test: Each of these values return the expected result:
        * A Make that does not exist at all returns false (regardless of model/year).
        * Make Honda, Model Camry returns false (regardless of year).
        * Make Subaru, Model WRX returns true for year 2020.
        * Make Subaru, Model WRX returns false for year 2000.
        */
        [Fact]
        public async Task WasModelMadeInYearAsyncNegativeTest()
        {
            //arrange
            Car car = new Car(0, "pants", "pants", 0);

            //act

            //assert
            Func<Task> act = async () => { await car.WasModelMadeInYearAsync(1988); };
            await act.Should().ThrowAsync<Before1995Exception>();
        }

        [Theory]
        [InlineData("Pants", "Accord", 2000, false)]
        [InlineData("Honda", "Camry", 2000, false)]
        [InlineData("Subaru", "WRX", 2020, true)]
        [InlineData("Subaru", "WRX", 2000, false)]
        public async Task WasModelMadeInYearAsyncPositiveTest(string carmake, string carmodel, int year, bool after1995)
        {
            //arrange
            Car car = new Car(0, carmake, carmodel, 0);

            //act
            bool validMakeModel = await car.WasModelMadeInYearAsync(year);

            //assert
            validMakeModel.Should().Be(after1995);
        }

        /* 
        AddPassengers test: Test that adding passengers to the car reduces the fuel economy of the car by .2 per passenger. Test that removing the passengers then adds back the fuel economy. 
        */
        [Theory]
        [InlineData(2, 0, 9.6)]
        [InlineData(0, 0, 10)]
        [InlineData(2, 1, 9.8)]
        public void VerifyEachPassengerReducesGasMileage(int numOfPassengersToAdd, int numOfPassengersToRemove, double expectedGasMileage)
        {
            //arrange
            Car car = new Car(10, "carmake", "carmodel", 10);

            //act
            car.AddPassengers(numOfPassengersToAdd);
            car.RemovePassengers(numOfPassengersToRemove);

            //assert
            car.MilesPerGallon.Should().Be(expectedGasMileage);
        }

        /*
        RemovePassengers test: Using a Theory, test the following:
        -Create a Car with 5 passengers that gets 21 MPG. Remove 3 passengers from the car. Verify the car now has 2 passengers and gets 20.6 MPG.
        -Create a Car with 5 passengers that gets 21 MPG. Remove 5 passengers from the car. Verify the car now has 0 passengers and gets 21 MPG.
        -Create a Car with 5 passengers that gets 21 MPG. Remove 25 passengers from the car. Verify the car now has 0 passengers and gets 21 MPG.
        */
        [Theory]
        [InlineData(5, 21, 3, 2, 20.6)]
        [InlineData(5, 21, 5, 0, 21)]
        [InlineData(5, 21, 25, 0, 21)]
        public void RemovePassengersTest(int passengersToAdd, int milesPerGallon, int passengersToRemove, int expectedPassengers, double expectedGasMileage)
        {
            //arrange
            Car car = new Car(10, "carmake", "carmodel", milesPerGallon);

            //act
            car.AddPassengers(passengersToAdd);
            car.RemovePassengers(passengersToRemove);
            
            //assert
            using (new AssertionScope())
            {
                car.MilesPerGallon.Should().Be(expectedGasMileage);
                car.NumberOfPassengers.Should().Be(expectedPassengers);
            }
        }
    }
}