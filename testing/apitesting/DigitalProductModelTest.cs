using apitesting.DTOs;
using apitesting.Models;

namespace api
{
    public class DigitalProductModelTest
    {
        NewProductModelDTO DTO = new NewProductModelDTO
        {
            Name = "Sample Digital Product",
            Description = "This is a sample digital product description",
            Keywords = "sample, digital, product"
        };

        [Fact]
        public void ConstructorSetsIsDigitalProductToTrue()
        {
            // Instantiate a DigitalProductModel using the constructor
            DigitalProductModel Obj = new DigitalProductModel(DTO);

            Assert.True(Obj.IsDigitalProduct);
        }

        [Fact]
        public void ConstructorSetsIsComingSoonToTrue()
        {
            // Instantiate a DigitalProductModel using the constructor
            DigitalProductModel Obj = new DigitalProductModel(DTO);

            Assert.True(Obj.IsComingSoon);
        }

        [Fact]
        public void ConstructorSetsIsAvailableForNewCartsToFalse()
        {
            // Instantiate a DigitalProductModel using the constructor
            DigitalProductModel Obj = new DigitalProductModel(DTO);

            Assert.False(Obj.IsAvailableForNewCarts);
        }
    }
}
