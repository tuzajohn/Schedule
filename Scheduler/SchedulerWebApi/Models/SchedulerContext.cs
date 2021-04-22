﻿using Microsoft.EntityFrameworkCore;

namespace SchedulerWebApi.Models
{
    public class SchedulerContext:DbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options) : base(options)
        {
                
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<HistoryShift> HistoryShifts { get; set; }
    }
}