using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Helpers
{
    public class DateConverter
    {
        public static int GetAgeFromDate(DateTime? dateOfBirth)
        {
            var monthdiff = DateTime.Now.Month - dateOfBirth.Value.Month;
            var yearDiff = DateTime.Now.Year - dateOfBirth.Value.Year;
            if (monthdiff < 0)
            {
                return yearDiff - 1;
            }
            else
            {
                return yearDiff;
            }

        }
        public static int GetAgeFromDate(DateTime dateOfBirth)
        {
            var monthdiff = DateTime.Now.Month - dateOfBirth.Month;
            var yearDiff = DateTime.Now.Year - dateOfBirth.Year;
            if (monthdiff < 0)
            {
                return yearDiff - 1;
            }
            else
            {
                return yearDiff;
            }

        }
        public static DateTime GetDateOfBirthFromAge(int age)
        {
            return DateTime.Now.AddYears(-age);
        }
        public static int CalculateAge(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            int years = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
            DateTime pastYearDate = dateOfBirth.AddYears(years);
            int months = 0;
            for (int i = 0; i <= 12; i++)
            {
                if (pastYearDate.AddMonths(i)==now)
                {
                    months = i;
                    break;
                }
                else if (pastYearDate.AddMonths(i) >= now)
                {
                    months = i - 1;
                    break;
                }
            }

            int days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            int hours = now.Subtract(pastYearDate).Hours;
            int minutes = now.Subtract(pastYearDate).Minutes;
            int seconds = now.Subtract(pastYearDate).Seconds;
            return years;
            
            
        }

    }
}
