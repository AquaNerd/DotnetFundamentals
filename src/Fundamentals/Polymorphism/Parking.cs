namespace Fundamentals.Polymorphism;

public abstract class VehicleBase
{
    public required string Make { get; init; }
    public required string Model { get; init; }
    public required int NumberOfWheels { get; init; }
    public required decimal Length { get; init; }
    public required decimal Weight { get; init; }
    public required int MaxNumberOfPassengers { get; init; }
}

public enum ParkingPlaces { Lot, Garage }

public class Car : VehicleBase { }

public class Motorcycle : VehicleBase { }

public class Bus : VehicleBase { }

public interface IParking
{
    void ParkVehicle(VehicleBase vehicle);
}

public class ParkingIsFullException : Exception
{
    public override string Message => "Parking is full!";
}

public abstract class ParkingFacility : IParking
{
    public required int MaxCapacity { get; init; }
    public required string Location { get; init; }

    public int TotalSpacesAvailable => MaxCapacity - _vehicles.Count;

    protected List<VehicleBase> _vehicles { get; set; } = new List<VehicleBase>();

    public virtual void ParkVehicle(VehicleBase vehicle)
    {
        if (TotalSpacesAvailable == 0)
        {
            throw new ParkingIsFullException();
        }
        else
        {
            _vehicles.Add(vehicle);
        }
    }

    public override string ToString() =>
        TotalSpacesAvailable == 0 ? $"Parking is full!" : $"Total Spaces Available: {TotalSpacesAvailable}";
}

public class Lot : ParkingFacility
{
    public override string ToString() =>
        TotalSpacesAvailable == 0 ? $"Parking Lot is full!" : @$"Total Spaces Available: {TotalSpacesAvailable}";
}

public class Garage : ParkingFacility
{
    public required int NumberOfCompactSpaces { get; init; }

    public int CurrentCompactSpacesAvailable => NumberOfCompactSpaces - _compactSpacesUsed;

    private int _compactSpacesUsed { get; set; }

    public override void ParkVehicle(VehicleBase vehicle)
    {
        switch (vehicle)
        {
            case Car:
                if (TotalSpacesAvailable == 0)
                {
                    throw new ParkingIsFullException();
                }
                else
                {
                    if (vehicle.Weight < 1500)
                    {
                        _compactSpacesUsed++;
                    }
                    _vehicles.Add(vehicle);
                }
                break;
            default:
                throw new Exception("Only cars are allowed in garage");
        }
    }

    public override string ToString() =>
        TotalSpacesAvailable == 0 ? $"Parking Garage is full!" : @$"Total Spaces Available: {TotalSpacesAvailable}; Compact Spaces Available: {CurrentCompactSpacesAvailable}";
}
