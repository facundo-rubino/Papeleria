using System;
using System.Security.Cryptography;

namespace AppLogic.HashPass
{
    // Clase estática para realizar operaciones de hash en contraseñas
    public static class PasswordHasher
    {
        // Constantes configurables dependiendo de los requisitos de seguridad
        private const int SaltSize = 16; // Tamaño en bytes del salt
        private const int KeySize = 32; // Tamaño en bytes del hash
        private const int Iterations = 10000; // Número de iteraciones

        // Método para hashear una contraseña
        public static string HashPassword(string password)
        {
            // Usando Rfc2898DeriveBytes para generar el hash con un salt aleatorio
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                string key = Convert.ToBase64String(algorithm.GetBytes(KeySize)); // La clave hasheada
                string salt = Convert.ToBase64String(algorithm.Salt); // El salt usado

                // Retornar el resultado como una cadena de texto con el formato "iteraciones.salt.hash"
                return $"{Iterations}.{salt}.{key}";
            }
        }

        // Método para verificar una contraseña contra un hash
        public static bool VerifyPassword(string hash, string password)
        {
            var parts = hash.Split('.', 3); // Dividir el hash en sus partes

            if (parts.Length != 3)
            {
                throw new FormatException("Formato de hash inesperado. Debe estar en el formato `{iteraciones}.{salt}.{hash}`");
            }

            var iterations = Convert.ToInt32(parts[0]); // Número de iteraciones usadas para crear el hash
            var salt = Convert.FromBase64String(parts[1]); // El salt usado
            var key = Convert.FromBase64String(parts[2]); // El hash de la contraseña

            // Rehash la contraseña proporcionada usando el mismo salt y número de iteraciones
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize); // El hash de la contraseña proporcionada
                // Comparar el hash calculado con el hash almacenado para verificar si son iguales
                return keyToCheck.SequenceEqual(key);
            }
        }
    }
}

