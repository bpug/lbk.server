// <auto-generated />
namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddLogAndLogType : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201401281621437_AddLogAndLogType"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
