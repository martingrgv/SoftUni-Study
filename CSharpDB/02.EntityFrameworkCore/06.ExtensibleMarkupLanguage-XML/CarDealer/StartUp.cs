using System.Xml.Linq;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string inputXmlSuppliers = XDocument.Load("Datasets/suppliers.xml").ToString();
            string resultSuppliers = ImportSuppliers(context, inputXmlSuppliers);

            string inputXmlParts = XDocument.Load("Datasets/parts.xml").ToString();
            string resultParts = ImportParts(context, inputXmlParts);

            string inputXmlCars = XDocument.Load("Datasets/cars.xml").ToString();
            string resultCars = ImportCars(context, inputXmlCars);

            string inputXmlCustomers = XDocument.Load("Datasets/customers.xml").ToString();
            string resultCustomers = ImportCustomers(context, inputXmlCustomers);

            Console.WriteLine($"Suppliers: {resultSuppliers}");
            Console.WriteLine($"Parts: {resultParts}");
            Console.WriteLine($"Cars: {resultCars}");
            Console.WriteLine($"Cars: {resultCustomers}");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(
                typeof(SupplierImportDTO[]),
                new XmlRootAttribute("Suppliers")
            );
            var dtoImports = (SupplierImportDTO[]?)
                serializer.Deserialize(new StringReader(inputXml));
            ;

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No suppliers were extracted from xml!");
            }

            var suppliers = dtoImports
                .Select(dto => new Supplier() { Name = dto.Name, IsImporter = dto.IsImporter })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(
                typeof(PartImportDTO[]),
                new XmlRootAttribute("Parts")
            );
            var dtoImports = (PartImportDTO[]?)serializer.Deserialize(new StringReader(inputXml));

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No parts were extracted from xml!");
            }

            var supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

            var partsWithSuppliers = dtoImports
                .Where(dto => supplierIds.Contains(dto.SupplierId))
                .Select(dto => new Part
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(partsWithSuppliers);
            context.SaveChanges();

            return $"Successfully imported {partsWithSuppliers.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(
                typeof(CarImportDTO[]),
                new XmlRootAttribute("Cars")
            );
            var dtoImports = (CarImportDTO[]?)serializer.Deserialize(new StringReader(inputXml));

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No cars were extracted from xml!");
            }

            var existingPartsIds = context.Parts.Select(p => p.Id).ToArray();

            var cars = new List<Car>();

            foreach (var dto in dtoImports)
            {
                var car = new Car()
                {
                    Make = dto.Make,
                    Model = dto.Model,
                    TraveledDistance = dto.TraveledDistance,
                };

                int[] carPartsIds = dto
                    .PartsIds.Where(p => existingPartsIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .Distinct()
                    .ToArray();

                var carParts = new List<PartCar>();

                foreach (var partId in carPartsIds)
                {
                    carParts.Add(
                        new PartCar()
                        {
                            Car = car,
                            CarId = car.Id,
                            PartId = partId
                        }
                    );
                }

                car.PartsCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(
                typeof(CustomerImportDTO[]),
                new XmlRootAttribute("Customers")
            );
            var dtoImports = (CustomerImportDTO[]?)
                serializer.Deserialize(new StringReader(inputXml));

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No customers were extracted from xml!");
            }

            var customers = dtoImports
                .Select(dto => new Customer
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver,
                })
                .ToArray();

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
    }
}
