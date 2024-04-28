using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for AES_Algorithm
/// </summary>
public class AES_Algorithm
{
    public static string AES_Encrypt(string clearText, string EncryptionKey)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    public static string AES_Decrypt(string cipherText, string EncryptionKey)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    //public static void AES_Encrypt(string inputFile, string outputFile, byte[] passwordBytes)
    //{
    //    byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    //    string cryptFile = outputFile;
    //    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

    //    RijndaelManaged AES = new RijndaelManaged();

    //    AES.KeySize = 256;
    //    AES.BlockSize = 128;


    //    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
    //    AES.Key = key.GetBytes(AES.KeySize / 8);
    //    AES.IV = key.GetBytes(AES.BlockSize / 8);
    //    AES.Padding = PaddingMode.Zeros;

    //    AES.Mode = CipherMode.CBC;

    //    CryptoStream cs = new CryptoStream(fsCrypt,
    //         AES.CreateEncryptor(),
    //        CryptoStreamMode.Write);

    //    FileStream fsIn = new FileStream(inputFile, FileMode.Open);

    //    int data;
    //    while ((data = fsIn.ReadByte()) != -1)
    //        cs.WriteByte((byte)data);


    //    fsIn.Close();
    //    cs.Close();
    //    fsCrypt.Close();
    //}

    //public static void AES_Decrypt(string inputFile, string outputFile, byte[] passwordBytes)
    //{
    //    byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    //    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

    //    RijndaelManaged AES = new RijndaelManaged();

    //    AES.KeySize = 256;
    //    AES.BlockSize = 128;


    //    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
    //    AES.Key = key.GetBytes(AES.KeySize / 8);
    //    AES.IV = key.GetBytes(AES.BlockSize / 8);
    //    AES.Padding = PaddingMode.Zeros;

    //    AES.Mode = CipherMode.CBC;

    //    CryptoStream cs = new CryptoStream(fsCrypt,
    //        AES.CreateDecryptor(),
    //        CryptoStreamMode.Read);

    //    FileStream fsOut = new FileStream(outputFile, FileMode.Create);

    //    int data;
    //    while ((data = cs.ReadByte()) != -1)
    //        fsOut.WriteByte((byte)data);

    //    fsOut.Close();
    //    cs.Close();
    //    fsCrypt.Close();
    //}
}