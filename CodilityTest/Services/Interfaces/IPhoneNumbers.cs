namespace CodilityTest.Services.Interfaces
{
    public enum NumberFormat
    {
        UKMobile,
        UKLandLine
    }

    public interface IPhoneNumbers
    {
        string FromMask(string mask);
        string WithFormat(NumberFormat format);
    }
}
