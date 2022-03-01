using System;
using System.Collections.Generic;
using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Modulo2CSKeyVault.keyvault
{
    /*Esta clase es usada para conectarnos al 
     * Azure AD y al Azure Key Vault Secrets
     */
    class KeyClient
    {
        /*appid, tenantid, secret client: se extraen del Azure AD app registration*/
        private static readonly string APPID = "0ec40e11-8011-4270-93fa-07c6bee5b149";
        private static readonly string TENANTID = "8f801786-dcd2-4f6b-b81e-f961ea9a9e20";
        private static readonly string SECRETCLIENT = "f0E7Q~A52CmQ6RGvH-lc9Tx9EOX0ZW8QRCJob";
        /*keyvault: Se extrae del overview del servicio key vault*/
        private static readonly string KEYVAULT = "https://vaultenvf.vault.azure.net/";

        /*Secret: Es una variable que puedo obtener su valor
         en cualquier parte del código, pero no puedo modicarla fuera de este archivo (clase)*/
        public static SecretClient Secret { get; private set; }

        /*Constructor: Nos ayuda a inicializar (Construir) un servicio (Objeto)*/
        static KeyClient() { Init();  }

        /*Este método es usado para iniciar la conexión a nuestro KeyVault*/
        private static void Init() {
            if (Secret==null) {
                var credencial = new ClientSecretCredential(TENANTID, APPID, SECRETCLIENT);
                Secret = new SecretClient(new Uri(KEYVAULT), credencial);
            }
        
        }

    }
}
