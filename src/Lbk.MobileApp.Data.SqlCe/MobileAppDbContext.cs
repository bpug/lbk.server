// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileAppDbContext.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe
{
    #region using directives

    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    using Lbk.MobileApp.Model;

    #endregion

    public partial class MobileAppDbContext : DbContext, IUnitOfWork
    {
        #region - Properties -

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Serie> Series { get; set; }

        #endregion

        #region - Implemented Interfaces -

        #region IUnitOfWork

        void IUnitOfWork.SaveChanges()
        {
            this.SaveChanges();
        }

        #endregion

        #endregion

        #region - Methods -

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetupSeriesEntity(modelBuilder);

            SetupQuestionEntity(modelBuilder);

            SetupAnswerEntity(modelBuilder);

            SetupMenuEntity(modelBuilder);

            SetupFoodEntity(modelBuilder);

            SetupCategoryEntity(modelBuilder);

            SetupEventEntity(modelBuilder);

            SetupPictureEntity(modelBuilder);
        }

        private static void SetupAnswerEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasKey(a => a.Id);
            modelBuilder.Entity<Answer>().Property(a => a.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Answer>().Property(a => a.Description).HasMaxLength(255);
            modelBuilder.Entity<Answer>().Property(a => a.Explanation).HasMaxLength(255);
            modelBuilder.Entity<Answer>().Property(a => a.IsRight).IsRequired();
            modelBuilder.Entity<Answer>().HasRequired(a => a.Question);
        }

        private static void SetupCategoryEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Category>().Property(c => c.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(255);
            modelBuilder.Entity<Category>().HasMany(c => c.Foods);
            modelBuilder.Entity<Category>().Property(c => c.Title).HasMaxLength(255);
        }

        private static void SetupEventEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Event>().Property(e => e.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Event>().Property(e => e.ActivatedAt).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Date).HasMaxLength(255);
            modelBuilder.Entity<Event>().Property(e => e.DateOrder);
            modelBuilder.Entity<Event>().Property(e => e.Description).HasMaxLength(255);
            modelBuilder.Entity<Event>().Property(e => e.ExpiresAt);
            modelBuilder.Entity<Event>().Property(e => e.IsActivated).IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Title).HasMaxLength(255);
        }

        private static void SetupFoodEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasKey(f => f.Id);
            modelBuilder.Entity<Food>().Property(f => f.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Food>().HasRequired(f => f.Category);
            modelBuilder.Entity<Food>().Property(f => f.Description).HasMaxLength(255);
            modelBuilder.Entity<Food>().HasRequired(f => f.Menu);
            modelBuilder.Entity<Food>().Property(f => f.Price).IsRequired();
            modelBuilder.Entity<Food>().Property(f => f.SortOrder);
            modelBuilder.Entity<Food>().Property(f => f.Title).HasMaxLength(255);
        }

        private static void SetupMenuEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasKey(m => m.Id);
            modelBuilder.Entity<Menu>().Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Menu>().Property(m => m.Date).IsRequired();
            modelBuilder.Entity<Menu>().Property(m => m.Description).HasMaxLength(255);
            modelBuilder.Entity<Menu>().HasMany(m => m.Foods);
        }

        private static void SetupPictureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>().HasKey(e => e.Id);
            modelBuilder.Entity<Picture>().Property(e => e.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Picture>().Property(e => e.Description).HasMaxLength(255);
            modelBuilder.Entity<Picture>().Property(e => e.FileName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Picture>().Property(e => e.Link).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Picture>().Property(e => e.SortOrder);
        }

        private static void SetupQuestionEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<Question>().Property(q => q.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Question>().HasMany(q => q.Answers);
            modelBuilder.Entity<Question>().Property(q => q.Description).HasMaxLength(255);
            modelBuilder.Entity<Question>().Property(q => q.Number).IsRequired();
            modelBuilder.Entity<Question>().Property(q => q.Points).IsRequired();
            modelBuilder.Entity<Question>().HasRequired(q => q.Serie);
        }

        private static void SetupSeriesEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>().HasKey(s => s.Id);
            modelBuilder.Entity<Serie>().Property(s => s.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Serie>().Property(s => s.ActivatedAt).IsRequired();
            modelBuilder.Entity<Serie>().Property(s => s.Description).HasMaxLength(255);
            modelBuilder.Entity<Serie>().Property(s => s.ExpiresAt).IsRequired();
            modelBuilder.Entity<Serie>().Property(s => s.IsActivated).IsRequired();
            modelBuilder.Entity<Serie>().HasMany(s => s.Questions);
        }

        #endregion
    }
}
