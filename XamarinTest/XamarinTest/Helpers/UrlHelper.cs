using System.Text.RegularExpressions;

namespace XamarinTest.Helpers {
    public static class UrlHelper {
        public static string baseUrl = "http://192.168.1.135/";

        public static string Token = "Token";
        public static string Register = "api/Auth/Register";
        public static string Logout = "api/Auth/Logout";
        public static string CheckEmail = "api/Auth/CheckEmail";

        public static string SaveImage = "api/Image/Save";
        public static string ImageList = "api/Image/List";

        public static string UrlEncode(string str) {
            return Regex.Replace(str, @"([^\w\-_\.~])", new MatchEvaluator(x => string.Format("{0:X}", x.Value[0])));
        }
    }
}
