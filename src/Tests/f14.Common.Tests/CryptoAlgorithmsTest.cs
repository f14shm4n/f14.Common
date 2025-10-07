using f14.Security;
using FluentAssertions;

namespace f14.Common.Tests
{
    public class CryptoAlgorithmsTest
    {
        [Theory]
        [InlineData("Hello world.")]
        [InlineData("This is ad dummy string.")]
        public void EncryptAndDecryptString(string inputString)
        {
            byte[] key = { 0xCE, 0x95, 0x11, 0x33, 0x23, 0xFC, 0xAC, 0xCD, 0xCC, 0x41, 0x88, 0x99, 0x61, 0xF9, 0xC4, 0x33 };

            var aes = new AesEncryptor();

            var encrypted = aes.Encrypt(inputString, key);
            var encryptedString = Convert.ToBase64String(encrypted);

            var decryptedString = aes.Decrypt(Convert.FromBase64String(encryptedString), key);

            inputString.Should().Be(decryptedString);
        }
    }
}
