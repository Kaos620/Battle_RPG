using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    internal class Inimigo : IFicha
    {
        public Inventario inventario { get ; set ; }

        public string Nome { get ; set ; }
        public string Classe { get ; set ; }
        public string Raca { get ; set ; }
        public int Idade { get ; set ; }
        public int HP { get ; set ; }
        public int EP { get ; set ; }
        public int Ataque { get ; set ; }
        public int Defesa { get ; set ; }
        public int Mobilidade { get ; set ; }


        private static Inimigo _instanciaInimigo;

        private Inimigo() { }

        public static Inimigo GetInstancia()
        {
            if (_instanciaInimigo == null)
            {
                _instanciaInimigo = new Inimigo();
            }
            return _instanciaInimigo;
        }


        public void CriarInimigo()
        {
            Inventario inventario = Inventario.GetInstancia();

            Nome = "Arnaldo - O Destuidor";
            Idade = 23;
            HP = 110;
            EP = 10;

            Ataque = 23;
            Defesa = 12;
            Mobilidade = 6;
        }
    }
}
