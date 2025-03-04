﻿using Assignment_3_EF_Core;
using Microsoft.EntityFrameworkCore;

public class ITIDbContext : DbContext
{
    public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<EmployeeDepartment>()
            .HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

        modelBuilder.Entity<EmployeeDepartment>()
            .HasOne(ed => ed.Employee)
            .WithMany(e => e.EmployeeDepartments)
            .HasForeignKey(ed => ed.EmployeeId);

        modelBuilder.Entity<EmployeeDepartment>()
            .HasOne(ed => ed.Department)
            .WithMany(d => d.EmployeeDepartments)
            .HasForeignKey(ed => ed.DepartmentId);
    }
}
