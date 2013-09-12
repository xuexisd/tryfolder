using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sunny.Common.Security.Server
{
    public class SymmetricMethod
    {
        /// <summary>   
        /// 获得密钥   
        /// </summary>   
        /// <returns>密钥</returns>   
        private static byte[] GetLegalKeyC()
        {
            string sTemp = @"Wow(%&hj7x82H$yuBI$456F2Lyj5&fbSBFCy76*h%(HiiJ$lhj!y6&(**)asi975";

            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>   
        /// 获得初始向量IV   
        /// </summary>   
        /// <returns>初试向量IV</returns>   
        private static byte[] GetLegalIVC()
        {
            string sTemp = @"Popoo*Ghg7!rNIfb&95GUY87LyjhUb#er57SBh(u%g6HJ($$)Wk7&!hg4ui%$movie";

            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>   
        /// 加密方法   
        /// </summary>   
        /// <param name="Source">待加密的串</param>   
        /// <returns>经过加密的串</returns>   
        public static string EncryptoC(string Source)
        {
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKeyC();
            mobjCryptoService.IV = GetLegalIVC();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }
        /// <summary>   
        /// 解密方法   
        /// </summary>   
        /// <param name="Source">待解密的串</param>   
        /// <returns>经过解密的串</returns>   
        public static string DecryptoC(string Source)
        {
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKeyC();
            mobjCryptoService.IV = GetLegalIVC();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        /// <summary>   
        /// 获得密钥   
        /// </summary>   
        /// <returns>密钥</returns>   
        private static byte[] GetLegalKeyS()
        {
            string sTemp = @"Uhn(%&hj7x82H$yuBI0456F2Lyj5&fvSBFCy76*h%(HilJ$lhj!y6&(*wpibid90";
            //string sTemp = strKey;

            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>   
        /// 获得初始向量IV   
        /// </summary>   
        /// <returns>初试向量IV</returns>   
        private static byte[] GetLegalIVS()
        {
            string sTemp = @"Uidoc(Ghg7!rNIfb&94GUY81LyjhUb#er51HBh(u%g6HL($jhWk7&!hg4ui%()$775";
            //string sTemp = strIV;

            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>   
        /// 加密方法   
        /// </summary>   
        /// <param name="Source">待加密的串</param>   
        /// <returns>经过加密的串</returns>   
        public static string EncryptoS(string Source)
        {
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKeyS();
            mobjCryptoService.IV = GetLegalIVS();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }
        /// <summary>   
        /// 解密方法   
        /// </summary>   
        /// <param name="Source">待解密的串</param>   
        /// <returns>经过解密的串</returns>   
        public static string DecryptoS(string Source)
        {
            SymmetricAlgorithm mobjCryptoService = new RijndaelManaged();
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKeyS();
            mobjCryptoService.IV = GetLegalIVS();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        #region MD5_Method

        /// <summary>
        /// MD5的加密方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String md5(String s)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }


        #endregion
    }
}
