using Fundamentals.Polymorphism;

namespace Fundamentals.Tests.Polymorphism;

public class ParkingUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GarageOnlyAllowsCars()
    {
        var garage = new Garage { MaxCapacity = 2, Location = "Downtown", NumberOfCompactSpaces = 1 };

        var car = new Car { Length = 20, Make = "Honda", MaxNumberOfPassengers = 50, Model = "Civic", NumberOfWheels = 6, Weight = 3000 };
        var bus = new Bus { Length = 100, Make = "International", MaxNumberOfPassengers = 50, Model = "B-50", NumberOfWheels = 6, Weight = 15000 };
        var truck = new Motorcycle { Length = 5, Make = "Honda", MaxNumberOfPassengers = 2, Model = "600", NumberOfWheels = 2, Weight = 300 };

        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => garage.ParkVehicle(car));
            Assert.Throws<Exception>(() => garage.ParkVehicle(bus));
            Assert.Throws<Exception>(() => garage.ParkVehicle(truck));
        });
    }

    [Test]
    public void OnceGarageFullThrowsException()
    {
        var garage = new Garage { MaxCapacity = 2, Location = "Downtown", NumberOfCompactSpaces = 1 };

        var car = new Car { Length = 20, Make = "Honda", MaxNumberOfPassengers = 50, Model = "Civic", NumberOfWheels = 6, Weight = 3000 };

        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => garage.ParkVehicle(car));
            Assert.DoesNotThrow(() => garage.ParkVehicle(car));
            Assert.Throws<ParkingIsFullException>(() => garage.ParkVehicle(car));
        });
    }

    [Test]
    public void WhenCompactCarParksInGarageItUsesCompactSpace()
    {
        var garage = new Garage { MaxCapacity = 2, Location = "Downtown", NumberOfCompactSpaces = 1 };

        var car = new Car { Length = 20, Make = "Honda", MaxNumberOfPassengers = 50, Model = "Civic", NumberOfWheels = 6, Weight = 3000 };
        var compact = new Car { Length = 20, Make = "Honda", MaxNumberOfPassengers = 50, Model = "Civic", NumberOfWheels = 6, Weight = 1000 };

        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => garage.ParkVehicle(car));
            Assert.That(garage.CurrentCompactSpacesAvailable == 0, Is.False);
            Assert.DoesNotThrow(() => garage.ParkVehicle(compact));
            Assert.That(garage.CurrentCompactSpacesAvailable == 0, Is.True);
            Assert.Throws<ParkingIsFullException>(() => garage.ParkVehicle(car));
        });
    }

    [Test]
    public void ThatLotAllowsAllTypesUpToMax()
    {
        var lot = new Lot { MaxCapacity = 3, Location = "Downtown" };

        var car = new Car { Length = 20, Make = "Honda", MaxNumberOfPassengers = 50, Model = "Civic", NumberOfWheels = 6, Weight = 3000 };
        var bus = new Bus { Length = 100, Make = "International", MaxNumberOfPassengers = 50, Model = "B-50", NumberOfWheels = 6, Weight = 15000 };
        var truck = new Motorcycle { Length = 5, Make = "Honda", MaxNumberOfPassengers = 2, Model = "600", NumberOfWheels = 2, Weight = 300 };

        Assert.Multiple(() =>
        {
            Assert.DoesNotThrow(() => lot.ParkVehicle(car));
            Assert.That(lot.TotalSpacesAvailable == lot.MaxCapacity - 1, Is.True);
            Assert.DoesNotThrow(() => lot.ParkVehicle(bus));
            Assert.That(lot.TotalSpacesAvailable == lot.MaxCapacity - 2, Is.True);
            Assert.DoesNotThrow(() => lot.ParkVehicle(truck));
            Assert.That(lot.TotalSpacesAvailable == lot.MaxCapacity - 3, Is.True);
            Assert.Throws<ParkingIsFullException>(() => lot.ParkVehicle(car));
        });
    }

}
