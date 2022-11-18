using System.Text.Json;
using System.Linq;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        public int Numberoftires = 4;
        private HttpClient _client;
        public Car()
            : this (0, "", "", 0)
        { 
        }
        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
        {
            GasTankCapacity = gasTankCapacity;
            Make = make;
            Model = model;
            MilesPerGallon = milesPerGallon;
            _client = new HttpClient()
            {
                BaseAddress = new Uri("https://vpic.nhtsa.dot.gov/api/")
            };
        }
        // Car has a method called IsValidModelForMakeAsync. This method is async and returns a type of Task<bool>. This method has no parameters. The method reaches out to the National Highway Traffic Safety Administration (NHTSA) API via the private HttpClient to determine whether or not the Car’s provided Model is actually a real Model for its Make. If the Model is valid, it returns true. If the Model is not valid, it returns false. You are responsible for determining how best to accomplish this by reading the provided documentation for that API.
        // Example: Calling this method on a Car with Make = “Honda” and Model = “Civic” should return true. 
        // Example: Calling this method on a Car with Make = “Honda” and Model = “Camry” should return false.
        // Hint: It is STRONGLY recommended that you use json and deserialize the response of your API call into a strongly-typed C# object. This may require creating additional classes.

        public async Task<bool> IsValidModelForMakeAsync()
        {
            string urlSuffix = $"vehicles/GetModelsForMake/{Make}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            var wasThereARecord = data.Results.FirstOrDefault(r => r.Model_Name == Model);
            if (wasThereARecord == null)
                return false;
            else return true;
        } 

        public async Task<bool> WasModelMadeInYearAsync(int year)
        {
            if(year < 1995)
            {
                throw new Before1995Exception();
            }
            string urlSuffix = $"vehicles/getmodelsformakeyear/make/{Make}/modelyear/{year}?format=json";
            var response = await _client.GetAsync(urlSuffix);
            var rawJson = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<GetModelsForMakeYearResponseModel>(rawJson);
            var wasThereARecord = data.Results.FirstOrDefault(r => r.Model_Name == Model);
            if (wasThereARecord == null)
                return false;
            else return true;
        }
        public void AddPassengers(int numOfPassengersToAdd)
        {
            NumberOfPassengers = NumberOfPassengers + numOfPassengersToAdd;
            MilesPerGallon = MilesPerGallon - (NumberOfPassengers * 0.2);
            MilesPerGallon = Math.Round(MilesPerGallon, 1);
        }
        public void RemovePassengers(int numOfPassengersToRemove)
        {
            if (NumberOfPassengers >= numOfPassengersToRemove)
            {
                NumberOfPassengers = NumberOfPassengers - numOfPassengersToRemove;
                MilesPerGallon = MilesPerGallon + (numOfPassengersToRemove * 0.2);
                MilesPerGallon = Math.Round(MilesPerGallon, 1);
            }
            else if (NumberOfPassengers <= numOfPassengersToRemove)
            {
                MilesPerGallon = MilesPerGallon + (NumberOfPassengers * 0.2);
                NumberOfPassengers = 0;
                MilesPerGallon = Math.Round(MilesPerGallon, 1);
            }
        }
    }
}