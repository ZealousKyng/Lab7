using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blazor_Lab_Starter_Code; // Ensure correct namespace for your main project

namespace LibraryTests
{
    [TestClass]
    public class ReadBooksTests
    {
        private const string TestFilePath = "./Data/TestBooks.csv";

        [TestInitialize]
        public void Setup()
        {
            // Create a test CSV file with mock data
            if (!Directory.Exists("./Data"))
            {
                Directory.CreateDirectory("./Data");
            }

            File.WriteAllText(TestFilePath, "1,Flesh and the Devil,Claudine Hirche,695255409-2");
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Remove the test file after each test run
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [TestMethod]
        public void ReadBooks_ShouldPopulateBooksList_WithValidData()
        {
            // Arrange: Clear or prepare the books collection before calling ReadBooks (assuming it's a static collection).
            // Here we assume 'books' is accessible (consider making it public or providing a method to clear it)
            Blazor_Lab_Starter_Code.Program.books.Clear();

            // Act: Invoke the ReadBooks method
            Blazor_Lab_Starter_Code.Program.ReadBooks();

            // Assert: Check if books list is populated correctly
            Assert.AreEqual(2, Blazor_Lab_Starter_Code.Program.books.Count);
            Assert.AreEqual("Test Book", Blazor_Lab_Starter_Code.Program.books[0].Title);
            Assert.AreEqual("Another Book", Blazor_Lab_Starter_Code.Program.books[1].Title);
        }
    }
}
