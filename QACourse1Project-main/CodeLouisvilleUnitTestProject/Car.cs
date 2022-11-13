namespace CodeLouisvilleUnitTestProject
{
    public class Car : Vehicle
    {
        public int NumberOfPassengers { get; private set; }
        string baseUrl = "https://vpic.nhtsa.dot.gov/api/";
        private HttpClient client;
        // Client.BaseAddress = new Uri(baseUrl);


        public Car()
            : this (0, "", "", 0)
        { 
            NumberOfTires = 4;
        }

        public Car(double gasTankCapacity, string make, string model, double milesPerGallon)
        {
            NumberOfTires = 4;
            GasTankCapacity = gasTankCapacity;
            Make = make;
            Model = model;
            MilesPerGallon = milesPerGallon;
            client = new HttpClient();
        }
        // Car has a method called IsValidModelForMakeAsync. This method is async and returns a type of Task<bool>. This method has no parameters. The method reaches out to the National Highway Traffic Safety Administration (NHTSA) API via the private HttpClient to determine whether or not the Car’s provided Model is actually a real Model for its Make. If the Model is valid, it returns true. If the Model is not valid, it returns false. You are responsible for determining how best to accomplish this by reading the provided documentation for that API.
        // Example: Calling this method on a Car with Make = “Honda” and Model = “Civic” should return true. 
        // Example: Calling this method on a Car with Make = “Honda” and Model = “Camry” should return false.
        // Hint: It is STRONGLY recommended that you use json and deserialize the response of your API call into a strongly-typed C# object. This may require creating additional classes.

        // public async Task<bool> IsValidModelForMakeAsync()
        // {
        //     var response = await client.GetAsync(Make, Model);
        //     var content = response.Content.ReadAsStringA sync();
        //     var options = new System.Text.Json.JsonSerializerOptions
        //     {
        //         PropertyNameCaseInsensitive = true
        //     };
        //     var carInfoList = System.Text.Json.JsonSerializer.Deserialize<List<CarStuff>>(content)>>(content, options);
        //     var carInfo = carInfoList.FirstOrDefault();
            
        //     using HttpResponseMessage response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api/");
        //     response.EnsureSuccessStatusCode();
        //     string responseBody = await response.Content.ReadAsStringAsync();
        //     return 
            
        // } 
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
            else if (NumberOfPassengers < numOfPassengersToRemove)
            {
                NumberOfPassengers = 0;
            }
        }
    }
}