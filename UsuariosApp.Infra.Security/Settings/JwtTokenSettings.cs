using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Infra.Security.Settings
{
    public class JwtTokenSettings
    {
        public static string SecretKey = "11BCADA3-E18D-4925-B37E-3834DF773079";

        public static int ExpirationInHours = 1;
    }
}
