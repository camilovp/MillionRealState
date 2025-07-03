using Moq;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Application.UseCases.Properties;
using RealState.Domain.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealState.Test.UseCasesTest
{
    [TestFixture]
    public class CreatePropertyUseCaseTests
    {
        private Mock<IPropertyRepository> _mockRepo;
        private CreatePropertyUseCase _useCase;
        private GetPropertyFilteredUseCase _getUseCase;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IPropertyRepository>();
            _useCase = new CreatePropertyUseCase(_mockRepo.Object);
            _getUseCase = new GetPropertyFilteredUseCase(_mockRepo.Object);
        }

        [Test]
        public async Task ExecuteAsync_WithValidData_ReturnsCreatedProperty()
        {
            // Arrange
            var dto = new CreatePropertyDto
            {
                Name = "Test Property",
                Address = "123 Main St",
                Price = 100000,
                CodeInternal = "PROP001",
                Year = 2023,
                IdOwner = "owner123"
            };

            var property = new Property
            {
                IdProperty = "",
                Name = dto.Name,
                Address = dto.Address,
                Price = dto.Price,
                CodeInternal = dto.CodeInternal,
                Year = dto.Year,
                IdOwner = dto.IdOwner
            };

            // Fix: Use the correct type for ReturnsAsync
            _mockRepo.Setup(r => r.CreateAsync(It.IsAny<Property>()))
                     .Returns(Task.FromResult(property));

            // Act
            var result = await _useCase.ExecuteAsync(dto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(dto.Name));
        }


        [Test]
        public async Task ExecuteAsync_RepositoryFails_ReturnsNull()
        {
            // Arrange
            var dto = new CreatePropertyDto
            {
                Name = "Test Property",
                Address = "123 Main St",
                Price = 100000,
                CodeInternal = "PROP001",
                Year = 2023,
                IdOwner = "owner123"
            };

            _mockRepo.Setup(r => r.CreateAsync(It.IsAny<Property>()))
                     .Returns(Task.FromResult<Property>(null));

            // Act
            var result = await _useCase.ExecuteAsync(dto);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ExecuteAsync_WithMatchingFilters_ReturnsFilteredProperties()
        {
            // Arrange
            var filter = new PropertyFilterDto
            {
                Name = "Test",
                Address = "123 Main St",
                MinPrice = 100000,
                MaxPrice = 200000
            };

            var expectedEntities = new List<Property>
            {
                new Property
                {
                    IdProperty = "1",
                    Name = "Test",
                    Address = "123 Main St",
                    Price = 150000,
                    CodeInternal = "PROP001",
                    Year = 2023,
                    IdOwner = "owner123"
                }
            };

            _mockRepo.Setup(r => r.GetFilteredAsync(filter))
                     .ReturnsAsync(expectedEntities);

            // Act
            var result = await _getUseCase.ExecuteAsync(filter);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Name, Is.EqualTo("Test"));
        }

        [Test]
        public async Task ExecuteAsync_NoMatchingFilters_ReturnsEmptyList()
        {
            // Arrange
            var filter = new PropertyFilterDto
            {
                Name = "Nonexistent"
            };

            _mockRepo.Setup(r => r.GetFilteredAsync(filter))
                     .ReturnsAsync(new List<Property>());

            // Act
            var result = await _getUseCase.ExecuteAsync(filter);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ExecuteAsync_RepositoryThrowsException_Throws()
        {
            // Arrange
            var filter = new PropertyFilterDto();

            _mockRepo.Setup(r => r.GetFilteredAsync(filter))
                     .ThrowsAsync(new System.Exception("Database failure"));

            // Act & Assert
            Assert.ThrowsAsync<System.Exception>(() => _getUseCase.ExecuteAsync(filter));
        }
    }
}
