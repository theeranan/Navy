using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Navy.Core
{
    public class Constants
    {
        public static string currentConString = DBConnection.defaultConString;

        public static DateTimePicker picker = new DateTimePicker();
        public static DateTime minDate = picker.MinDate;

        public const string shortDateFormat_TH = "dd/MM/yyyy";
        public const string shortDateFormat_US = "MM/dd/yyyy";

        public const string subDateFormat_TH = "d MMM yy";

        public const string longDateFormat_TH = "d MMMM yyyy";
        public const string longDateFormat_US = "d MMMM yyyy";

        public const string string_cultureTH = "th-TH";
        public const string string_cultureUS = "en-US";

        public const int countItemResult = 50;
        public static int[] shiftYearin =  { 1, 2, 3, 4 };

        public static string maxYearin = null;
        public static bool fullMode = true;

        public enum ImagePath
        {
            PersonCard, PersonCardPreValidate, PersonCardPostValidate
        }
    }
}
