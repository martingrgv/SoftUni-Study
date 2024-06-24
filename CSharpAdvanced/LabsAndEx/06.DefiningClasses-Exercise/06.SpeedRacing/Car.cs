﻿using System.Diagnostics.SymbolStore;
using System.Text;

namespace DefiningClasses;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double travelledDistance;

    public Car()
    {
        this.TravelledDistance = 0;
    }

    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) : this()
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumptionPerKilometer
    {
        get { return this.fuelConsumptionPerKilometer; }
        set { this.fuelConsumptionPerKilometer = value; }
    }

    public double TravelledDistance
    {
        get { return this.travelledDistance; }
        set { this.travelledDistance = value; }
    }

    public void Drive(double distance)
    {
        if (this.FuelAmount - (distance * this.FuelConsumptionPerKilometer) >= 0)
        {
            this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
            this.TravelledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
    }
}