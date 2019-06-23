namespace HW04.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ServiceModel1 : DbContext
    {
        public ServiceModel1()
            : base("name=ServiceModel1")
        {
        }

        public DbSet<Col> Col { get; set; }
        public DbSet<Type> Type { get; set; }

        // �NEntity<Friend>�������ƪ�Ch2Friends�AEntity<Employee>�������ƪ�Ch2Employees
        // �Y�S���H�U�]�w�A�w�]Entity<Friend>�N�������ƪ�Friends�AEntity<Employee>�������ƪ�Employees


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map entity to table
            modelBuilder.Entity<Col>().ToTable("Col");
            modelBuilder.Entity<Type>().ToTable("Type");
        }
    }
}
