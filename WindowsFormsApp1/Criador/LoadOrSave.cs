using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace Criador
{
    public class LoadOrSave
    {
        private byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Where to store these keys is the tricky part, 
                                                 // you may need to obfuscate them or get the user to input a password each time
        private byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };

        private DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        /// <summary>
        /// Escreve um arquivo criptografado
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public  void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            //using (var cryptoStream = new CryptoStream(stream, des.CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // This is where you serialize the class
                formatter.Serialize(stream, objectToWrite);
            }

        }

        /// <summary>
        /// Le um Text Criptografado 
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file. || tipo do objeto</typeparam>
        /// <param name="filePath">The file path to read the object instance from.|| Onde o arquivo sera lido/salvo</param>
        /// <returns>Returns a new instance of the object read from the Json file. || retorna o objeto lido </returns>
        public  T ReadFromJsonFile<T>(string filePath) where T : new()
        {

            using (var stream= new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var cryptoStream = new CryptoStream(stream, des.CreateDecryptor(key, iv), CryptoStreamMode.Read))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(cryptoStream);
                
            }
        }
    }
    public static class StringUtil
    {
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        public static string Crypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text)
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(text);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}
