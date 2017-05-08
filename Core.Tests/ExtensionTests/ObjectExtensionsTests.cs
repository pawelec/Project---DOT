using Core.Extensions;
using FluentAssertions;
using System;
using Xunit;

namespace Core.Tests.ExtensionTests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void IsNull_EntityIsNullReferenceType_ShouldReturnTrue()
        {
            // Arrange
            object entity = null;

            // Act
            var actualResult = entity.IsNull();

            // Assert
            actualResult.Should().BeTrue();
        }
        [Fact]
        public void IsNull_EntityIsNotNullReferenceType_ShouldReturnFalse()
        {
            // Arrange
            object entity = new object();

            // Act
            var actualResult = entity.IsNull();

            // Assert
            actualResult.Should().BeFalse();
        }
        [Fact]
        public void IsNull_NullableTypeAsNull_ShouldReturnTrue()
        {
            // Arrange
            Nullable<int> entity = new Nullable<int>();

            // Act
            var actualResult = entity.IsNull();

            // Assert
            actualResult.Should().BeTrue();
        }
        [Fact]
        public void IsNull_NullableTypeAsNotNull_ShouldReturnFalse()
        {
            // Arrange
            Nullable<int> entity = 5;

            // Act
            var actualResult = entity.IsNull();

            // Assert
            actualResult.Should().BeFalse();
        }
        [Fact]
        public void IsNull_ValueType_ShouldReturnFalse()
        {
            // Arrange
            int entity = 5;

            // Act
            var actualResult = entity.IsNull();

            // Assert
            actualResult.Should().BeFalse();
        }
    }
}
