using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    interface IFicha
    {
        Inventario inventario { get; set; }

        string Nome { get; set; }
        string Classe { get; set; }
        string Raca { get; set; }

        int Idade { get; set; }
        int HP { get; set; }
        int EP { get; set; }

        int Ataque { get; set; }
        int Defesa { get; set; }
        int Mobilidade { get; set; }
    }
}
