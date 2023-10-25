namespace NotificationsApp.Models
{
    public class NotificationPayload
    {
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int CoTwo { get; set; }
        public int WaitingTime { get; set; }
        public int BatteryLevel { get; set; }
        public bool IsBlocked { get; set; }
        public string Status { get; set; }
        public bool StartingSoon { get; set; }
        public bool IsFlagged { get; set; }
        public string Room { get; set; }
        public string Robot { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoutineName { get; set; }
    }
}