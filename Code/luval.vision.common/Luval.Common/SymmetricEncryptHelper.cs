// Decompiled with JetBrains decompiler
// Type: Luval.Common.SymmetricEncryptHelper
// Assembly: Luval.Common, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B992C692-7E84-45DD-86CD-7314208BE4E5
// Assembly location: C:\Users\Kenneth Hidalgo\Documents\Devs\Celeris(git)\luval-vision\Libraries\Luval.Common.dll

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Luval.Common
{
  public class SymmetricEncryptHelper
  {
    public string ProviderName { get; }

    public string Key { get; }

    public string IV { get; }

    public SymmetricEncryptHelper(string key, string iv)
      : this("RijndaelManaged", key, iv)
    {
    }

    public SymmetricEncryptHelper(string algorithmName, string key, string iv)
    {
      this.ProviderName = algorithmName;
      this.Key = key;
      this.IV = iv;
    }

    public byte[] Encrypt(byte[] data)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (SymmetricAlgorithm symmetricAlgorithm = SymmetricAlgorithm.Create(this.ProviderName))
        {
          using (CryptoStream s = new CryptoStream((Stream) memoryStream, symmetricAlgorithm.CreateEncryptor(this.ToArray(this.Key), this.ToArray(this.IV)), CryptoStreamMode.Write))
          {
            s.Write(data, 0, data.Length);
            return s.ReadToEnd();
          }
        }
      }
    }

    public string Encrypt(string data, Encoding encoding)
    {
      return encoding.GetString(this.Encrypt(encoding.GetBytes(data)));
    }

    public string Encrpyt(string data)
    {
      return this.Encrypt(data, Encoding.UTF8);
    }

    public byte[] Decrypt(byte[] data)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        using (SymmetricAlgorithm symmetricAlgorithm = SymmetricAlgorithm.Create(this.ProviderName))
        {
          using (CryptoStream s = new CryptoStream((Stream) memoryStream, symmetricAlgorithm.CreateDecryptor(this.ToArray(this.Key), this.ToArray(this.IV)), CryptoStreamMode.Read))
            return s.ReadToEnd();
        }
      }
    }

    public string Decrypt(string data, Encoding encoding)
    {
      return encoding.GetString(this.Decrypt(encoding.GetBytes(data)));
    }

    public string Decrypt(string data)
    {
      return this.Decrypt(data, Encoding.UTF8);
    }

    private byte[] ToArray(string str)
    {
      return Encoding.UTF8.GetBytes(str);
    }
  }
}
