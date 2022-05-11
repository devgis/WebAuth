using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Common
{
    public class CommonHelper
    {
        public static Dictionary<string, string> paraURLParm(string param)
        {
            Dictionary<string, string> dicRs = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(param))
            {
                //?u = 1 & pwd = 123"
                string queryString = param.TrimStart('?');
                //string[] arrtemp = param.Split('&');
                //if (arrtemp != null && arrtemp.Length > 0)
                //{
                //    foreach (string keyvalue in arrtemp)
                //    {
                //        string[] arr = keyvalue.Split('=');
                //        if (arr.Length < 2)
                //        {
                //            return false;
                //        }
                //    }
                //}

                if (!string.IsNullOrEmpty(queryString))
                {
                    int count = queryString.Length;
                    for (int i = 0; i < count; i++)
                    {
                        int startIndex = i;
                        int index = -1;
                        while (i < count)
                        {
                            char item = queryString[i];
                            if (item == '=')
                            {
                                if (index < 0)
                                {
                                    index = i;
                                }
                            }
                            else if (item == '&')
                            {
                                break;
                            }
                            i++;
                        }
                        string key = null;
                        string value = null;
                        if (index >= 0)
                        {
                            key = queryString.Substring(startIndex, index - startIndex);
                            value = queryString.Substring(index + 1, (i - index) - 1);
                        }
                        else
                        {
                            key = queryString.Substring(startIndex, i - startIndex);
                        }
                        if (!dicRs.ContainsKey(key))
                        {
                            dicRs.Add(key, value);
                        }
                        //if (isEncoded)
                        //{
                        //    result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                        //}
                        //else
                        //{
                        //    result[key] = value;
                        //}
                        //if ((i == (count - 1)) && (queryString[i] == '&'))
                        //{
                        //    result[key] = string.Empty;
                        //}
                    }
                }
            }
            return dicRs;
        }


    }
}
