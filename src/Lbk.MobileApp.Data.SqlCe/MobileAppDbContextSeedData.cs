// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileAppDbContextSeedData.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lbk.MobileApp.Model;

    #endregion

    public partial class MobileAppDbContext : ISeedDatabase
    {
        #region - Implemented Interfaces -

        #region ISeedDatabase

        public void Seed()
        {
            // Seed for menus
            this.SeedCategories();
            this.SeedMenus();
            this.SaveChanges();
            this.SeedFoods();
            this.SaveChanges();

            // Seed for quiz
            this.SeedQuestionsAndAnswers(this.SeedSeries());
            this.SaveChanges();

            // Seed for events
            this.SeedEvents();
            this.SaveChanges();

            // Seed for pictures
            this.SeedPictures();
            this.SaveChanges();
        }

        #endregion

        #endregion

        #region - Methods -

        private void SeedCategories()
        {
            this.Categorys.Add(new Category { Description = "Vorspeisen gehören einfach dazu", Title = "Vorspeisen" });
            this.Categorys.Add(
                new Category
                    {
                        Description = "11 - 15 Uhr (solange der Vorrat reicht – kein Beilagentausch möglich)", 
                        Title = "Mittagsschmankerl"
                    });
            this.Categorys.Add(new Category { Description = "À la carte", Title = "Hauptspeisen" });
            this.Categorys.Add(new Category { Description = "Muss einfach sein", Title = "Desserts" });
        }

        private void SeedEvents()
        {
            this.Events.Add(
                new Event
                    {
                        ActivatedAt = new DateTime(2011, 08, 01), 
                        Date = "17.09.2011 - 01.10.2011, 18:30 Uhr", 
                        DateOrder = new DateTime(2011, 09, 17), 
                        Description =
                            "Nach dem Erfolg mi letzten Jahr, wird es auch heuer wieder die echte Alternative zum Oktoberfest geben: Das Wiesnzelt am Stiglmaier Platz.", 
                        ExpiresAt = new DateTime(2011, 10, 02), 
                        IsActivated = true, 
                        Title = "Das Wiesnzelt am Stiglmaierplatz"
                    });
            this.Events.Add(
                new Event
                    {
                        ActivatedAt = new DateTime(2011, 08, 15), 
                        Date = "16.09.2011, 18:30 Uhr", 
                        DateOrder = new DateTime(2011, 09, 16), 
                        Description =
                            "Vorfreude ist bekanntlich die schönste Freude, aber am schönsten ist es doch wenn es endlich losgeht! Deshalb feiern Insider beim \"Früh...", 
                        ExpiresAt = new DateTime(2011, 09, 17), 
                        IsActivated = true, 
                        Title = "Frühstart"
                    });
            this.Events.Add(
                new Event
                    {
                        ActivatedAt = new DateTime(2011, 09, 01), 
                        Date = "11.11.2011 - 13.11.2011", 
                        DateOrder = new DateTime(2011, 11, 11), 
                        Description =
                            "Seit über 20 Jahren das erfolgreiche Messeforum für Spiritualität und sanfte Medizin.", 
                        ExpiresAt = new DateTime(2011, 11, 14), 
                        IsActivated = true, 
                        Title = "ESOTERIK-Tage"
                    });
        }

        private void SeedFoods()
        {
            var firstMenu = this.Menus.Where(x => x.Date == new DateTime(2011, 07, 14)).FirstOrDefault();
            var vorspeiseCategory = this.Categorys.Where(x => x.Title == "Vorspeisen").FirstOrDefault();
            var mittagsschmankerlCategory = this.Categorys.Where(x => x.Title == "Mittagsschmankerl").FirstOrDefault();
            var hauptspeisenCategory = this.Categorys.Where(x => x.Title == "Hauptspeisen").FirstOrDefault();
            var dessertsCategory = this.Categorys.Where(x => x.Title == "Desserts").FirstOrDefault();

            this.Foods.Add(
                new Food
                    {
                        Category = vorspeiseCategory, 
                        Description = "Eiskaffee: 2 Kugeln Vanilleeis mit Kaffee und Schlagsahne", 
                        Menu = firstMenu, 
                        Price = 3.90m, 
                        SortOrder = 10, 
                        Title = "Kalter Kaffee macht schön – sagt man im Volksmund"
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = vorspeiseCategory, 
                        Description = "Grießnockerlsuppe mit Gemüse und vui Schnittlauch", 
                        Menu = firstMenu, 
                        Price = 4.20m, 
                        SortOrder = 20, 
                        Title = "Aus der Löwenkopfterrine"
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = vorspeiseCategory, 
                        Description = "Großer Marktsalat mit Hausdressing, Ochsenfetzen und frischem Malzbrot", 
                        Menu = firstMenu, 
                        Price = 11.50m, 
                        SortOrder = 30, 
                        Title = "Leicht & Frisch"
                    });

            this.Foods.Add(
                new Food
                    {
                        Category = mittagsschmankerlCategory, 
                        Description = "Paprika Hendl mit Butternudeln", 
                        Menu = firstMenu, 
                        Price = 7.50m, 
                        SortOrder = 40
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = mittagsschmankerlCategory, 
                        Description = "Spießrollbraten mit Kümmeljus und Kartoffelknödel", 
                        Menu = firstMenu, 
                        Price = 7.50m, 
                        SortOrder = 50
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = mittagsschmankerlCategory, 
                        Description = "Schweinerücken Steak vom Rost mit Broccoli, Kräuterbutter und Kartoffelecken", 
                        Menu = firstMenu, 
                        Price = 7.50m, 
                        SortOrder = 60
                    });

            this.Foods.Add(
                new Food
                    {
                        Category = hauptspeisenCategory, 
                        Description = "Frische Pfifferlinge in Rahmsoße mit Semmelknödel und frischen Kräutern", 
                        Menu = firstMenu, 
                        Price = 12.90m, 
                        SortOrder = 70, 
                        Title = "Frische Pfifferlinge"
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = hauptspeisenCategory, 
                        Description = "Rösches Spanferkel in Natursoße mit Semmelknödel und Speckkrautsalat", 
                        Menu = firstMenu, 
                        Price = 13.50m, 
                        SortOrder = 80, 
                        Title = "Spezialität des Hauses"
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = hauptspeisenCategory, 
                        Description =
                            "Ochsenfilet (200g) vom Grill mit Bärlauchkruste, Pfifferlingen und Rosmarinkartoffeln", 
                        Menu = firstMenu, 
                        Price = 19.80m, 
                        SortOrder = 90
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = hauptspeisenCategory, 
                        Description = "Schweinerücken Steak vom Rost mit Broccoli, Kräuterbutter und Kartoffelecken", 
                        Menu = firstMenu, 
                        Price = 13.90m, 
                        SortOrder = 100, 
                        Title = "Gemischtes Bratenpfandl"
                    });
            this.Foods.Add(
                new Food
                    {
                        Category = hauptspeisenCategory, 
                        Description =
                            "Gebratene Schweinerückensteaks mit Champignons und Bergkäse überbacken, dazu gibt’s kleine Rösti", 
                        Menu = firstMenu, 
                        Price = 14.50m, 
                        SortOrder = 110, 
                        Title = "Alpenländer Schnitzel"
                    });

            this.Foods.Add(
                new Food
                    {
                        Category = dessertsCategory, 
                        Menu = firstMenu, 
                        Price = 5.50m, 
                        SortOrder = 120, 
                        Title =
                            "Gebratene Schweinerückensteaks mit Champignons und Bergkäse überbacken, dazu gibt’s kleine Rösti"
                    });
        }

        private void SeedMenus()
        {
            this.Menus.Add(new Menu { Date = new DateTime(2011, 07, 14), Description = "Schmankerl - Donnerstag" });
        }

        private void SeedPictures()
        {
            this.Pictures.Add(
                new Picture
                    {
                        Description = "Leckerer Schweinsbratn...", 
                        FileName = "schweinsbratn.jpg", 
                        Link = @"D:\web\pictures\2012\02\", 
                        SortOrder = 1
                    });
            this.Pictures.Add(
                new Picture
                    {
                        Description = "Unser Kaiserschmarrn", 
                        FileName = "ks.jpg", 
                        Link = @"D:\web\pictures\2012\01\", 
                        SortOrder = 2
                    });
            this.Pictures.Add(
                new Picture
                    {
                        Description = "Obstsalat mit viieeel Quark... ;-)", 
                        FileName = "oss.jpg", 
                        Link = @"D:\web\pictures\2012\02\", 
                        SortOrder = 3
                    });
            this.Pictures.Add(
                new Picture
                    {
                        Description = "Fuer unsere Leistungssportler...", 
                        FileName = "einfachNix.jpg", 
                        Link = @"D:\web\pictures\2011\12\", 
                        SortOrder = 4
                    });
        }

        private void SeedQuestionsAndAnswers(long serieId)
        {
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer
                                        {
                                            Description = "Kiss", 
                                            Explanation = "Ganz ohne Makeup rockten Kiss hier vor 2000 begeisterten Fans.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "Queen" }, 
                                    new Answer { Description = "The Sweet" }
                                }, 
                        Description = "Welche Band spielte 1983 live im Löwenbräukeller?", 
                        Number = 1, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer { Description = "29. Februar 1901" }, 
                                    new Answer
                                        {
                                            Description = "14. Juni 1883", 
                                            Explanation =
                                                "Insgesamt 413.311.11 Mark zahlte der Brauer und Löwenbräu-Eigentümer Ludwig Brey für den Bau.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "3. November 1814" }
                                }, 
                        Description = "Wann wurde der Löwenbräukeller feierlich eröffnet?", 
                        Number = 2, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer { Description = "Bier-Pipeline" }, 
                                    new Answer { Description = "Keferloher-Spülmaschine" }, 
                                    new Answer
                                        {
                                            Description = "Elektrisches Licht", 
                                            Explanation =
                                                "Das gesamte Gebäude, sowohl außen als auch innen, verfügte über eine elektrische Beleuchtung.", 
                                            IsRight = true
                                        }
                                }, 
                        Description = "Welche Sensation bot der Löwenbräukeller um 1894 den Münchnern?", 
                        Number = 3, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer
                                        {
                                            Description = "Großbrand", 
                                            Explanation =
                                                "Über Nacht brannte der gerade erst vollkommen renovierte Festsaal samt Galerie und Balkon ab.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "Guiness-Hochzeitsrekord" }, 
                                    new Answer { Description = "Wiedereröffnung" }
                                }, 
                        Description = "Was geschah am 23. Juli 1986 im Löwenbräukeller?", 
                        Number = 4, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer
                                        {
                                            Description = "850 Jahre", 
                                            Explanation =
                                                "Urkundlich wurde München erstmals 1158 erwähnt. Regiert wurde es vom Welfen-Herzog Heinrich der Löwe.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "600 Jahre" }, 
                                    new Answer { Description = "1100 Jahre" }
                                }, 
                        Description = "Welchen runden Geburtstag feierte München 2008?", 
                        Number = 5, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer { Description = "anno 1480" }, 
                                    new Answer { Description = "anno 1553" }, 
                                    new Answer
                                        {
                                            Description = "anno 1383", 
                                            Explanation =
                                                "Bis 1383 lässt sich die Bräu-Geschichte zurückverfolge. 1818 erwirbt der Brauer Georg Brey die Löwenbrauerei und macht Löwenbräu zur größten Brauer.", 
                                            IsRight = true
                                        }
                                }, 
                        Description = "Wann wurde die Löwenbräu-Brauerei gegründet?", 
                        Number = 6, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer
                                        {
                                            Description = "nach Aschermittwoch", 
                                            Explanation =
                                                "Nachdem Ende des Faschings beginnt die Zeit des Fasten und somit auch die Starkbierzeit. Im Löwenbräukeller wird dann vier Wochen lang ein süffiges Triumphator ausgeschenkt.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "nach Ostern" }, 
                                    new Answer { Description = "nach dem Oktoberfest" }
                                }, 
                        Description = "Wann beginnt alljährlich die Starkbierzeit im Löwenbräukeller?", 
                        Number = 7, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer { Description = "Reichster Mann Bayerns" }, 
                                    new Answer
                                        {
                                            Description = "Stärkster Mann Bayerns", 
                                            Explanation =
                                                "Der Münchner Metzger galt anno 1879 als \"Stärkster Mann Bayerns\". Denn es ihm gelang einen 259 kg schweren Stein nur mit einem Finger anzulupfen. Die Tradition des Steinhebens findet auch heute noch während der Starkbierzeit im Löwenbräukeller statt.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "Schönster Mann Bayerns" }
                                }, 
                        Description =
                            "Mit welchem Titel verewigte sich der legendäre Steyrer Hans in den Geschichtsbüchern Bayerns?", 
                        Number = 8, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer { Description = "1901" }, 
                                    new Answer { Description = "1890" }, 
                                    new Answer
                                        {
                                            Description = "1867", 
                                            Explanation =
                                                "Genau 50 Personen fanden anno 1867 Platz in dem ersten Biertempel auf dem Oktoberfest. Allerdings handelt es sich dabei noch um kein Zelt, sondern einen Bretterschuppen.", 
                                            IsRight = true
                                        }
                                }, 
                        Description =
                            "Wann gründete die Familie Schottenhamel das \"erste Wiesn-Zelt\" auf der Theresienwiese?", 
                        Number = 9, 
                        Points = 3, 
                        SerieId = serieId
                    });
            this.Questions.Add(
                new Question
                    {
                        Answers =
                            new List<Answer> {
                                    new Answer
                                        {
                                            Description = "1806", 
                                            Explanation =
                                                "Dank Napoleon wurde Bayern am 1. Januar 1806 zum Königreich erhoben. Aus Kurfürst Herzog Maximilian IV. Joseph von Bayern wurde so König Maximilian I. von Bayern, der sogleich München zur Hauptstadt seines neuen wesentlich größeren Reichs ernannte.", 
                                            IsRight = true
                                        }, 
                                    new Answer { Description = "1861" }, 
                                    new Answer { Description = "1799" }
                                }, 
                        Description = "Wann wurde München Hauptstadt des Königreichs Bayern?", 
                        Number = 10, 
                        Points = 3, 
                        SerieId = serieId
                    });
        }

        private long SeedSeries()
        {
            var serie = new Serie
                            {
                                ActivatedAt = new DateTime(2011, 07, 14), 
                                Description = "Eröffnungsquiz", 
                                ExpiresAt = new DateTime(2011, 08, 25), 
                                IsActivated = true
                            };
            this.Series.Add(serie);

            this.SaveChanges();
            return serie.Id;
        }

        #endregion
    }
}
