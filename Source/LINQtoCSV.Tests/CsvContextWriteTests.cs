using LINQtoCSV;
using Xunit;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace LINQtoCSV.Tests
{
    public class CsvContextWriteTests : Test
    {
        [Fact]
        public void OnlyIncludeFieldsSpecifiedInFieldsToIncludeInOutput()
        {
            // Arrange

            List<ProductData> dataRows_Test = new List<ProductData>();
            dataRows_Test.Add(new ProductData { name = "normal", weight = 7.5, hexProductCode = 0x456, retailPrice = 349.99m });
            dataRows_Test.Add(new ProductData { name = "extra", weight = 6.5, hexProductCode = 0x457, retailPrice = 249.99m, description = "should not appear" });
            dataRows_Test.Add(new ProductData { name = "free", weight = 5.5, hexProductCode = 0x458 });

            CsvFileDescription fileDescription_namesNl2 = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                EnforceCsvColumnAttribute = false,
                TextEncoding = Encoding.Unicode,
                FileCultureName = "nl-Nl", // default is the current culture
                FieldsToIncludeInOutput = new[] { "name", "weight", "code", "price" }
            };

            string expected =
@"name,weight,code,price
normal,""007,500"",1110,""€ 349,99""
extra,""006,500"",1111,""€ 249,99""
free,""005,500"",1112,""€ 0,00""
";

            // Act and Assert

            AssertWrite(dataRows_Test, fileDescription_namesNl2, expected);
        }
    }
}
