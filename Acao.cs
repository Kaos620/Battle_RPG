using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    public class Acao /*: Jogo*/
    {
        private int Atacar;
        private int Defender;
        private int Curar;
        private bool Correr;
        private bool Desistir;
        private int Dado;

        Jogador jogador = Jogador.GetInstancia();
        Inimigo inimigo = Inimigo.GetInstancia();
        Inventario inventario = Inventario.GetInstancia();


        public int UsarAtaque()
        {
            int Dado = RolarDado();
            int Dano = 0;
            int danoArma = 0;

            if (jogador.Classe == "Guerreiro")
            {
                danoArma = inventario.ListaArmas["Espada Longa"];
            } 
            
            else if (jogador.Classe == "Arqueiro")
            {
                danoArma = inventario.ListaArmas["Arco"];
            }
            
            else if (jogador.Classe == "Barbaro")
            {
                danoArma = inventario.ListaArmas["Martelo"];
            }

            if (Dado >= 13 && jogador.EP >= 1)
            {
                Dano = jogador.Ataque + danoArma;

                inimigo.HP = (inimigo.HP - Dano) + inimigo.Defesa;

                jogador.EP--;

                Console.WriteLine($"\n\nO inimigo tomou um dano de {Dano}. O inimigo está com {inimigo.HP} de vida...\n");
            }
            else if (Dado < 13)
            {
                Console.WriteLine("\nVocê falhou em acertar o ataque, tente novamente no proximo turno\n");
            }

            Console.WriteLine("\nFim de turno\n");
            return Dano;
        }

        public int inimigoAtacar()
        {
            Dado = RolarDado();
            int Dano = 0;

            if (Dado >= 13 && inimigo.EP >= 1)
            {
                Random random = new Random();
                int num = random.Next(1, 30);

                Dano = inimigo.Ataque + num;

                jogador.HP = (jogador.HP - Dano) + jogador.Defesa;

                inimigo.EP--;

                Console.WriteLine($"\n\nO inimigo te acertou! Você tomou um dano de {Dano}.\nVocê está com {jogador.HP} de vida...\n\n");
            }
            else if (Dado < 13)
            {
                Console.WriteLine("\n\nO inimigo errou!\n\n");
            }

            Console.WriteLine("\nFim de turno\n");
            return Dano;

        }

        public bool UsarDesistir()
        { 

            bool Desistir = true;
            jogador.HP = 0;
            //GameOver();

            return Desistir;
        }

        public int RolarDado()
        {
            Random random = new Random();

            Console.WriteLine("\n\n             Rolando Dado...\n");

            int Dado = random.Next(1, 20) + jogador.Mobilidade;

            Console.WriteLine($"O resultado é: {Dado}");

            return Dado;
        }
    }
}
