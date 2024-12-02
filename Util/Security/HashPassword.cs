using System.Security.Cryptography;
using System.Text;

public static class HashPassword
{
    public static string ComputeSHA256Hash(string rawData)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte bytes in hash)
            {
                stringBuilder.Append(bytes.ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}