using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace CSharpAssignments
{
    public class PatientInformation
    {
       
        public PatientInformation(string mrn)
        {
            this.mrn = mrn;
        }
     
        private string mrn;
       
        public string MRN { get { return this.mrn; } }


       
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }

       
        public string Email;

    }
   

    public static class UtilityExtensions
    {
        public static string Dump(this PatientInformation obj)
        {
            return ($"{obj.MRN},{obj.Name},{obj.Age},{obj.ContactNumber},{obj.Email}");
        }
    }

    


    public class PatientCSVProvider
    {
        public string FilePath { get; set; }
        public List<PatientInformation> GetAllPatients()
        {

            string[] csvdata = File.ReadAllLines(FilePath);

            List<PatientInformation> query = new List<PatientInformation>(from eachline in csvdata
                                                                          let data = eachline.Split(',')
                                                                          select new PatientInformation(data[0])
                                                                          {
                                                                              Name = data[1],
                                                                              Age = Convert.ToInt32(data[2]),
                                                                              ContactNumber = data[3],
                                                                              Email = data[4]
                                                                          });
            return query;
        }
    }

    public class Client
    {
        public void Query()
        {
            PatientCSVProvider provider = new PatientCSVProvider();
            provider.FilePath = @"D:\Practise\CSHARP_TR_DAY_1\CSharpAssignments\patient.csv";
            IEnumerable<PatientInformation> patients = provider.GetAllPatients();
            IEnumerable<PatientInformation> result = patients.Where(p => p.Age > 30);
            foreach (PatientInformation patient in result)
            {
                Console.WriteLine(patient.Dump());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client objclient = new Client();
            objclient.Query();
            Console.Read();
        }
    }
}

