using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}

    public DbSet<Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>().HasData(new Contact[] {
            new Contact {  Name = "Ahmed", Address="Cairo",Phone="+2015168138451"},
            new Contact {  Name = "asd", Address="Cairo",Phone="+2015676786871"},
            new Contact {  Name = "dfg", Address="Cairo",Phone="+2015176867884"},
            new Contact {  Name = "Ahbcvbmed", Address="Cairo",Phone="+2067867868384"},
            new Contact {  Name = "jghj", Address="Cairo",Phone="+2018888888884"},
            new Contact {  Name = "bmnmb", Address="Cairo",Phone="+2066666681384"},
            new Contact {  Name = "Ahbnmbnmed", Address="Cairo",Phone="+2015168139999"},
            new Contact {  Name = "jkljll;", Address="Cairo",Phone="+2015100000005"},
            new Contact {  Name = "op[opp", Address="Cairo",Phone="+2015333333845"},
            new Contact {  Name = "p'wreer", Address="Cairo",Phone="+201515553845"},
            new Contact {  Name = "fdsf", Address="Cairo",Phone="+201544443445"},
            new Contact {  Name = "tyu", Address="Cairo",Phone="+201516819999"},
            new Contact {  Name = "oiio", Address="Cairo",Phone="+202222238451"}
        });
        base.OnModelCreating(modelBuilder);
    }
}
