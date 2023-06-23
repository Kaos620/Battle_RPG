using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    public class Inventario
    {
        // <Nome Arma, Dano Arma>
        public Dictionary<string, int> ListaArmas = new Dictionary<string, int>();

        private static Inventario _instanciaInventario;

        private Inventario() { }

        public static Inventario GetInstancia()
        {
            if (_instanciaInventario == null)
            {
                _instanciaInventario = new Inventario();
            }
            return _instanciaInventario;
        }

        public void ProcurarItem()
        {
            Console.WriteLine("Qual item você gostaria de procurar?");
            string itemProcura = Console.ReadLine();

            foreach (var item in ListaArmas)
            {
                if (ListaArmas.ContainsKey(itemProcura) == true)
                {
                    Console.WriteLine("Item achado!");
                }
                else
                {
                    Console.WriteLine("Item não existe");
                }
            }
        }
    }
}
