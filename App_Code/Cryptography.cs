using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// <summary>
/// Summary description for Cryptography
/// </summary>
public class Cryptography
{
    //public static RSACryptoServiceProvider rsa;

    private static string sKey = "UJYHCX783her*&5@$%#(MJCX**38n*#6835ncv56tvbry(&#MX98cn342cn4*&X#&";

	public Cryptography()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Encrypt(string sPainText)
    {
        if (sPainText.Length == 0)
            return (sPainText);
        return (EncryptString(sPainText, sKey));
    }

    public string Decrypt(string sEncryptText)
    {
        if (sEncryptText.Length == 0)
            return (sEncryptText);
        return (DecryptString(sEncryptText, sKey));
    }

    protected string EncryptString(string InputText, string Password)
    {
        // "Password" string variable is nothing but the key(your secret key) value which is sent from the front end.
        // "InputText" string variable is the actual password sent from the login page.
        // We are now going to create an instance of the
        // Rihndael class.
        RijndaelManaged RijndaelCipher = new RijndaelManaged();
        // First we need to turn the input strings into a byte array.
        byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
        // We are using Salt to make it harder to guess our key
        // using a dictionary attack.
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
        // The (Secret Key) will be generated from the specified
        // password and Salt.
        //PasswordDeriveBytes -- It Derives a key from a password
        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
        // Create a encryptor from the existing SecretKey bytes.
        // We use 32 bytes for the secret key
        // (the default Rijndael key length is 256 bit = 32 bytes) and
        // then 16 bytes for the IV (initialization vector),
        // (the default Rijndael IV length is 128 bit = 16 bytes)
        ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
        // Create a MemoryStream that is going to hold the encrypted bytes
        MemoryStream memoryStream = new MemoryStream();
        // Create a CryptoStream through which we are going to be processing our data.
        // CryptoStreamMode.Write means that we are going to be writing data
        // to the stream and the output will be written in the MemoryStream
        // we have provided. (always use write mode for encryption)
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
        // Start the encryption process.
        cryptoStream.Write(PlainText, 0, PlainText.Length);
        // Finish encrypting.
        cryptoStream.FlushFinalBlock();
        // Convert our encrypted data from a memoryStream into a byte array.
        byte[] CipherBytes = memoryStream.ToArray();
        // Close both streams.
        memoryStream.Close();
        cryptoStream.Close();
        // Convert encrypted data into a base64-encoded string.
        // A common mistake would be to use an Encoding class for that.
        // It does not work, because not all byte values can be
        // represented by characters. We are going to be using Base64 encoding
        // That is designed exactly for what we are trying to do.
        string EncryptedData = Convert.ToBase64String(CipherBytes);
        // Return encrypted string.
        return EncryptedData;
    }

    protected string DecryptString(string InputText, string Password)
    {
        try
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            byte[] EncryptedData = Convert.FromBase64String(InputText);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            // Create a decryptor from the existing SecretKey bytes.
            ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(16), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream(EncryptedData);
            // Create a CryptoStream. (always use Read mode for decryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold EncryptedData;
            // DecryptedData is never longer than EncryptedData.
            byte[] PlainText = new byte[EncryptedData.Length];
            // Start decrypting.
            int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
            memoryStream.Close();
            cryptoStream.Close();
            // Convert decrypted data into a string.
            string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            // Return decrypted string.
           // string DecryptedData = "MX98cn342cn4";
            return DecryptedData;
        }
        catch (Exception exception)
        {
            return (exception.Message);
        }
    }

    //public static void AssignParameter() 
    //{ 
    //    const int PROVIDER_RSA_FULL = 1; 
    //    const string CONTAINER_NAME = "SpiderContainer1"; 
    //    CspParameters cspParams; 
    //    cspParams = new CspParameters(PROVIDER_RSA_FULL); 
    //    cspParams.KeyContainerName = CONTAINER_NAME; 
    //    cspParams.Flags = CspProviderFlags.UseMachineKeyStore; 
    //    cspParams.ProviderName = "Microsoft Strong Cryptographic Provider"; 
    //    rsa = new RSACryptoServiceProvider(cspParams); 
    //}

    //public static string EncryptData(string data2Encrypt,string encpath1)  
    //{	
    //    AssignParameter();
    //    StreamReader reader = new StreamReader(encpath1);	
    //    string publicOnlyKeyXML = reader.ReadToEnd();	
    //    rsa.FromXmlString(publicOnlyKeyXML);	
    //    reader.Close();	
    //    //read plaintext, encrypt it to ciphertext	
    //    byte[] plainbytes =	System.Text.Encoding.UTF8.GetBytes(data2Encrypt);	
    //    byte[] cipherbytes = rsa.Encrypt(plainbytes,false);	
    //    return Convert.ToBase64String(cipherbytes);  
    //}

    // public static void AssignNewKey(string encpath,string decpath)  
    // {	
    //     AssignParameter();		
    //     //provide public and private RSA params	
    //     StreamWriter writer = new StreamWriter(decpath);	
    //     string publicPrivateKeyXML = rsa.ToXmlString(true);	
    //     writer.Write(publicPrivateKeyXML);	writer.Close();
    //     //provide public only RSA params	
    //     writer = new StreamWriter(encpath);
    //     string publicOnlyKeyXML = rsa.ToXmlString(false);	
    //     writer.Write(publicOnlyKeyXML);	
    //     writer.Close();  
    // }

    //public static string DecryptData(string data2Decrypt,string decpath1)  
    //{	
    //    AssignParameter();	
    //    byte[] getpassword = Convert.FromBase64String(data2Decrypt);
    //    StreamReader reader = new StreamReader(decpath1);
    //    string publicPrivateKeyXML = reader.ReadToEnd();
    //    rsa.FromXmlString(publicPrivateKeyXML);	reader.Close();
    //    //read ciphertext, decrypt it to plaintext
        
    //    byte[] plain =	rsa.Decrypt(getpassword,false); 
    //    return System.Text.Encoding.UTF8.GetString(plain);
    //}
}
