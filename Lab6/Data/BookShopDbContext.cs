using Lab6.Models;
using System.Collections.Generic;

public class BookShopDbContext : DbContext
{
    public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book_Category> BookCategories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Item> OrderItems { get; set; }
    public DbSet<Ref_Contact_Type> ContactTypes { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
