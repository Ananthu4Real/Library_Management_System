using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EntLibraryProj.Entities;

// Add profile data for application users by adding properties to the LibraryUser class
public class LibraryUser : IdentityUser
{
    /// <summary>
    /// Principle: Ian for the first three, Ryan for the rest. Ian used to add custom identity users to the table. Ryan used it to add up to three items for each user for item checkout
    /// </summary>
    public int LibraryCardNum { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [ForeignKey("Item1")]
    public int? itemId1 { get; set; }
    public LibraryItem? Item1 { get; set; }

    [ForeignKey("Item2")]
    public int? itemId2 { get; set; }
    public LibraryItem? Item2 { get; set; }

    [ForeignKey("Item3")]
    public int? itemId3 { get; set; }
    public LibraryItem? Item3 { get; set; }

}

