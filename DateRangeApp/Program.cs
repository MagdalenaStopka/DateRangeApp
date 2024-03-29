using System;
using System.Globalization;

namespace DateRangeApp
{


    public class Program
    {
        string period = "";
        string[] _dates = new string[2] ;
        public static void Main(string[] args)
        {
            Program p = new Program();
            
            Console.WriteLine("Enter your two dates in format dd.MM.yyyy dd.MM.yyyy :");
            string dates = Console.ReadLine();
            p.TrySplitDates(dates);
            string startDate = p._dates[0];
            string endDate = p._dates[1];
            
            DateTime _startDate = p.TryParseDateToFormat(startDate);
            DateTime _endDate = p.TryParseDateToFormat(endDate);
            p.CheckDateRange(_startDate, _endDate);
            p.DateRange(_startDate, _endDate);
            Console.WriteLine("The date range:");
            Console.WriteLine(p.period);
            Console.ReadKey();
        }

        public string[] TrySplitDates( string dates)
        {
            _dates = dates.Split(' ');
       
            if (_dates.Length != 2)
            {
                throw new Exception("Incorrect number of dates is entered ");
            }
            else
            {
                return _dates;
            }
        }

        public DateTime TryParseDateToFormat(string date)
        {
            try
            {
                DateTime _date = DateTime.ParseExact(date, "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture);
                return _date;
            }
            catch (FormatException e)
            {
                throw new FormatException(date + " entered date is NOT in correct format", e);
            }
        }
        public string DateRange(DateTime _startDate, DateTime _endDate)
        {
            if (_startDate.Month == _endDate.Month && _startDate.Year == _endDate.Year)
            {
                period = string.Format("{0} - {1}", _startDate.ToString("dd"), _endDate.ToString("dd.MM.yyyy"));
            }
            else if (_startDate.Year == _endDate.Year)
            {
                period = string.Format("{0} - {1}", _startDate.ToString("dd.MM"), _endDate.ToString("dd.MM.yyyy"));
            }
            else
            {
                period = string.Format("{0} - {1}", _startDate.ToString("dd.MM.yyyy"), _endDate.ToString("dd.MM.yyyy"));
            }
            return period;
        }
        public bool CheckDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new FormatException("End date is larger than start date");
            }
            else
                return true;
        }
    }
}
