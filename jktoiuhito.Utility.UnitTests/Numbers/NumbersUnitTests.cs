using jktoiuhito.Utility.Numbers;
using Xunit;
using System;

/*
 * This file was automatically generated 2020/09/01 12:19:08 UTC time.
 * All manual changes will be lost.
 */

namespace jktoiuhito.Utility.UnitTests.Numbers
{
    public class NumbersUnitTests
    {
                    [Theory]
            [InlineData(-1, "")]
            [InlineData(-1, " ")]
            [InlineData(-1, "　")]
            [InlineData(-1, "	")]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void sbyteNotZero_EmptyWhitespaceLocalname_ThrowsException (
                sbyte number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void sbyteNotZero_Negative_ReturnsInput (string localname)
            {
                sbyte number = -1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void sbyteNotZero_Positive_ReturnsInput (string localname)
            {
                sbyte number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void sbyteNotZero_Zero_ThrowsException (string localname)
            {
                sbyte number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(-1, "")]
            [InlineData(-1, " ")]
            [InlineData(-1, "　")]
            [InlineData(-1, "	")]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void shortNotZero_EmptyWhitespaceLocalname_ThrowsException (
                short number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void shortNotZero_Negative_ReturnsInput (string localname)
            {
                short number = -1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void shortNotZero_Positive_ReturnsInput (string localname)
            {
                short number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void shortNotZero_Zero_ThrowsException (string localname)
            {
                short number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(-1, "")]
            [InlineData(-1, " ")]
            [InlineData(-1, "　")]
            [InlineData(-1, "	")]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void intNotZero_EmptyWhitespaceLocalname_ThrowsException (
                int number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void intNotZero_Negative_ReturnsInput (string localname)
            {
                int number = -1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void intNotZero_Positive_ReturnsInput (string localname)
            {
                int number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void intNotZero_Zero_ThrowsException (string localname)
            {
                int number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(-1, "")]
            [InlineData(-1, " ")]
            [InlineData(-1, "　")]
            [InlineData(-1, "	")]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void longNotZero_EmptyWhitespaceLocalname_ThrowsException (
                long number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void longNotZero_Negative_ReturnsInput (string localname)
            {
                long number = -1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void longNotZero_Positive_ReturnsInput (string localname)
            {
                long number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void longNotZero_Zero_ThrowsException (string localname)
            {
                long number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            
                    [Theory]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void byteNotZero_EmptyWhitespaceLocalname_ThrowsException (
                byte number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void byteNotZero_Positive_ReturnsInput (string localname)
            {
                byte number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void byteNotZero_Zero_ThrowsException (string localname)
            {
                byte number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void ushortNotZero_EmptyWhitespaceLocalname_ThrowsException (
                ushort number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void ushortNotZero_Positive_ReturnsInput (string localname)
            {
                ushort number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void ushortNotZero_Zero_ThrowsException (string localname)
            {
                ushort number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void uintNotZero_EmptyWhitespaceLocalname_ThrowsException (
                uint number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void uintNotZero_Positive_ReturnsInput (string localname)
            {
                uint number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void uintNotZero_Zero_ThrowsException (string localname)
            {
                uint number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
                    [Theory]
            [InlineData(0, "")]
            [InlineData(0, " ")]
            [InlineData(0, "　")]
            [InlineData(0, "	")]
            [InlineData(1, "")]
            [InlineData(1, " ")]
            [InlineData(1, "　")]
            [InlineData(1, "	")]
            public void ulongNotZero_EmptyWhitespaceLocalname_ThrowsException (
                ulong number, string localname)
            {
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void ulongNotZero_Positive_ReturnsInput (string localname)
            {
                ulong number = 1;
    
                var result = number.NotZero(localname);
    
                Assert.Equal(number, result);
            }
    
            [Theory]
            [InlineData(null)]
            [InlineData("name")]
            public void ulongNotZero_Zero_ThrowsException (string localname)
            {
                ulong number = 0;
    
                Assert.Throws<ArgumentException>(
                    () => number.NotZero(localname));
            }
            }
}