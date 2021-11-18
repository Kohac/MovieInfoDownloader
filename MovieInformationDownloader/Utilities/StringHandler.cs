
namespace MovieInformationDownloader.Utilities;
public static class StringHandler
{
    public static string ReplaceTabCharacters(this string inputedString)
    {
        return inputedString.Replace("\t", "").Trim();
    }
    public static string ReplaceNewLineCharacters(this string inputedString)
    {
        return inputedString.Replace("\n","").Trim();
    }
    public static string ReplaceAllHTMLStaff(this string inputedString)
    {
        string originalData = inputedString;
        while (inputedString.Contains("<") && inputedString.Contains(">"))
        {
            int startIndex = inputedString.IndexOf("<");
            int endIndex = inputedString.IndexOf(">");
            inputedString = inputedString.Remove(startIndex, endIndex + 1 - startIndex);
        }
        return inputedString;
    }
    public static string ReplaceStarterSpace(this string inputedString)
    {
        if (inputedString.Substring(0,1) == " ")
        {
            return inputedString.Substring(1,inputedString.Length - 1);
        }
        return inputedString;
    }
    public static string RemoveButtonNames(this string inputedString)
    {
        string returnedString = inputedString;
        if (inputedString.Contains("(více)"))
        {
            returnedString = returnedString.Replace("(více)", "");
        }
        if (inputedString.Contains("(více)"))
        {
            returnedString = returnedString.Replace("(méně)", "");
        }
        return returnedString;
    }
}
