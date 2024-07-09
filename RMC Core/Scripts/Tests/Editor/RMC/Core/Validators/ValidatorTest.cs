using NUnit.Framework;
using RMC.Core.Exceptions;

namespace RMC.Core.Validators
{
    public class SampleValidatable : IValidatable<int>
    {
        public int Value { get; }

        public SampleValidatable(int value)
        {
            Value = value;
        }
    }
    public class SampleValidator : GenericValidator<SampleValidatable>
    {
        public override bool Validate(SampleValidatable validatable)
        {
            // Provide validation (Fictitious example shown)
            return validatable.Value == 10;
        }
    }
    
    /// <summary>
    /// Replace with comments...
    /// </summary>
    [Category("RMC.Core")]
    public class ValidatorTest
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------


        //  Initialization --------------------------------


        //  Methods ---------------------------------------
        [Test]
        public void Validate_ResultIsTrue_WhenIsValueIs10()
        {
            // Arrange
            SampleValidatable sampleValidatable = new SampleValidatable(10);
            SampleValidator sampleValidator = new SampleValidator();

            // Act
            bool result = sampleValidator.Validate(sampleValidatable);

            // Assert
            Assert.That(result, Is.True);
            
        }
        
        [Test]
        public void RequireIsValid_DoesNotThrow_WhenIsValueIs10()
        {
            // Arrange
            SampleValidatable sampleValidatable = new SampleValidatable(10);
            SampleValidator sampleValidator = new SampleValidator();

            // Assert
            Assert.DoesNotThrow(() =>
            {
                // Act
                sampleValidator.RequireIsValid(sampleValidatable);
            });
        }
        
        [Test]
        public void Validate_ResultIsFalse_WhenIsValueIs5()
        {
            // Arrange
            SampleValidatable sampleValidatable = new SampleValidatable(5);
            SampleValidator sampleValidator = new SampleValidator();

            // Act
            bool result = sampleValidator.Validate(sampleValidatable);

            // Assert
            Assert.That(result, Is.False);
            
        }
        
        [Test]
        public void RequireIsValid_DoesThrow_WhenIsValueIs5()
        {
            // Arrange
            SampleValidatable sampleValidatable = new SampleValidatable(5);
            SampleValidator sampleValidator = new SampleValidator();

            // Assert
            Assert.Throws<IsNotValidException>(() =>
            {
                // Act
                sampleValidator.RequireIsValid(sampleValidatable);
            });
        }


        //  Event Handlers --------------------------------
    }
}