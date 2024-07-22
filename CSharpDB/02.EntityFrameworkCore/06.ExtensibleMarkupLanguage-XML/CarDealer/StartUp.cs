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

            string inputXml = XDocument.Load("../../../Datasets/suppliers.xml").ToString();
            string result = ImportSuppliers(context, inputXml);

            Console.WriteLine(result);           
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierImportDTO[]), new XmlRootAttribute("Suppliers"));
            var dtoImports = (SupplierImportDTO[]?) serializer.Deserialize(new StringReader(inputXml));;

            if (dtoImports == null)
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

            return $"Successfully imported {suppliers.Count()}";
        }
    }
}