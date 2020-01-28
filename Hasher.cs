/*
Computes Files Hashes
*/

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SharpUpdate
{
    /// <summary>
    /// The type of hash to create
    /// </summary>
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }

    /// <summary>
    /// Class used to generate hash sums of files
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        /// Generate a hash sum of a file
        /// </summary>
        /// <param name="filePath">The file to hash</param>
        /// <param name="algo">The Type of hash</param>
        /// <returns>The computed hash</returns>
        public static string HashFile(string IN_FILE, HashType algo)
        {
            byte[] hashBytes = null;
            
            switch (algo)
            {
                case HashType.MD5:
                    hashBytes = MD5.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                //ALT    
                case HashType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open)));
                case HashType.SHA256:
                    return MakeHashString(SHA256.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open)));
                case HashType.SHA384:
                    return MakeHashString(SHA384.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open)));
                    
                    
              
                    
                    
        /// <summary>
        /// Generate a hash sum of a file
        /// </summary>
        /// <param name="filePath">The file to hash</param>
        /// <param name="algo">The Type of hash</param>
        /// <returns>The computed hash</returns>
        public static string HashFile(string IN_STRING, HashType algo)
        {
            byte[] hashBytes = null, hashBytes = null;
            inStringBytes = Encoding.ASCII>GetBytes(IN_STRING);
            
            switch (algo)
            {
                 case HashType.MD5:
                    hashBytes = MD5.Create().ComputeHash(inStringBytes);      
                    break;   
                 case HashType.SHA1:
                    hashBytes = SHA1.Create().ComputeHash(inStringBytes);      
                    break;
                       
                case HashType.SHA256:
                    hashBytes = SHA256.Create().ComputeHash(inStringBytes);      
                    break;
                             
                case HashType.SHA384:
                    hashBytes = SHA384.Create().ComputeHash(inStringBytes);      
                    break;
                       
                case HashType.SHA512:
                    hashBytes = SHA512.Create().ComputeHash(inStringBytes);      
                    break;
            }
      
            return MakeHashString(hashBytes);
        }

        /// <summary>
        /// Converts byte[] to string
        /// </summary>
        /// <param name="hash">The hash to convert</param>
        /// <returns>Hash as string</returns>
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
    }
}
