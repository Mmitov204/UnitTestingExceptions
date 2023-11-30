using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

   
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "hi";
        string expected = "ih";
        // Act
        string result = this._exceptions.ArgumentNullReverse(input);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {      // Arrange
        string input = "hi";
        string expected = "ih";
        // Act
        string result = this._exceptions.ArgumentNullReverse(input);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 10.0m;
        //Act
        decimal result = this._exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        //Assert
        Assert.That(result,Is.EqualTo(90));
    }

   
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -10.0m;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);

    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = { 1, 2, 3};
        int index = 1;
        //Act
        int result = this._exceptions.IndexOutOfRangeGetElement(array, index);
        //Assert
        Assert.That(result, Is.EqualTo(2));
    }

    
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int index = -1;
        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array,index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length + 3;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLogIn = true;

        //Act
        string resulrt = this._exceptions.InvalidOperationPerformSecureOperation(isLogIn);
        //Assert
        Assert.That(resulrt, Is.EqualTo("User logged in."));

    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool isLogIn = false;

        //Act & Assert
        Assert.That(()=> this._exceptions.InvalidOperationPerformSecureOperation(isLogIn), Throws.InstanceOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "3";
        //Act
        int result = this._exceptions.FormatExceptionParseInt(input);
        //Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "3,, ssdd11";
        //Act & Assert
        Assert.That(()=> this._exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
       
    } 

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> keyValue = new()
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3
        };
        string searchKey = "second";
        //Act
        int result = this._exceptions.KeyNotFoundFindValueByKey(keyValue, searchKey);
        //Assert
        Assert.That(result,Is.EqualTo(2));

    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> keyValue = new()
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3
        };
        string searchKey = "six";
        //Act & Assert
        Assert.That(()=> this._exceptions.KeyNotFoundFindValueByKey(keyValue,searchKey), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange 
        int num1 = 1;
        int num2 = 2;
        //Act
        int result = this._exceptions.OverflowAddNumbers(num1, num2);
        //Assert
        Assert.That(result,Is.EqualTo(3));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange 
        int num1 = int.MaxValue;
        int num2 = 1;
        //Act & Assert
        Assert.That(()=> this._exceptions.OverflowAddNumbers(num1,num2), Throws.InstanceOf<OverflowException>());   
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange 
        int num1 = int.MinValue;
        int num2 = -1;
        //Act & Assert
        Assert.That(() => this._exceptions.OverflowAddNumbers(num1, num2), Throws.InstanceOf<OverflowException>());

    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        //Arrange
        int num1 = 6;
        int num2 = 2;

        //Act
        int result = this._exceptions.DivideByZeroDivideNumbers(num1,num2);
        //Assert
        Assert.That(result, Is.EqualTo(3)); 
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        //Arrange
        int num1 = 19;
        int num2 = 0;
        //Act & Assert
        Assert.That(() => this._exceptions.DivideByZeroDivideNumbers(num1, num2),Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {

        //Arrange
        int[] colection = new[]{1,2,3};
        int index = 2; 

        //Act
        int result = this._exceptions.SumCollectionElements(colection, index);
        //Assert
        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        //Arrange
        int[]? colection = null;
        int index = 2;
        //Act & Assert
        Assert.That(()=>this._exceptions.SumCollectionElements(colection,index),Throws.ArgumentNullException);
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[]? colection = new[] {1,2,3,4,5};
        int index = 6;
        //Act & Assert
        Assert.That(() => this._exceptions.SumCollectionElements(colection, index), Throws.InstanceOf<IndexOutOfRangeException>());

    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        //Arrange
        Dictionary<string, string> collection = new()
        {
            ["f1"] = "1",
            ["f2"] = "2",
            ["f3"] = "3"
        };
        string key = "f1";
        //Act
        int result = this._exceptions.GetElementAsNumber(collection, key);
        //Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        //Arrange
        Dictionary<string, string> colection = new()
        {
            ["f1"] = "1",
            ["f2"] = "2",
            ["f2"] = "3"
        };
        string key = "1";
        //Act & Assert
        Assert.That(()=> this._exceptions.GetElementAsNumber(colection,key), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        //Arrange
        Dictionary<string, string> collection = new()
        {
            ["f1"] = "1",
            ["f2"] = "s2",
            ["f3"] = "3"
        };
        string key = "f2";

        //Act & Assert
        Assert.Throws<FormatException>(() => this._exceptions.GetElementAsNumber(collection, key));

    }
}
