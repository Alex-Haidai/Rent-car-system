
namespace DAL.Entities
{
    public class Drive
    {
        public int DriveId { get; set; }
        public Car Car { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Length { get; set; }
        public double Cost { get; set; }
        public TimeSpan Duration { get; set; }
        public DriveState CurrentDriveState { get; set; }
        public Drive(Car car)
        {
            Car = car;
        }
    }
}
