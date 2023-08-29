namespace BlazorGrpc.Shared
{
    using System;
    using Google.Protobuf.WellKnownTypes;
    using Grpc.Net.Client;

    public partial class WeatherForecast
        {
            public DateTime Date
            {
                get => DateTimeStamp.ToDateTime();
                set { DateTimeStamp = Timestamp.FromDateTime(value.ToUniversalTime()); }
            }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public class WeatherForecastServiceClient
        {
            private GrpcChannel channel;

            public WeatherForecastServiceClient(GrpcChannel channel)
            {
                this.channel = channel;
            }
        }
    }
    

    //public class WeatherForecast
    //{
    //    public DateTime Date { get; set; }

    //    public int TemperatureC { get; set; }

    //    public string? Summary { get; set; }

    //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    //}
}