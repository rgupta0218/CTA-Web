using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
  
namespace program.Pages  
{  
    public class RidershipByDayModel : PageModel  
    {  
        public List<string> Week { get; set; }
        public List<int> NumRiders { get; set; }
        public Exception EX { get; set; }
  
        public void OnGet()  
        {
          Week = new List<string>();
          NumRiders = new List<int>();
          
          EX = null;
          
          Week.Add("Sunday");
          Week.Add("Monday");
          Week.Add("Tuesday");
          Week.Add("Wednesday");
          Week.Add("Thursday");
          Week.Add("Friday");
          Week.Add("Saturday");

          try
          {
            string sql = string.Format(@"
SELECT DATENAME(WEEKDAY, TheDate) AS TheDay, Sum(DailyTotal) AS NumRiders
FROM Riderships
GROUP BY DATENAME(WEEKDAY, TheDate)
ORDER BY 
    CASE 
    When DATENAME(WEEKDAY, TheDate) = 'Sunday' Then 1
    When DATENAME(WEEKDAY, TheDate) = 'Monday' Then 2
    When DATENAME(WEEKDAY, TheDate) = 'Tuesday' Then 3
    When DATENAME(WEEKDAY, TheDate) = 'Wednesday' Then 4
    When DATENAME(WEEKDAY, TheDate) = 'Thursday' Then 5
    When DATENAME(WEEKDAY, TheDate) = 'Friday' Then 6
    When DATENAME(WEEKDAY, TheDate) = 'Saturday' Then 7
    end asc
    

");
          
            DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
         
              int numriders = Convert.ToInt32(row["NumRiders"]);

              NumRiders.Add(numriders);
            }
		      }
		      catch(Exception ex)
		      {
            EX = ex;
		      }
		      finally
		      { 
            // nothing at the moment
          } 
        }  
        
    }//class
}//namespace