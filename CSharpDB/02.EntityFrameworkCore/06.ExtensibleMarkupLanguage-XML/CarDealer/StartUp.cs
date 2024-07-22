using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            string inputXml = XDocument.Load("../../../Datasets/parts.xml").ToString();
            string result = ImportParts(context, inputXml);

            Console.WriteLine(result);           
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierImportDTO[]), new XmlRootAttribute("Suppliers"));
            var dtoImports = (SupplierImportDTO[]?) serializer.Deserialize(new StringReader(inputXml));;

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No suppliers were extracted from xml!");
            }

            var suppliers = dtoImports.Select(dto => new Supplier()
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter
            })
            .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartImportDTO[]), new XmlRootAttribute("Parts"));
            var dtoImports = (PartImportDTO[]?)serializer.Deserialize(new StringReader(inputXml));

            if (dtoImports == null || dtoImports.Length == 0)
            {
                throw new InvalidOperationException("No parts were extracted from xml!");
            }

            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

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
    }
}