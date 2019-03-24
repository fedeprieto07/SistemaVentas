using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ArquitecturaBase
{
    public class Seguridad
    {

        public string encriptar(string password) {
            string passencript = Eramake.eCryptography.Encrypt(password);

            return passencript;

        }
    }
}
