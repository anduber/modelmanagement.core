using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class ImportFromExcel
    {
        public List<T> ExportToList<T>(string filePath, string sheetName) where T : new()
        {

            string fileConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';";
            OleDbConnection oledbConnection = new OleDbConnection(fileConnection);
            string excelStringSQL = "SELECT * FROM [" + sheetName + "$]";
            OleDbCommand oledDbCommand = new OleDbCommand(excelStringSQL, oledbConnection);
            DataSet dataSet = new DataSet();
            OleDbDataAdapter oledAdapter = new OleDbDataAdapter(oledDbCommand);
            oledAdapter.Fill(dataSet);
            var list = new List<T>();
            foreach (DataTable dataTable in dataSet.Tables)
            {
                list = ExcelUtility.ToList<T>(dataTable);
            }
            return list;
        }
    }

    public class ExcelUtility
    {
        public static List<T> ToList<T>(DataTable dataTable) where T : new()
        {
            var dataList = new List<T>();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            var objectFieldNames = typeof(T).GetProperties(flags).Cast<PropertyInfo>().
                Select(item => new
                {
                    Name = item.Name,
                    Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType

                }).ToList();

            var dtlFieldName = dataTable.Columns.Cast<DataColumn>().
                Select(item => new
                {
                    Name = item.ColumnName,
                    Type = item.DataType
                }).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var classObj = new T();
                foreach (var dtField in dtlFieldName)
                {
                    PropertyInfo propertyInfos = classObj.GetType().GetProperty(dtField.Name);
                    var field = objectFieldNames.Find(x => x.Name == dtField.Name);
                    if (field != null)
                    {

                        if (propertyInfos.PropertyType == typeof(DateTime) || propertyInfos.PropertyType == typeof(Nullable<DateTime>))
                            propertyInfos.SetValue(classObj, ConvertToDateTime(dataRow[dtField.Name]), null);
                        else if (propertyInfos.PropertyType == typeof(int) || propertyInfos.PropertyType == typeof(Nullable<int>))
                            propertyInfos.SetValue(classObj, ConvertToInt(dataRow[dtField.Name]), null);
                        else if (propertyInfos.PropertyType == typeof(long) || propertyInfos.PropertyType == typeof(Nullable<long>))
                            propertyInfos.SetValue(classObj, ConvertToLong(dataRow[dtField.Name]), null);
                        else if (propertyInfos.PropertyType == typeof(decimal) || propertyInfos.PropertyType == typeof(Nullable<decimal>))
                            propertyInfos.SetValue(classObj, ConvertToDecimal(dataRow[dtField.Name]), null);
                        else if (propertyInfos.PropertyType == typeof(String))
                        {
                            if (dataRow[dtField.Name].GetType() == typeof(DateTime) || dataRow[dtField.Name].GetType() == typeof(Nullable<DateTime>))
                            {
                                propertyInfos.SetValue(classObj, ConvertToDateString(dataRow[dtField.Name]), null);
                            }
                            else
                            {
                                propertyInfos.SetValue(classObj, ConvertToString(dataRow[dtField.Name]), null);
                            }
                        }
                    }
                }
                dataList.Add(classObj);

            }
            return dataList;
        }

        #region Converters

        private static string ConvertToString(object value)
        {
            return Convert.ToString(ReturnEmptyIfNull(value));
        }

        private static DateTime ConvertToDateTime(object date)
        {
            return Convert.ToDateTime(ReturnDateTimeMinIfNull(date));
        }

        private static int ConvertToInt(object value)
        {
            return Convert.ToInt32(ReturnZeroIfNull(value));
        }

        private static long ConvertToLong(object value)
        {
            return Convert.ToInt64(ReturnZeroIfNull(value));
        }

        private static decimal ConvertToDecimal(object value)
        {
            return Convert.ToDecimal(ReturnZeroIfNull(value));
        }

        private static string ConvertToDateString(object date)
        {
            if (date == null)
                return string.Empty;
            return ConvertDate(Convert.ToDateTime(date));
        }
        #endregion

        #region HelperFunction
        private static object ReturnEmptyIfNull(object value)
        {
            if (value == DBNull.Value || value == null)
                return string.Empty;
            return value;
        }

        private static object ReturnDateTimeMinIfNull(object value)
        {
            if (value == DBNull.Value || value == null)
                return DateTime.MinValue;
            return value;
        }

        private static object ReturnZeroIfNull(object value)
        {
            if (value == DBNull.Value || value == null)
                return 0;
            return value;
        }

        private static string ConvertDate(DateTime dateTime, bool excludeHourseAndMinutes = false)
        {
            if (dateTime != DateTime.MinValue)
            {
                if (excludeHourseAndMinutes)
                    return dateTime.ToString("yyyy-MM-dd");
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            }
            return null;
        }

        #endregion
    }

}
