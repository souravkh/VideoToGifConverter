using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VideoToGifConverter.Converter;

namespace VideoToGifConverter.UnitTests.ConverterTests
{
    /// <summary>
    /// Unit tests for the <see cref="BoolToVisibilityConverter"/> class.
    /// This class tests both the <see cref="BoolToVisibilityConverter.Convert"/> and
    /// <see cref="BoolToVisibilityConverter.ConvertBack"/> methods.
    /// </summary>
    [TestFixture]
    public class BoolToVisibilityConverterTests
    {
        private BoolToVisibilityConverter _converter;

        /// <summary>
        /// Sets up the test environment before each test case.
        /// Initializes the <see cref="BoolToVisibilityConverter"/> instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _converter = new BoolToVisibilityConverter();
        }

        #region Convert Method Tests

        /// <summary>
        /// Tests the <see cref="BoolToVisibilityConverter.Convert"/> method 
        /// when provided with boolean input values.
        /// </summary>
        /// <param name="input">The boolean input value to convert.</param>
        /// <param name="expected">The expected <see cref="Visibility"/> result.</param>
        [Test]
        [TestCase(true, Visibility.Visible)]
        [TestCase(false, Visibility.Collapsed)]
        public void Convert_WhenBooleanValue_ReturnsCorrectVisibility(bool input, Visibility expected)
        {
            // Act
            object result = _converter.Convert(input, typeof(Visibility), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.That(result, Is.InstanceOf<Visibility>(), "Result should be of type Visibility.");
            Assert.That((Visibility)result, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the <see cref="BoolToVisibilityConverter.Convert"/> method 
        /// when the input is not a boolean value.
        /// </summary>
        [Test]
        public void Convert_WhenInputIsNotBoolean_ReturnsCollapsed()
        {
            // Act
            object result = _converter.Convert("invalid", typeof(Visibility), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.That(result, Is.InstanceOf<Visibility>(), "Result should be of type Visibility.");
            Assert.That((Visibility)result, Is.EqualTo(Visibility.Collapsed));
        }

        #endregion

        #region ConvertBack Method Tests

        /// <summary>
        /// Tests the <see cref="BoolToVisibilityConverter.ConvertBack"/> method 
        /// when provided with valid <see cref="Visibility"/> values.
        /// </summary>
        /// <param name="input">The <see cref="Visibility"/> value to convert back.</param>
        /// <param name="expected">The expected boolean result after conversion.</param>
        [Test]
        [TestCase(Visibility.Visible, true)]
        [TestCase(Visibility.Collapsed, false)]
        [TestCase(Visibility.Hidden, false)] // Testing with Hidden to verify behavior
        public void ConvertBack_WhenVisibilityValue_ReturnsCorrectBoolean(Visibility input, bool expected)
        {
            // Act
            object objResult = _converter.ConvertBack(input, typeof(bool), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.That(objResult, Is.InstanceOf<bool>(), "Result should be of type bool.");
            Assert.That((bool)objResult, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the <see cref="BoolToVisibilityConverter.ConvertBack"/> method 
        /// when the input is not a valid <see cref="Visibility"/> value.
        /// </summary>
        [Test]
        public void ConvertBack_WhenInputIsNotVisibility_ReturnsFalse()
        {
            // Act
            object objResult = _converter.ConvertBack("invalid", typeof(bool), null, CultureInfo.InvariantCulture);

            // Assert
            Assert.That(objResult, Is.InstanceOf<bool>(), "Result should be of type bool.");
            Assert.That((bool)objResult, Is.EqualTo(false));
        }

        #endregion
    }
}
