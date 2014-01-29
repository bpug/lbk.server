// -----------------------------------------------------------------------
// <copyright file="LogMap.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    using Lbk.MobileApp.Model;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LogTypeMap : EntityTypeConfiguration<LogType>
    {
        public LogTypeMap()
        {
            this.ToTable("LogType");
            this.Property(t => t.Id).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            

            this.HasKey(p => p.Id);
            this.Property(t => t.Description)
                .HasMaxLength(50);
            //this.HasMany(p => p.Logs);
        }
    }
}
