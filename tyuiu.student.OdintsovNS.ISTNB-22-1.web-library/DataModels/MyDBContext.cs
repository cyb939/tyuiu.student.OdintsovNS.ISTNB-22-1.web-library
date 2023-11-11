using Microsoft.EntityFrameworkCore;
using tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.DataModels;

namespace tyuiu.student.OdintsovNS.ISTNB_22_1.web_library.DataModels
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookShelf> BookSelfs { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Library> Library { get; set; }
    }
}
