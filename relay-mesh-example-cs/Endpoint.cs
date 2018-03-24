namespace relay_mesh_example_cs
{
    public class Endpoint
    {
        public string name { get; set; }
        public string ipAddress { get; set; }
        public string listenerServiceId { get; set; }
        public int port { get; set; }
        public string controlProtocol { get; set; }
        public string signalingProtocol { get; set; }
        public string dialStyle { get; set; }
        public string addressStyle { get; set; }
        public string calendarId { get; set; }
        public string calendarType { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"Name={name}, IpAddress={ipAddress}, ListenerServiceId={listenerServiceId}, Port={port}, ControlProtocol={controlProtocol}, SignalingProtocol={signalingProtocol}, DialStyle={dialStyle}, AddressStyle={addressStyle}, CalendarId={calendarId}, CalendarType={calendarType}, Username={username}, Password=(hidden)";
        }
    }
}