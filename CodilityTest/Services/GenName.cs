using CodilityTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CodilityTest.Extension
{
    public class GenName: IGenName
    {
        private static readonly Lazy<string[]> _maleNames = new Lazy<string[]>(GetMaleNames);
        private static readonly Lazy<string[]> _femaleNames = new Lazy<string[]>(GetFemaleNames);
        private static readonly Lazy<string[]> _surnames = new Lazy<string[]>(GetSurnames);
        private readonly Random _rand;
        public GenName()
        {
            _rand = new Random();    
        }

        private static string[] GetMaleNames()
        {
            return GetResourceStrings("dist.male.first.txt");
        }

        private static  string[] GetFemaleNames()
        {
            return GetResourceStrings("dist.female.first.txt");
        }

        private  static string[] GetSurnames()
        {
            return GetResourceStrings("dist.all.last.txt");
        }

        private static string[] GetResourceStrings(string fileName)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DanskeItTask.Data." + fileName))
            using (var reader = new StreamReader(stream))
            {
                var list = new List<string>();
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                        list.Add(line);
                }
                return list.ToArray();
            }
        }

        public string Female()
        {
            // Generate a random index less than the size of the array.  
            int index = _rand.Next(_femaleNames.Value.Length);
            return _femaleNames.Value[index];
            
        }

        public string Male()
        {
            // Generate a random index less than the size of the array.  
            int index = _rand.Next(_maleNames.Value.Length);
            return _maleNames.Value[index];
        }

        public string Surname()
        {
            // Generate a random index less than the size of the array.  
            int index = _rand.Next(_surnames.Value.Length);
            return _surnames.Value[index];
        }
    }
}
