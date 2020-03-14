using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class TopTenStationInfoModel : PageModel  
    {  
				public List<Models.Station> StationList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
  
        public void OnGet(string input)  
        {  
				  StationList = new List<Models.Station>();
								
							string sql;

							sql = string.Format(@"
                            
                            SELECT TOP 10 Stations.StationID, Stations.Name, SUM(DailyTotal) AS TotalRidership 
                            FROM Stations
                            FULL JOIN Riderships ON Stations.StationID = Riderships.StationID
                            GROUP BY Stations.StationID, Stations.Name
                            ORDER BY TotalRidership DESC ;
                            ");

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								Models.Station s = new Models.Station();

								s.StationID = Convert.ToInt32(row["StationID"]);
                                s.StationName = Convert.ToString(row["Name"]); 
								s.DailyRider = Convert.ToInt32(row["TotalRidership"]);                                                        

								StationList.Add(s);
							}
		}
			
    }//class  
}//namespace