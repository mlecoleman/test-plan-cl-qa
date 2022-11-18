using System.Text.Json;
using System.Linq;

namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        public int NumberOfTires = 4;
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
        /*
        Car has a method called IsValidModelForMakeAsync. This method is async and returns a type of Task<bool>. This method has no parameters. The method reaches out to the National Highway Traffic Safety Administration (NHTSA) API via the private HttpClient to determine whether or not the Car’s provided Model is actually a real Model for its Make. If the Model is valid, it returns true. If the Model is not valid, it returns false.
        */
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

        /*
        Car has a method called WasModelMadeInYearAsync. This method is async and returns a type of Task<bool>. This method has one parameter: an integer value representing the year. If the user passes in a year before 1995, this method should throw a System.ArgumentException with a helpful message telling the user no data is available for years before 1995. If the provided year is 1995 or after, this method also reaches out to the NHTSA API via the private HttpClient and determines if the Car’s Make and Model were indeed made during the provided year. If the Make and Model were made in that year, the endpoint returns true. If they were not, it returns false.
        */
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

        /*
        Car has a method called AddPassengers. This method returns void. This method has one parameter, an integer representing the number of passengers to add. The method increases NumberOfPassengers by the amount provided. The method will also reduce the MilesPerGallon the car gets by a value of .2 per passenger.
        */
        public void AddPassengers(int numOfPassengersToAdd)
        {
            NumberOfPassengers = NumberOfPassengers + numOfPassengersToAdd;
            MilesPerGallon = MilesPerGallon - (NumberOfPassengers * 0.2);
            MilesPerGallon = Math.Round(MilesPerGallon, 1);
        }

        /*
        Car has a method called RemovePassengers. This method returns void. This method has one parameter, an integer representing the number of passengers to remove.
        The NumberOfPassengers should not go below zero. If the user attempts to remove more passengers from the car than the car has, set NumberOfPassengers to 0.
        */
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