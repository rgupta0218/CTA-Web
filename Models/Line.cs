//
// One CTA Station
//

namespace program.Models
{

  public class Line
	{
	
		// data members with auto-generated getters and setters:
      	public int StationID { get; set; }
        public string StopName { get; set; }
		public string StationName { get; set; }
        public int Stops {get; set; }
	
		// default constructor:
		public Line()
		{ }
		
		// constructor:
		public Line(string stopname, int stationid, string stationName, int stops)
		{
			StopName = stopname;
            StationID = stationid;
			StationName = stationName;
            Stops = stops;
		}
		
	}//class

}//namespace