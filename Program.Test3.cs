using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Test3
{
    struct FileInformation
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string DataPath { get; set; }
        public DateTime UpdateDate { get; set; }

        public FileInformation(string name, string type, string dataPath, DateTime updateDate)
        {
            Name = name;
            Type = type;
            DataPath = dataPath;
            UpdateDate = updateDate;
        }
    }

    class Program
    {
        const string ColsSeparator = "\t";
        const string RowsSeparator = "\n";
        static void Main(string[] args)
        {
            try
            {
                var testDataFilePath = @"C:\data.txt";
                var outputFilePath = @"C:\data_out.txt";
                if (File.Exists(outputFilePath))
                {
                    List<FileInformation> testData = FillFromTestFile(testDataFilePath);

                    JsonSerializeObject(outputFilePath, testData);
                    var deserializedData = JsonDeserializeObject<List<FileInformation>>(outputFilePath);

                    Console.WriteLine((testData.SequenceEqual(deserializedData)) ? "The same data" : "Different data!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static List<FileInformation> FillFromTestFile(string filePath)
        {
            List<FileInformation> result = new List<FileInformation>();

            string fileData = File.ReadAllText(filePath);
            var Rows = fileData.Split(RowsSeparator);

            for (int i=1; i<Rows.Length; i++)
            {
                var splittedRow = Rows[i].Split(ColsSeparator);
                var fiLoc = new FileInformation(splittedRow[0], splittedRow[1], splittedRow[2], DateTime.Parse(splittedRow[3]));
                result.Add(fiLoc);
            }

            return result;
        }

        public static void JsonSerializeObject<T>(string outputFileName, T objectToSerialize)
        {
            var jsonStr = JsonSerializer.Serialize(objectToSerialize, typeof(T));

            File.WriteAllText(outputFileName, jsonStr);
        }

        public static T JsonDeserializeObject<T>(string inputFileName)
        {
            JsonSerializerOptions jsp = new JsonSerializerOptions();

            var obj = JsonSerializer.Deserialize(File.ReadAllText(inputFileName), typeof(T), jsp);
            return (T) obj;
        }
    }
}
