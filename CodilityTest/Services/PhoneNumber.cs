using CodilityTest.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CodilityTest.Services
{
    public class PhoneNumber: IPhoneNumbers
    {
        private readonly int _seed;
        private readonly Func<int> _generate;


        public PhoneNumber(int? seed = null)
        {
            _seed = seed ?? CreateRandomSeed();
            _generate = Integers(0, 10);
        }

        string MaskToString(string mask)
        {
            return string.Join("", MaskToEnumerable(mask));
        }

        IEnumerable<string> MaskToEnumerable(string mask)
        {
            foreach (var character in mask)
            {
                if (character == 'x')
                {
                    yield return this._generate().ToString();
                }
                else
                {
                    yield return character.ToString();
                }
            }
        }

        string NumberFormatToMask(NumberFormat format)
        {
            switch (format)
            {
                case NumberFormat.UKLandLine:
                    return "01xxx xxxxxx";

                case NumberFormat.UKMobile:
                    return "07xxx xxxxxx";

                default:
                    throw new NotSupportedException(string.Format("Format {0} is not supported.", format));
            }
        }

        public string FromMask(string mask)
        {
            return MaskToString(mask);
        }

        public string WithFormat(NumberFormat format)
        {
            return FromMask(NumberFormatToMask(format));
        }

        internal static int CreateRandomSeed()
        {
            return BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 10);
        }
        internal Random CreateRandom()
        {
            return new Random(_seed);
        }

        private Func<int> Integers(int min = 0, int max = 100)
        {
            if (min >= max)
                throw new ArgumentOutOfRangeException("min >= max");

            var random = CreateRandom();

            return () => random.Next(min, max);
        }
    }
}
