using System.Text.RegularExpressions;

namespace OlympOnlineStore.API.Utils;

public static class PhoneNumberUtils
{
    public static string ClearPhoneNumber(this string phoneNumber)
    {
        return Regex.Replace(phoneNumber, @"[^0-9]+", "");
    }
}