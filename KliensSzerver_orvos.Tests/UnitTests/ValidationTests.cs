using Asszisztens_kliens.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KliensSzerver_orvos.Tests.UnitTests;

[TestClass]
public class ValidationTests
{
    [TestMethod]
    public void NameValidation_ShouldBeValid()
    {
        string teststring = "Szabó Kristóf";
        string teststring2 = "Kristóf";
        string teststring3 = "Szabó Kristóf Péter";

        Assert.AreEqual(true, Validation.IsValidName(teststring));
        Assert.AreEqual(true, Validation.IsValidName(teststring2));
        Assert.AreEqual(true, Validation.IsValidName(teststring3));

    }

    [TestMethod]
    public void NameValidation_ShouldBeInValid()
    {
        string name = "";
        string name2 = " ";
        string name3 = "Szabo-Kristof Adam";
        string name4 = "     ";
        string name5 = "Kristóf !Anita'";

        Assert.AreEqual(false, Validation.IsValidName(name));
        Assert.AreEqual(false, Validation.IsValidName(name2));
        Assert.AreEqual(false, Validation.IsValidName(name3));
        Assert.AreEqual(false, Validation.IsValidName(name4));
        Assert.AreEqual(false, Validation.IsValidName(name5));
    }


    [TestMethod]
    public void SSNValidation_ShouldBeValid()
    {
        string teststring = "012 345 678";
        string teststring2 = "123 456 789";

        Assert.AreEqual(true, Validation.IsValidSSN(teststring));
        Assert.AreEqual(true, Validation.IsValidSSN(teststring2));
    }

    [TestMethod]
    public void SSNValidation_ShouldBeInValid()
    {
        string teststring = "";
        string teststring2 = "123 46 789";
        string teststring3 = "13 46f 789";
        string teststring4 = "13 46 7890";

        Assert.AreEqual(false, Validation.IsValidSSN(teststring));
        Assert.AreEqual(false, Validation.IsValidSSN(teststring2));
        Assert.AreEqual(false, Validation.IsValidSSN(teststring3));
        Assert.AreEqual(false, Validation.IsValidSSN(teststring4));
    }
}