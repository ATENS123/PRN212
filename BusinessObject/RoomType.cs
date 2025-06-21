namespace BusinessObject
{
    public class RoomType
    {
        public RoomType(int id, string name, string desc, string note)
        {
            RoomTypeID = id;
            RoomTypeName = name;
            TypeDescription = desc;
            TypeNote = note;
        }

        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeNote { get; set; }

        public virtual ICollection<Room> Rooms { get; set; } // nếu cần
    }


}
