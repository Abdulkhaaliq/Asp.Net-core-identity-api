using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthenticationAndPostingApi.Models;

namespace AuthenticationAndPostingApi.Data
{
    public class IncidentReportContext : DbContext
    {
        public IncidentReportContext (DbContextOptions<IncidentReportContext> options)
            : base(options)
        {
        }

        public DbSet<AuthenticationAndPostingApi.Models.IncidentReport> IncidentReport { get; set; }
    }
}
