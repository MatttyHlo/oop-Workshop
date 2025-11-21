using oop_workshop.src.Domain.Media;
using oop_workshop.src.Domain.User;
using NUnit.Framework;

namespace UnitTests;

public class MediaTests
{
    [Test]
    public void Media_Constructor_SetsTitle()
    {
        var media = new Media("Test Book");
        Assert.That(media.title, Is.EqualTo("Test Book"));
    }

    [Test]
    public void AddRating_ValidRating_UpdatesRating()
    {
        var media = new Media("Test Book");
        media.AddRating(5);
        Assert.That(media.rating, Is.EqualTo(5.0));
    }

    [Test]
    public void AddRating_MultipleRatings_CalculatesAverage()
    {
        var media = new Media("Test Book");
        media.AddRating(4);
        media.AddRating(5);
        Assert.That(media.rating, Is.EqualTo(4.5));
    }

    [Test]
    public void AddRating_RatingTooLow_ThrowsException()
    {
        var media = new Media("Test Book");
        Assert.Throws<ArgumentOutOfRangeException>(() => media.AddRating(0));
    }

    [Test]
    public void AddRating_RatingTooHigh_ThrowsException()
    {
        var media = new Media("Test Book");
        Assert.Throws<ArgumentOutOfRangeException>(() => media.AddRating(6));
    }
}

public class BorrowerTests
{
    [Test]
    public void Borrower_Constructor_SetsProperties()
    {
        var borrower = new Borrower("John", 25, 123456789);
        Assert.That(borrower.Name, Is.EqualTo("John"));
        Assert.That(borrower.Age, Is.EqualTo(25));
        Assert.That(borrower.SocialSecurityNumber, Is.EqualTo(123456789));
    }

    [Test]
    public void Rate_ValidRating_AddsRatingToMedia()
    {
        var borrower = new Borrower("John", 25, 123456789);
        var media = new Media("Test Book");
        
        borrower.Rate(media, 5);
        
        Assert.That(media.rating, Is.EqualTo(5.0));
    }

    [Test]
    public void Rate_InvalidRating_DisplaysError()
    {
        var borrower = new Borrower("John", 25, 123456789);
        var media = new Media("Test Book");
        
        // Should not throw, but handle gracefully
        Assert.DoesNotThrow(() => borrower.Rate(media, 6));
    }

    [Test]
    public void ViewDetails_ExistingItem_DisplaysInfo()
    {
        var borrower = new Borrower("John", 25, 123456789);
        var items = new List<Media> 
        { 
            new Media("Book1"),
            new Media("Book2")
        };
        
        Assert.DoesNotThrow(() => borrower.ViewDetails("Book1", items));
    }

    [Test]
    public void ViewDetails_NonExistentItem_DisplaysNotFound()
    {
        var borrower = new Borrower("John", 25, 123456789);
        var items = new List<Media> 
        { 
            new Media("Book1")
        };
        
        Assert.DoesNotThrow(() => borrower.ViewDetails("NonExistent", items));
    }
}
