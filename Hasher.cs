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
                case HashType.SHA1:
                    hashBytes = SHA1.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA256:
                    hashBytes = SHA256.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA384:
                    hashBytes = SHA384.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
                case HashType.SHA512:
                    hashBytes = SHA512.Create().ComputeHash(new FileStream(IN_FILE, FileMode.Open));
                    break;
            }
            
            Return MakeHashString(hashBytes);
       }
                    
                  
                    
        /// <summary>
        /// Generate a hash sum of a file
        /// </summary>
        /// <param name="filePath">The file to hash</param>
        /// <param name="algo">The Type of hash</param>
        /// <returns>The computed hash</returns>
        public static string HashFile(string IN_STRING, HashType algo)
        {
            byte[] inStringBytes = null, hashBytes = null;
            inStringBytes = Encoding.ASCII.GetBytes(IN_STRING);
            
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
            buuilder.Clear();
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}
