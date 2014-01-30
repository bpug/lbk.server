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
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.Property(t => t.Id).HasColumnName("ID");
            this.Property(t => t.Fingerprint).HasColumnName("Fingerprint");
            this.Property(t => t.InsertTime).HasColumnName("InsertTime");
            this.Property(t => t.LogEventId).HasColumnName("LogType");

            this.HasKey(p => p.Id);
            this.Property(t => t.Fingerprint)
                .HasMaxLength(50);
            //this.HasRequired(p => p.Type);
            this.HasRequired(p => p.Event).WithMany( p => p.Logs).HasForeignKey( p => p.LogEventId);
        }
    }
}
