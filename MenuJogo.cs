using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    public class MenuJogo
    {
        public void Menu()
        {
            Jogador jogador = Jogador.GetInstancia();
            Inimigo inimigo = Inimigo.GetInstancia();
            Inventario inventario = Inventario.GetInstancia();
            Jogo jogo = new Jogo();

            inimigo.CriarInimigo();

            Console.WriteLine("               -------------------------------               \n" +
                "               Bem Vindo a BATALHA CONTRA ARNALDO!               \n" +
                "               -------------------------------               \n\n" +
                "               Vamos criar seu personagem!              \n\n");

            jogo.Tutorial();
            Thread.Sleep(8000);

            jogador.CriarPersonagem();


            Console.WriteLine("               -------------------------------               " + 
                                "\n               Personagem Criado               \n" +
                                "               Agora vamos a BATALHA!               \n" +
                                "               -------------------------------               \n");

            jogo.Turno();

        }
    }
}
