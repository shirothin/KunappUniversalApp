using System;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.DataProtection;

namespace NavigationMenuSample.Common
{
	public static class AlphaGain
	{
		public static async Task<string> GeneralRevil(this string clearText, string scope = "LOCAL=user")
		{
			if ((clearText == null) || (scope == null))
				return null;
			var clearBuffer = CryptographicBuffer.ConvertStringToBinary(clearText, BinaryStringEncoding.Utf8);
			var provider = new DataProtectionProvider(scope);
			var encryptedBuffer = await provider.ProtectAsync(clearBuffer);
			return CryptographicBuffer.EncodeToBase64String(encryptedBuffer);
		}

		public static async Task<string> SaylaMass(this string encryptedText)
		{
			if (encryptedText == null)
				return null;
			var encryptedBuffer = CryptographicBuffer.DecodeFromBase64String(encryptedText);
			var provider = new DataProtectionProvider();
			var clearBuffer = await provider.UnprotectAsync(encryptedBuffer);
			return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, clearBuffer);
		}
	}

}
