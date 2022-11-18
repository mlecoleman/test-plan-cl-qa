namespace CodeLouisvilleUnitTestProject
{
    public class GasOverfillException : Exception
    {
        public GasOverfillException(double amountAdded, double capacity)
            : base($"Unable to add {amountAdded} gallons to tank " +
                  $"because it would exceed the capacity of {capacity} gallons")
        { }
    }

    public class NoTireToChangeException : Exception
    {
        public NoTireToChangeException()
            : base($"No flat tire to change")
        { }
    }

    public class NoCargoWithThatNameException : Exception
    {
        public NoCargoWithThatNameException()
            : base($"Sorry bub. You got the wrong truck!")
        { }
    }

    public class Before1995Exception : Exception
    {
        public Before1995Exception()
            : base($"OMG go back to pre 1995 ya geezer - No Data Available for years prior to 1995!")
        { }
    }
}
