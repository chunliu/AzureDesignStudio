using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System.Text;

namespace AzureDesignStudio.Server.Services
{
    public interface ICryptoService
    {
        Task<string> Encrypt(string plainText);
        Task<string> Decrypt(string encryptedText);
    }
    public class CryptoService : ICryptoService
    {
        private readonly CryptographyClient _cryptoClient;

        public CryptoService(IConfiguration configuration)
        {
            var chainedTokenCred = new ChainedTokenCredential(
                new ManagedIdentityCredential(),
                new AzureCliCredential());
            var keyClient = new KeyClient(new Uri($"https://{configuration["KeyVaultName"]}.vault.azure.net/"),
                chainedTokenCred);
            var key = keyClient.GetKey(configuration["KeyVaultKeyName"]).Value;
            _cryptoClient = new CryptographyClient(key.Id, chainedTokenCred);
        }
        public async Task<string> Decrypt(string encryptedText)
        {
            byte[] inputAsByteArray = Convert.FromBase64String(encryptedText);
            DecryptResult decryptResult = await _cryptoClient.DecryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray);
            return Encoding.Default.GetString(decryptResult.Plaintext);
        }

        public async Task<string> Encrypt(string plainText)
        {
            byte[] inputAsByteArray = Encoding.UTF8.GetBytes(plainText);
            EncryptResult encryptResult = await _cryptoClient.EncryptAsync(EncryptionAlgorithm.RsaOaep, inputAsByteArray);
            return Convert.ToBase64String(encryptResult.Ciphertext);
        }
    }
}
