﻿namespace tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.DataModels
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<BookShelf> BookShelfs;
    }
}
