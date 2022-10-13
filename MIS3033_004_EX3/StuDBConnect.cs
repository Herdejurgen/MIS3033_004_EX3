using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS3033_004_EX3
{
    public class StuDBConnect:DbContext
    {
        public DbSet<Student> students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite(@"Data Source=C:\Users\Jack\Desktop\School stuff\Fall 2022\Business Programming Languages\MIS3033_004_EX3_Jack_Herdejurgen\MIS3033_004_EX3\Students.db");
        }
    }
}
