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

        public DbSet<Video> Videos { get; set; }

        public DbSet<QuestionCategory> QuestionCategorys { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LocalizableEntityTranslation> LocalizableEntityTranslations { get; set; }

        public DbSet<LocalizableEntity> LocalizableEntitys { get; set; }

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

            SetupVideoEntity(modelBuilder);

            SetupQuestionCategoryEntity(modelBuilder);

            SetupLanguageEntity(modelBuilder);

            SetupTranslationsEntity(modelBuilder);

            SetupLocalizableEntity(modelBuilder);
        }

        private static void SetupLanguageEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Language>().HasKey(a => a.Id);
            modelBuilder.Entity<Language>().Property(a => a.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Language>().Property(a => a.Code).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Language>().Property(a => a.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Language>().HasMany(m => m.LocalizableEntityTranslation);
        }

        private static void SetupLocalizableEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalizableEntity>().ToTable("LocalizableEntity");
            modelBuilder.Entity<LocalizableEntity>().HasKey(a => a.Id);
            modelBuilder.Entity<LocalizableEntity>().Property(a => a.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LocalizableEntity>().Property(a => a.EntityName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<LocalizableEntity>().Property(a => a.PrimaryKeyFieldName).HasMaxLength(int.MaxValue).IsRequired();
            modelBuilder.Entity<LocalizableEntity>().HasMany(m => m.LocalizableEntityTranslation);
        }

        private static void SetupTranslationsEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalizableEntityTranslation>().ToTable("LocalizableEntityTranslation");
            modelBuilder.Entity<LocalizableEntityTranslation>().HasKey(a => a.Id);
            modelBuilder.Entity<LocalizableEntityTranslation>().Property(a => a.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LocalizableEntityTranslation>().Property(a => a.Text).HasMaxLength(int.MaxValue).IsRequired();
            modelBuilder.Entity<LocalizableEntityTranslation>().Property(a => a.FieldName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<LocalizableEntityTranslation>().Property(a => a.PrimaryKeyValue).IsRequired();
            modelBuilder.Entity<LocalizableEntityTranslation>().HasRequired(q => q.Language);
            modelBuilder.Entity<LocalizableEntityTranslation>().HasRequired(q => q.LocalizableEntity);
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
            modelBuilder.Entity<Event>().Property(e => e.ReservationLink).HasMaxLength(255);
            modelBuilder.Entity<Event>().Property(e => e.ThumbnailLink).HasMaxLength(255);
            modelBuilder.Entity<Event>().Property(e => e.ThumbnailName).HasMaxLength(255);
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
            modelBuilder.Entity<Picture>().Property(e => e.Title).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Picture>().Property(e => e.Description).HasMaxLength(255);
            modelBuilder.Entity<Picture>().Property(e => e.FileName).HasMaxLength(255);
            modelBuilder.Entity<Picture>().Property(e => e.Link).HasMaxLength(255);
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
            modelBuilder.Entity<Question>().HasRequired(q => q.Category);
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

        private static void SetupVideoEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>().HasKey(e => e.Id);
            modelBuilder.Entity<Video>().Property(e => e.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Video>().Property(e => e.Description).HasMaxLength(255);
            modelBuilder.Entity<Video>().Property(e => e.FileName).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Video>().Property(e => e.Link).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Video>().Property(e => e.SortOrder);
            modelBuilder.Entity<Video>().Property(e => e.ThumbnailLink).HasMaxLength(255);
        }

       
        private static void SetupQuestionCategoryEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionCategory>().HasKey(e => e.Id);
            modelBuilder.Entity<QuestionCategory>().Property(e => e.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<QuestionCategory>().Property(e => e.Title).HasMaxLength(5).IsRequired();
        }
        
        #endregion
    }
}
