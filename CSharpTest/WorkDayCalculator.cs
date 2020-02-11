using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (weekEnds != null)
            {
                foreach (WeekEnd weekends in weekEnds)
                {
                    if (weekends.StartDate == weekends.EndDate && startDate.AddDays(dayCount) >= weekends.EndDate)
                    {
                        dayCount += 1;
                    }
                    if (startDate <= weekends.StartDate && startDate.AddDays(dayCount) >= weekends.EndDate)
                    {

                        if (weekends.StartDate <= weekends.EndDate)
                        {
                            dayCount += weekends.EndDate.Day - weekends.StartDate.Day;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data format, check the beginning and end of weekends and holidays");
                        }
                    }
                    else if (startDate >= weekends.StartDate && (startDate.AddDays(dayCount) >= weekends.EndDate || startDate.AddDays(dayCount) < weekends.EndDate))
                    {
                        if (weekends.StartDate <= weekends.EndDate)
                        {
                            dayCount += (weekends.EndDate - startDate).Days;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data format, check the beginning and end of weekends and holidays");
                        }
                    }
                    else if (startDate <= weekends.StartDate && startDate.AddDays(dayCount) <= weekends.EndDate && startDate.AddDays(dayCount) >= weekends.StartDate)
                    {
                        if (weekends.StartDate <= weekends.EndDate)
                        {
                            dayCount += (weekends.EndDate - startDate).Days;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect data format, check the beginning and end of weekends and holidays");
                        }
                    }
                }

                return startDate.AddDays(dayCount);
            }
            else
            {
                return startDate.AddDays(dayCount - 1);
            }
            

            throw new NotImplementedException();
        }
    }
}
