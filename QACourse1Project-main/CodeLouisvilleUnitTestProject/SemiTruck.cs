using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CodeLouisvilleUnitTestProject
{
    public class SemiTruck : Vehicle
    {
        public List<CargoItem> Cargo { get; private set; }

        /// <summary>
        /// Creates a new SemiTruck that always has 18 Tires
        /// </summary>
        public SemiTruck()
        {
           NumberOfTires = 18;
           Cargo = new List<CargoItem>();
        }

        /// <summary>
        /// Adds the passed CargoItem to the Cargo
        /// </summary>
        /// <param name="item">The CargoItem to add</param>
        public void LoadCargo(CargoItem item)
        {
            Cargo.Add(item);
        }
            
        /// <summary>
        /// Attempts to remove the first item with the passed name from the Cargo and return it
        /// </summary>
        /// <param name="name">The name of the CargoItem to attempt to remove</param>
        /// <returns>The removed CargoItem</returns>
        /// <exception cref="ArgumentException">Thrown if no CargoItem in the Cargo matches the passed name</exception>
        public List<CargoItem> UnloadCargo(string name)
        {
            var cargoItemToRemove = Cargo.FirstOrDefault(CargoItem => CargoItem.Name == name);
            if(cargoItemToRemove != null)
            {
                Cargo.Remove(cargoItemToRemove);
            }
            else
            {
                throw new NoCargoWithThatNameException();
            }
            return Cargo;
        }

        /// <summary>
        /// Returns all CargoItems with the exact name passed. If no CargoItems have that name, returns an empty List.
        /// </summary>
        /// <param name="name">The name to match</param>
        /// <returns>A List of CargoItems with the exact name passed</returns>
        public List<CargoItem> GetCargoItemsByName(string name)
        {
            List<CargoItem> queryNames = new();
            queryNames = Cargo.Where(CargoItem => CargoItem.Name == name).ToList();

            return queryNames;
        }

        /// <summary>
        ///  Returns all CargoItems who have a description containing the passed description. If no CargoItems have that name, returns an empty list.
        /// </summary>
        /// <param name="description">The partial description to match</param>
        /// <returns>A List of CargoItems with a description containing the passed description</returns>
        public List<CargoItem> GetCargoItemsByPartialDescription(string description)
        {
            List<CargoItem> queryDescription = new();
            queryDescription = Cargo.Where(CargoItem => CargoItem.Description.Contains(description)).ToList();

            return queryDescription;
        }

        /// <summary>
        /// Get the number of total items in the Cargo.
        /// </summary>
        /// <returns>An integer representing the sum of all Quantity properties on all CargoItems</returns>
        public int GetTotalNumberOfItems()
        {
            int totalCargoItems = Cargo.Sum(CargoItem => CargoItem.Quantity);
            return totalCargoItems;
        }
    }
}
