using System.Text.Json;

namespace JsonHelloWorldv101
{
    public class InputData
    {
        public string? Message { get; set; }
        public string? Name { get; set; }
    }

    public class OutputData
    {
        public string? NewMessage { get; set; }
        public string? NewName { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            string? json; //Input String
            string outJson = ""; //Output String

            //Reading Input Json and converting it to string
            using (StreamReader r = new StreamReader(@"C:\Users\ABHIK\source\repos\JsonHelloWorldv1.1\Input.json"))
            {
                json = r.ReadToEnd();
                Console.WriteLine(json);
            }
            InputData? inputData = JsonSerializer.Deserialize<InputData>(json);

            //Processing the input Json
            if (inputData!=null && inputData.Message!=null && inputData.Name!=null)
            {
                OutputData? outputData = new()
                {
                    NewMessage = inputData.Message.ToLower(),
                    NewName = inputData.Name.ToUpper()
                };

                //Conversion of .NET object to Json String
                outJson = JsonSerializer.Serialize(outputData);
                Console.WriteLine(outJson);
            }
            
            //Output File Creation and Updation
            string fileName = @"C:\Users\ABHIK\source\repos\JsonHelloWorldv1.1\Output.json";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllText(fileName, outJson);
        }
    }
}
