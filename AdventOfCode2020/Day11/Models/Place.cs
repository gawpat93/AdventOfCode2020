namespace Day11.Models
{
    public class Place
    {
        public Place(bool hasSeat)
        {
            HasSeat = hasSeat;
        }

        public bool HasOccupiedSeat => HasSeat && IsOccupied;

        public bool HasSeat { get; }

        public bool IsOccupied { get; set; }
    }
}
