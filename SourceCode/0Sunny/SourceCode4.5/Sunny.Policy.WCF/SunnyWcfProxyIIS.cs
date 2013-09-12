using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Sunny.Policy.WCF
{
    public class SunnyWcfProxyIIS<T> : ChannelFactory<T>
    {
        public SunnyWcfProxyIIS(string remoteAddress)
            : base(typeof(T).Name.ToString(), new EndpointAddress(remoteAddress))
        {
        }
        public SunnyWcfProxyIIS() : base() { }
        public T GetObject()
        {
            return CreateChannel(new BasicHttpBinding("SunnyServiceBinding"), new EndpointAddress(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))));
        }
    }
    public class SunnyWcfProxyIISWebConfig<T> : SunnyWcfProxyIIS<T>
    {
        public SunnyWcfProxyIISWebConfig() : base(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))) { }
    }
    public class SunnyWcfProxyInstanceIIS<T>
    {
        //ChannelFactory<T> currentChannel;
        public T GetChannel()
        {
            T ContractT = ChannelFactory<T>.CreateChannel(new WSHttpBinding("SunnyServiceBinding"), new EndpointAddress(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))));
            //T ContractT = ChannelFactory<T>.CreateChannel(new WSHttpBinding(), new EndpointAddress(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))));
            return ContractT;
            #region old code
            /*
            currentChannel = new ChannelFactory<T>(new BasicHttpBinding(), new EndpointAddress(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))));
            T CurrentT = currentChannel.CreateChannel();
            try
            {
                if (currentChannel.State != CommunicationState.Opened)
                    currentChannel.Open();

                //return ChannelFactory<T>.CreateChannel(new BasicHttpBinding(), new EndpointAddress(SunnyWcfProxyCOMMON.GetObjAdress(typeof(T))));
            }
            catch { currentChannel.Abort(); }
            return CurrentT;
             */
            #endregion
        }
    }
    public class SunnyWcfProxyCOMMON
    {
        public static string GetObjAdress(Type te)
        {
            string WCFmailAddress = Decrypto(System.Configuration.ConfigurationManager.ConnectionStrings["SunnyWcfHostAddress"].ToString());
            string retstring = "";
            string tep1 = te.Name[0].ToString();
            if (tep1.Equals("I"))
            {
                retstring = WCFmailAddress + te.Name.Substring(1) + ".svc";
            }
            return retstring;
        }


        #region Symmetric_Method

        private static System.Security.Cryptography.SymmetricAlgorithm mobjCryptoService = new System.Security.Cryptography.RijndaelManaged();


        private static byte[] GetLegalKey()
        {
            string sTemp = @"1WP7%8(%&hj7x82H$yuBI$456F2Lyj5&fbSBFCy6*h%(HllJ$lhj!y6&(**)as87";
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        private static byte[] GetLegalIV()
        {
            string sTemp = @"1WP7%8*GhgL!rNIfb&95GUY8LLyjhUb#er5LSBh(u%g6HJ($$)WkL&!hg4u%$mov86";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        private static string Decrypto(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            System.Security.Cryptography.ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            System.Security.Cryptography.CryptoStream cs = new System.Security.Cryptography.CryptoStream(ms, encrypto, System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.StreamReader sr = new System.IO.StreamReader(cs);
            return sr.ReadToEnd();
        }

        #endregion
    }
}
