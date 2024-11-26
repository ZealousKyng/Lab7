using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Blazor_Lab_Starter_Code;

namespace LibTests
{
    [TestClass]
    public class ProgramTests
    {

        [TestMethod]
        public void Fail_ReadBooks()
        {
            // Arrange:
            Program.books.Clear();

            // Act:
            Program.ReadBooks();

            // Assert:
            Assert.AreEqual(2, Program.books.Count); //Fails because there a lot more than 2 books
            Assert.AreEqual("Flesh and the Devil", Program.books[0].Title);
            Assert.AreEqual("Alecia Polycote", Program.books[1].Author);
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_ReadBooks()
        {

            //Arrange:
            Program.books.Clear();

            //Act:
            Program.ReadBooks();

            // Assert:
            Assert.AreEqual(1000/*this is the actual count of Books.csv*/, Program.books.Count);
            Assert.AreEqual("Flesh and the Devil", Program.books[0].Title);
            Assert.AreEqual("Alecia Polycote", Program.books[1].Author);
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_ReadUsers()
        {
            // Arrange:
            Program.users.Clear();

            //Act:
            Program.ReadUsers();

            //Assert:
            Assert.AreEqual("Dannye Jarradeee", /*SHould Fail here because of mispelled name*/ Program.users[0].Name);
            Assert.AreEqual("dflatman1@youtu.be", Program.users[1].Email);
            Program.users.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_ReadUsers()
        {
            // Arrange:
            Program.users.Clear();

            //Act:
            Program.ReadUsers();

            //Assert:
            Assert.AreEqual("Dannye Jarrad", Program.users[0].Name);
            Assert.AreEqual("dflatman1@youtu.be", Program.users[1].Email);
            Program.users.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_AddBook()
        {
            //Arrange: Fake user input
            var input = new StringReader("The Great Gatsby\nF. Scott Fitzgerald\n9780743273565\n");
            Console.SetIn(input);

            // Clear the books list before running the method
            Program.books.Clear();

            //Act:
            Program.AddBook();

            // Assert:
            Assert.AreEqual(1, Program.books.Count);
            Assert.AreEqual("The Great Gatsby", Program.books[0].Title);
            Assert.AreEqual("F. Scott Fitzgerald", Program.books[0].Author);
            Assert.AreEqual("9780743273565", Program.books[0].ISBN);

            //When i was reaserching the Console.SetIn it said i might need this
            Console.SetIn(new StringReader(string.Empty));
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_AddBook()
        {
            //Arrange: Fake user input
            var input = new StringReader("The Great Gatsby\nF. Scott Fitzgerald\n"); //Fails because user did not input ISBN
            Console.SetIn(input);

            // Clear the books list before running the method
            Program.books.Clear();

            //Act:
            Program.AddBook();

            // Assert:
            Assert.AreEqual(1, Program.books.Count);
            Assert.AreEqual("The Great Gatsby", Program.books[0].Title);
            Assert.AreEqual("F. Scott Fitzgerald", Program.books[0].Author);
            Assert.AreEqual("756786567", Program.books[0].ISBN);

            //When i was reaserching the Console.SetIn it said i might need this
            Console.SetIn(new StringReader(string.Empty));
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_AddUser()
        {
            //Arrange: Fake user input
            var input = new StringReader("Seth Emerine\nEmerines@etsu.edu");
            Console.SetIn(input);

            // Clear the books list before running the method
            Program.users.Clear();

            //Act:
            Program.AddUser();

            // Assert:
            Assert.AreEqual(1, Program.users.Count);
            Assert.AreEqual("Seth Emerine", Program.users[0].Name);
            Assert.AreEqual("Emerines@etsu.edu", Program.users[0].Email);

            //When i was reaserching the Console.SetIn it said i might need this
            Console.SetIn(new StringReader(string.Empty));
            Program.users.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_AddUser()
        {
            //Arrange: Fake user input
            var input = new StringReader("Seth Emerine\nEmerines@etsu.edu");
            Console.SetIn(input);

            // Clear the books list before running the method
            Program.users.Clear();

            //Act:
            Program.AddUser();

            // Assert:
            Assert.AreEqual(1, Program.users.Count);
            Assert.AreEqual("Seth Emerne", Program.users[0].Name); //Fails because Misspelled name
            Assert.AreEqual("Emerines@etsu.edu", Program.users[0].Email);

            //When i was reaserching the Console.SetIn it said i might need this
            Console.SetIn(new StringReader(string.Empty));
            Program.users.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_DeleteBook()
        {
            //Arrange:
            Program.books.Clear();
            Program.books.Add(new Book { Id = 1, Title = "Michel Vey", Author = "Richard P. Evans", ISBN = "85504039" });

            var input = new StringReader("1\n");
            Console.SetIn(input);

            // Act:
            Program.DeleteBook();

            // Assert:
            Assert.AreEqual(0, Program.books.Count); // Book Deletus
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_DeleteBook()
        {
            //Arrange:
            Program.books.Clear();
            Program.books.Add(new Book { Id = 1, Title = "Michel Vey", Author = "Richard P. Evans", ISBN = "85504039" });

            var input = new StringReader("2\n"); //Wrong Input
            Console.SetIn(input);

            // Act:
            Program.DeleteBook();

            // Assert:
            Assert.AreEqual(0, Program.books.Count); // Book Deletus
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_DeleteUser()
        {
            //Arrange:
            Program.users.Clear();
            Program.users.Add(new User { Id = 1, Name = "Seth Emerine", Email = "Emerines@etsu.edu" });

            var input = new StringReader("1\n");
            Console.SetIn(input);

            // Act:
            Program.DeleteUser();

            // Assert:
            Assert.AreEqual(0, Program.users.Count); // Deletes Users
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_DeleteUser()
        {
            //Arrange:
            Program.users.Clear();
            Program.users.Add(new User { Id = 1, Name = "Seth Emerine", Email = "Emerines@etsu.edu" });

            var input = new StringReader("Timothy\n");
            Console.SetIn(input);

            // Act:
            Program.DeleteUser();

            // Assert:
            Assert.AreEqual(0, Program.users.Count); // Deletes Users
            //--------------------------------------------------------
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_ListBooks()
        {
            //Arrange:
            Program.books.Clear(); // Clear any existing books
            Program.books.Add(new Book { Id = 1, Title = "Flesh and the Devil", Author = "Claudine Hirche", ISBN = "695255409-2" });
            Program.books.Add(new Book { Id = 2, Title = "Slumber Party Massacre", Author = "Alecia Polycote", ISBN = "057219088-3" });
            Program.books.Add(new Book { Id = 3, Title = "Clonus Horror", Author = "Demetris McAlester", ISBN = "198033622-9" });

            //Grab
            var sw = new StringWriter();
            Console.SetOut(sw);

            //Act:
            Program.ListBooks();

            // Assert:
            var output = sw.ToString(); //Output to string

            // Check that the output contains the expected book details
            Assert.IsTrue(output.Contains("1. Flesh and the Devil by Claudine Hirche (ISBN: 695255409-2)"));
            Assert.IsTrue(output.Contains("2. Slumber Party Massacre by Alecia Polycote (ISBN: 057219088-3)"));
            Assert.IsTrue(output.Contains("3. Clonus Horror by Demetris McAlester (ISBN: 198033622-9)"));
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_ListBooks()//Not sure how to Fail this
        {
            //Arrange:
            Program.books.Clear(); // Clear any existing books
            Program.books.Add(new Book { Id = 1, Title = "Flesh and the Devil", Author = "Claudine Hirche", ISBN = "695255409-2" });
            Program.books.Add(new Book { Id = 2, Title = "Slumber Party Massacre", Author = "Alecia Polycote", ISBN = "057219088-3" });
            Program.books.Add(new Book { Id = 3, Title = "Clonus Horror", Author = "Demetris McAlester", ISBN = "198033622-9" });

            //Grab
            var sw = new StringWriter();
            Console.SetOut(sw);

            //Act:
            Program.ListBooks();

            // Assert:
            var output = sw.ToString(); //Output to string

            Assert.IsTrue(output.Contains("1. Flesh and the Devil by Claudine Hirche (ISBN: 695255409-2)"));
            Assert.IsTrue(output.Contains("2. Slumber Party Massacre by Alecia Polycote (ISBN: 057219088-3)"));
            Assert.IsTrue(output.Contains("3. Clonus Horror by Demetris McAlester (ISBN: 198033622-9)"));
            Program.books.Clear();
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Succeed_ListUsers()
        {
            // Arrange:
            Program.users.Clear();
            Program.users.Add(new User { Id = 1, Name = "Seth Emerine", Email = "semerine05@icloud.com" });
            Program.users.Add(new User { Id = 2, Name = "Jacob Norris", Email = "norrisj@outlook.com" });

            // Capture the console output
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act:
            Program.ListUsers();

            // Assert:
            var output = sw.ToString();

            // Check that the output contains the expected user details
            Assert.IsTrue(output.Contains("1. Seth Emerine (Email: semerine05@icloud.com)"));
            Assert.IsTrue(output.Contains("2. Jacob Norris (Email: norrisj@outlook.com)"));
        }
        //--------------------------------------------------------
        [TestMethod]
        public void Fail_ListUsers()//Not sure how to Fail this
        {
            // Arrange:
            Program.users.Clear();
            Program.users.Add(new User { Id = 1, Name = "Seth Emerine", Email = "semerine05@icloud.com" });
            Program.users.Add(new User { Id = 2, Name = "Jacob Norris", Email = "borrisj@outlook.com" });

            // Capture the console output
            var sw = new StringWriter();
            Console.SetOut(sw);

            // Act:
            Program.ListUsers();

            // Assert:
            var output = sw.ToString();

            // Check that the output contains the expected user details
            Assert.IsTrue(output.Contains("1. Seth Emerine (Email: semerine05@icloud.com)"));
            Assert.IsTrue(output.Contains("2. Jacob Norris (Email: norrisj@outlook.com)"));
        }
        //--------------------------------------------------------

        //--------------------------------------------------------
    }
}
