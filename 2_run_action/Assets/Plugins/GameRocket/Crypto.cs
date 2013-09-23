using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;

namespace GameRocket
{
    public class Crypto
    {
        public static String Sign(string method, string url, IDictionary<string, object> parameters, string secretkey)
        {
			SortedDictionary<string, object> sortedParameters = new SortedDictionary<string, object>();
			foreach (KeyValuePair<string, object> pair in parameters)
			{
				sortedParameters.Add (pair.Key, pair.Value);
			}
			
            String baseString = buildBaseString(method, url, sortedParameters);
			Debug.Log (baseString);
            String signature = sign(baseString, secretkey);

            return signature;
        }

        private static String buildBaseString(string method, string url, IDictionary<string, object> parameters)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(method).Append("&").Append(Uri.EscapeDataString(url.ToLower())).Append("&");
            builder.Append(Uri.EscapeDataString(new QueryString().Append(parameters).ToString()));

            return builder.ToString();
        }

        private static String sign(string baseString, string secretkey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(baseString + secretkey);
            SHA256Managed sha256Managed = new SHA256Managed();
            byte[] hash = sha256Managed.ComputeHash(bytes);
            
            String signature = string.Empty;
            foreach (byte bit in hash)
            {
                signature += bit.ToString("x2");
            }
			
			Debug.Log (Encoding.UTF8.GetBytes(signature));

            String base64Signature = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(signature));
			
			Debug.Log (base64Signature);
            return base64Signature;
        }
    }
}
