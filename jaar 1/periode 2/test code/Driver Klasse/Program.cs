using System;

class Driver
{
    public string? Naam { get; set; }
    public DateTime BirthDay { get; set; }
    public long DriverLicenseNumber { get; set; }
    public DateTime DriverLicenseValidUntil { get; set; }

    public Driver(string naam, DateTime birthDay)
    {
        Naam = naam;
        BirthDay = birthDay;
    }
    public void Print()
    {
        Console.WriteLine($"Naam: {Naam} | BirthDay: {BirthDay} | Number: {DriverLicenseNumber} | Valid: {DriverLicenseValidUntil}");
    }

    public void UpdateDriverLicense(long? driverLicenseNumber = null, DateTime? driverLicenseValidUntil = null)
    {
        if (driverLicenseNumber.HasValue)
        {
            if (driverLicenseNumber.Value > 100000000)
            {
                DriverLicenseNumber = driverLicenseNumber.Value;
            }
        }

        if (driverLicenseValidUntil.HasValue)
        {
            if (driverLicenseValidUntil.Value > DateTime.Now)
            {
                DriverLicenseValidUntil = driverLicenseValidUntil.Value;
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        Driver nieuw = new Driver("Bas", DateTime.Now);
        // Update only the number
        nieuw.UpdateDriverLicense(51514614614);
        // Update only the validity date (named argument)
        nieuw.UpdateDriverLicense(driverLicenseValidUntil: DateTime.Now.AddYears(5));
        nieuw.Print();
    }
}