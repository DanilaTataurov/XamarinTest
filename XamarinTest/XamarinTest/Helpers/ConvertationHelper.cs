using System;
using System.Collections.Generic;
using System.Linq;

namespace XamarinTest.Helpers {
    public class ConvertationHelper {
        public static string CoordinatesToString(double[] val) {
            double[] doubleArray = val;
            string str = val[0] + "." + val[1] + val[2];
            str = str.Replace(",", "");
            return str;
        }

        public static IDictionary<string, string> ParametersToDictionary(object postParameters) {
            Type t = postParameters.GetType();
            IDictionary<string, string> dictionaryParams = t.GetProperties().ToDictionary(
                x => x.Name,
                x => x.GetValue(postParameters, null).ToString()
            );
            return dictionaryParams;
        }
    }
}
