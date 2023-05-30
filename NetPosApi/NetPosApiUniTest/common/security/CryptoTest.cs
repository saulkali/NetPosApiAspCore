using System;
using NUnit.Framework;
using PyPosApi.common.security;

namespace NetPosApiUniTest.common.security
{
	[TestFixture]
	public class CryptoTest
	{
		[Test]
		public void HashPasswordTest()
		{
			string password = "helloworld";
			string expectedValue = "936a185caaa266bb9cbe981e9e05cb78cd732b0b3280eb944412bb6f8f8f07af";

			string hastPassword = Crypto.HashPassword(password);

			Assert.That(hastPassword, Is.EqualTo(expectedValue));
			
		}

		[Test]
		public void VerifyPasswordHashTest_IsCorrect()
		{
			string password = "helloworld";
			string hashPassword = "936a185caaa266bb9cbe981e9e05cb78cd732b0b3280eb944412bb6f8f8f07af";
			bool expectedValue = true;

			bool result = Crypto.VerifyPasswordHash(password,hashPassword);

			Assert.That(expectedValue,Is.EqualTo(result));
		}

        [Test]
        public void VerifyPasswordHashTest_IsInCorrect()
        {
            string password = "helloworld";
            string hashPassword = "936a185c81e9e05cb78cd732b0b3280eb9444";
            bool expectedValue = false;

            bool result = Crypto.VerifyPasswordHash(password, hashPassword);

            Assert.That(expectedValue, Is.EqualTo(result));
        }

    }
}

