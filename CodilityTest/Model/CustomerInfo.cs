using System;

namespace CodilityTest.Model
{
    public class CustomerInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public DateTimeOffset BirthDate { get; set; }

    }
}
