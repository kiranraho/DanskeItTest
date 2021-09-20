using CodilityTest.Extension;
using CodilityTest.Model;
using CodilityTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodilityTest.Data
{
    public class Repository : IRepository
    {
        private readonly IGenName _genName;
        private readonly IPhoneNumbers _genPhoneNumber;
        private readonly List<CustomerInfo> _iList;
        public Repository(IGenName genName, IPhoneNumbers genPhoneNumber)
        {
            _genName = genName;
            _genPhoneNumber = genPhoneNumber;
            _iList = new List<CustomerInfo>();
        }
        public CustomerInfo CreateNewCustomer()
        {
            string gender = GenarateCustomer.Gender();
            int age = GenarateCustomer.Age();
            string bdate = $"{GenarateCustomer.Month()}-{GenarateCustomer.Date()}-{GenarateCustomer.Year(age)}";
            CustomerInfo costomerInfo = new CustomerInfo()
            {
                Gender = gender,
                Name = (gender == "Male") ? _genName.Male() : _genName.Female(),
                Surname = _genName.Surname(),
                PhoneNumber = _genPhoneNumber.WithFormat(NumberFormat.UKMobile),
                Citizenship ="UnitedKingDom",
                PersonalCode = GenarateCustomer.Code(),
                Age = age,
                BirthDate = DateTimeOffset.Parse(bdate)
            };
            _iList.Add(costomerInfo);
            return costomerInfo;
        }

        public List<CustomerInfo> GetAllCustomers()
        {
            return _iList;
        }

        public CustomerInfo GetCustomerByName(string firstName, string surName)
        {
            return _iList.FirstOrDefault(x=> x.Name == firstName  && x.Surname== surName );
        }
    }
}
