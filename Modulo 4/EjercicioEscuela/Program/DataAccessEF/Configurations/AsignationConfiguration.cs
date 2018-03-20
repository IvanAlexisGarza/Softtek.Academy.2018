using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Entities;

namespace DataAccessEF.Configurations
{
    public class AsignationConfiguration : EntityTypeConfiguration<Asignation>
    {
        public AsignationConfiguration()
        {
            this.ToTable("Asignation");

            this.HasKey(a => a.AsignationId);


        }
    }
}
