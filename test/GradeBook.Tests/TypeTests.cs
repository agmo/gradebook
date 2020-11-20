using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log;
            log = ReturnMessage;

            var result = log("Hello!");
            
            Assert.Equal("Hello!", result);
        }

        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMultipleMethods()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage2;

            log("Hello!");

            Assert.Equal(2, count);
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        string ReturnMessage2(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Name";
            var upper = MakeUpperCase(name);

            Assert.Equal("Name", name);
            Assert.Equal("NAME", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book1");
            var book2 = book1;

            Assert.True(Object.ReferenceEquals(book1, book2));
            // Better:
            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
