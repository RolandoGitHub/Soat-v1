using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaTec.SisPol.Infraestructure.Enums
{
    public sealed class TipoEstadoRegistro
    {
        public const string Activo = "1";
        public const string Inactivo = "0";
    }

    public sealed class Parametro
    {
        public const int Estado = 1;
        public const int Sexo = 2;
        public const int TipoPoliza = 3;
        public const int Moneda = 4;
    }
}
