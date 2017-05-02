using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NCDCLib.Api
{
    public class DataApi : NcdcApi
    {
        public DataApi(NCDCApiManager api) : base(api,"data")
        {
        }

        public async Task<string> GetData(List<DataType> dataTypes, DataSet datasetId, string locationId, DateTime startDate, DateTime endDate, int limit = 1000)
        {
            var parameters = new List<KeyValuePair<string, string>>();
            var dataTypeValues = dataTypes.Select(dt => new KeyValuePair<string,string>("datatypeid",Enum.GetName(typeof(DataSet),dt)));
            parameters.AddRange(dataTypeValues);

            parameters.Add(new KeyValuePair<string, string>("datasetid", Enum.GetName(typeof(DataSet), datasetId)));
            parameters.Add(new KeyValuePair<string, string>("locationid", locationId));
            parameters.Add(new KeyValuePair<string, string>("startdate", startDate.ToString("yyyy-MM-d")));
            parameters.Add(new KeyValuePair<string, string>("enddate", endDate.ToString("yyyy-MM-d")));
            parameters.Add(new KeyValuePair<string, string>("limit", limit.ToString()));

            return await ApiManager.GetStringAsync(GetRequestString(parameters));
        }
    }

    public enum DataSet
    {
        GSOM
    }

    public enum DataType
    {
        TMAX,
        TMIN,
        TAVG,
    }
}


//data?datasetid=GSOM&datatypeid=TMAX&datatypeid=TMIN&datatypeid=TAVG&locationid=CITY:US530001&startdate=2016-01-01&enddate=2017-04-01&limit=100
