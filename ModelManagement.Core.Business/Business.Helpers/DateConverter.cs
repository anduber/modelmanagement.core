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
            var now = DateTime.Now;
            var years = new DateTime(DateTime.Now.Subtract(dateOfBirth).Ticks).Year - 1;
            var pastYearDate = dateOfBirth.AddYears(years);
            var months = 0;
            for (var i = 0; i <= 12; i++)
            {
                if (pastYearDate.AddMonths(i)==now)
                {
                    months = i;
                    break;
                }
                if (pastYearDate.AddMonths(i) < now) continue;
                months = i - 1;
                break;
            }

            var days = now.Subtract(pastYearDate.AddMonths(months)).Days;
            var hours = now.Subtract(pastYearDate).Hours;
            var minutes = now.Subtract(pastYearDate).Minutes;
            var seconds = now.Subtract(pastYearDate).Seconds;
            return years;
            
            
        }

    }
}
