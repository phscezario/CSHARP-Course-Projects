using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace API.To.MongoDB
{
	public class Infected
	{
		public Infected(DateTime birthDate, string gender, double latidute, double longitude)
		{
			BirthDate = birthDate;
			Gender = gender;
			Localization = new GeoJson2DGeographicCoordinates(latidute, longitude);
		}

		public DateTime BirthDate{ get; set; }
		public string Gender { get; set; }
		public GeoJson2DGeographicCoordinates Localization { get; set; }
	}
}
