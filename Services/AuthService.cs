using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PrintLayer.Models;
using PrintLayer.Repositories.Interfaces;
using PrintLayer.Services.Interfaces;

namespace PrintLayer.Services
{
    public class AuthService : IAuthService
    {
        private static readonly byte[] Pepper = Encoding.UTF8.GetBytes("Pepper12#$pepperP");
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> LoginAsync(string login, string password)
        {
            var passwordHash = GenerateHashPassword(password);
            var user = await _authRepository.GetUserByCredentialsAsync(login, passwordHash);
            if (user == null) return null;

            var roleNames = new HashSet<string>();

            return user;
        }

        public async Task<User> CreateUserAsync(string login, string password)
        {
            var user = await _authRepository.GetUserByLoginAsync(login);

            if (user != null)
                return null;

            var passwordHash = GenerateHashPassword(password); 
            await _authRepository.AddUser(login, passwordHash);

            user = await _authRepository.GetUserByLoginAsync(login);

            return user;
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _authRepository.GetUserByLoginAsync(login);
        }

        private static string GenerateHashPassword(ReadOnlySpan<char> password)
        {
            var bufferLength = Encoding.UTF8.GetByteCount(password);
            Span<byte> buffer = new byte[bufferLength];
            Encoding.UTF8.GetBytes(password, buffer);
            return PepperedHash(buffer, Pepper);
        }

        public static string PepperedHash(ReadOnlySpan<byte> plainText, ReadOnlySpan<byte> pepper)
        {
            using HashAlgorithm algorithm = new SHA256Managed();

            Span<byte> plainTextWithSaltBytes = new byte[plainText.Length + pepper.Length];

            plainText.CopyTo(plainTextWithSaltBytes.Slice(0, plainText.Length));
            pepper.CopyTo(plainTextWithSaltBytes.Slice(plainText.Length, pepper.Length));

            return GetHash(algorithm, plainTextWithSaltBytes.ToArray());
        }

        public static string GetHash(HashAlgorithm hashAlgorithm, ReadOnlySpan<byte> input)
        {
            var size = hashAlgorithm.HashSize / 8;
            Span<byte> destination = stackalloc byte[size];
            hashAlgorithm.TryComputeHash(input, destination, out var bytesWritten);

            if (bytesWritten != size)
                throw new OverflowException();

            Span<char> stringBuffer = stackalloc char[hashAlgorithm.HashSize / 4];
            for (var i = 0; i < destination.Length; i++)
                destination[i].TryFormat(stringBuffer[(2 * i)..], out _, "x2");
            return new string(stringBuffer);
        }
    }
}
