using System;
using System.Collections.Generic;
using System.Text;

namespace GameRocket
{
    public class QueryString
    {
        protected StringBuilder builder;

        public QueryString()
        {
            builder = new StringBuilder();
        }

        public virtual QueryString Append(IDictionary<string, object> parameters)
        {
            foreach (KeyValuePair<string, object> pair in parameters)
            {
                Append(pair);
            }

            return this;
        }

        public virtual QueryString Append(KeyValuePair<string, object> pair)
        {
            return Append(pair.Key, pair.Value);
        }

        protected virtual QueryString Append(string key, object value)
        {
            if (key != null && !(key == "") && value != null)
            {
                if (builder.Length > 0)
                {
                    builder.Append("&");
                }
                builder.Append(EncodeParam(key, value));
            }
            return this;
        }

        protected virtual String EncodeParam(string key, object value)
        {
            return Uri.EscapeDataString(key) + "=" + Uri.EscapeDataString((string) value);
        }

        public override String ToString()
        {
            return builder.ToString();
        }
    }
}
