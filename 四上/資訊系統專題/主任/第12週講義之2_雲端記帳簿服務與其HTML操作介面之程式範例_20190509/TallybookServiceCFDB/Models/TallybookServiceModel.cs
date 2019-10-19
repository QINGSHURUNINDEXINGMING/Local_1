namespace TallybookServiceCFDB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TallybookServiceModel : DbContext
    {
        public TallybookServiceModel()
            : base("name=TallybookServiceModel")
        {
        }

        public DbSet<Tallybook> Tallybooks { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        // �NEntity<Friend>�������ƪ�Ch2Friends�AEntity<Employee>�������ƪ�Ch2Employees
        // �Y�S���H�U�]�w�A�w�]Entity<Friend>�N�������ƪ�Friends�AEntity<Employee>�������ƪ�Employees
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map entity to table
            modelBuilder.Entity<Tallybook>().ToTable("TallybooksCFDB");
            modelBuilder.Entity<ExpenseType>().ToTable("ExpenseTypesCFDB");
        }
    }
}
