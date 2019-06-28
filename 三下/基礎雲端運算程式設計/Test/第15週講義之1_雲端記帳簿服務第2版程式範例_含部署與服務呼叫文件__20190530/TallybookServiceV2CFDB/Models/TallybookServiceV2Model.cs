namespace TallybookServiceV2CFDB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TallybookServiceV2Model : DbContext
    {
        public TallybookServiceV2Model()
            : base("name=TallybookServiceV2Model")
        {
        }

        public DbSet<Tallybook> Tallybooks { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        // �NEntity<Friend>�������ƪ�Ch2Friends�AEntity<Employee>�������ƪ�Ch2Employees
        // �Y�S���H�U�]�w�A�w�]Entity<Friend>�N�������ƪ�Friends�AEntity<Employee>�������ƪ�Employees
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map entity to table
            modelBuilder.Entity<Tallybook>().ToTable("TallybooksV2CFDB");
            modelBuilder.Entity<ExpenseType>().ToTable("ExpenseTypesV2CFDB");
        }
    }
}
