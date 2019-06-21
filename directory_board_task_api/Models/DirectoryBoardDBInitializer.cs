using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace directory_board_task_api.Models
{
    public class DirectoryBoardDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<DirectoryBoardContext>
    {
        protected override void Seed(DirectoryBoardContext context)
        {
            var mockData = new List<Directory>
            {
                new Directory { Id = 1, Company = "AB&C INTERNATIONAL", Level = "8", Suite = "806" },
                                new Directory { Id = 2, Company = "AXA Insurance Agency Pty Ltd", Level = "1", Suite = "104" },
                                new Directory { Id = 3, Company = "Alex & Sons Consulting Pty Ltd", Level = "10", Suite = "1002" },
                                new Directory { Id = 4, Company = "Altura Care", Level = "5", Suite = "505" },
                                new Directory { Id = 5, Company = "Auroral Design", Level = "11", Suite = "1105" },
                                new Directory { Id = 6, Company = "Australia Burger Pty Ltd", Level = "6", Suite = "604" },
                                new Directory { Id = 7, Company = "Austra Cats Pty Ltd", Level = "9", Suite = "901" },
                                new Directory { Id = 8, Company = "Armstrong Legal Consulting", Level = "6", Suite = "605" },
                                new Directory { Id = 9, Company = "AXE recruitment", Level = "4", Suite = "401" },
                                new Directory { Id = 10, Company = "Balance Life", Level = "6", Suite = "605" },
                                new Directory { Id = 11, Company = "Balance Recreation", Level = "3", Suite = "302" },
                                new Directory { Id = 12, Company = "Brook & Pown Co", Level = "3", Suite = "305" },
                                new Directory { Id = 13, Company = "BTC Ready Limited", Level = "8", Suite = "805" },
                                new Directory { Id = 14, Company = "Carramel Consulting", Level = "6", Suite = "606" },
                                new Directory { Id = 15, Company = "Carrington Financial", Level = "11", Suite = "1105" },
                                new Directory { Id = 16, Company = "Casual Meal", Level = "2", Suite = "204" },
                                new Directory { Id = 17, Company = "Centenary Legal Practice", Level = "3", Suite = "306" },
                                new Directory { Id = 18, Company = "Central Accounting & Taxation", Level = "1", Suite = "105" },
                                new Directory { Id = 19, Company = "lever Mortgages", Level = "9", Suite = "904" },
                                new Directory { Id = 20, Company = "Clearly 90's Pty", Level = "6", Suite = "605" },
                                new Directory { Id = 21, Company = "Consult ME", Level = "6", Suite = "603" },
                                new Directory { Id = 22, Company = "Corporate Technology Services", Level = "2", Suite = "202" },
                                new Directory { Id = 23, Company = "Egis Papa", Level = "7", Suite = "701" },
                                new Directory { Id = 24, Company = "FERMER Insurance Specialists", Level = "1", Suite = "104" },
                                new Directory { Id = 25, Company = "Fire Shock Pty Ltd", Level = "10", Suite = "1005" },
                                new Directory { Id = 26, Company = "Global Video Pty Ltd", Level = "2", Suite = "201" },
                                new Directory { Id = 27, Company = "Golf Ball Specialist", Level = "3", Suite = "301" },
                                new Directory { Id = 28, Company = "GRTO Institute", Level = "1", Suite = "101" },
                                new Directory { Id = 29, Company = "Immigration Experts Pty Ltd", Level = "8", Suite = "801" },
                                new Directory { Id = 30, Company = "Instragram", Level = "9", Suite = "904" },
                                new Directory { Id = 31, Company = "Kenny & Associates Lawyers", Level = "9", Suite = "901" },
                                new Directory { Id = 32, Company = "Leadership Education Australia", Level = "7", Suite = "703" },
                                new Directory { Id = 33, Company = "LMAO Lawyers Pty Ltd", Level = "7", Suite = "709" },
                                new Directory { Id = 34, Company = "Mars Pty Ltd", Level = "2", Suite = "201" },
                                new Directory { Id = 35, Company = "Muri Muri Legal Practice", Level = "8", Suite = "802" },
                                new Directory { Id = 36, Company = "Peaceful Strata Management", Level = "8", Suite = "809" },
                                new Directory { Id = 37, Company = "Pinterested", Level = "1", Suite = "103" },
                                new Directory { Id = 38, Company = "Simple Supply", Level = "7", Suite = "705" },
                                new Directory { Id = 39, Company = "SXS Advisory Group", Level = "9", Suite = "901" },
                                new Directory { Id = 40, Company = "Skukura", Level = "11", Suite = "1104" },
                                new Directory { Id = 41, Company = "Sports Focus Physiotherapy", Level = "2", Suite = "204" },
                                new Directory { Id = 42, Company = "Think Harder", Level = "7", Suite = "705" },
                                new Directory { Id = 43, Company = "Tripple P", Level = "11", Suite = "1101" },
                                new Directory { Id = 44, Company = "Tri Logic", Level = "4", Suite = "405" },
                                new Directory { Id = 45, Company = "Umlaut", Level = "1", Suite = "101" },
                                new Directory { Id = 46, Company = "2hats", Level = "7", Suite = "209" },
                                new Directory { Id = 47, Company = "3D printer shop", Level = "1", Suite = "104" },

            };
            mockData.ForEach(p => context.Directories.AddOrUpdate(p));

        }
    }
}