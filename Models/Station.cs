//
// One CTA Station
//

namespace program.Models
{

  public class Station
	{
	
		// data members with auto-generated getters and setters:
	    public int StationID { get; set; }
		public string StationName { get; set; }
		public int AvgDailyRidership { get; set; }
        public int Stops {get; set; }
        public string Handicap {get; set; }
        public int DailyRider {get; set; }
	
		// default constructor:
		public Station()
		{ }
		
		// constructor:
		public Station(int id, string name, int avgDailyRidership, int stop, string handicap, int dailyRider)
		{
			StationID = id;
			StationName = name;
			AvgDailyRidership = avgDailyRidership;
            Stops = stop;
            Handicap = handicap;
            DailyRider = dailyRider;
		}
		
	}//class

}//namespace