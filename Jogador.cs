using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    public class Jogador : IFicha
    {
        public string Lore { get; set; }
        public string Nome { get; set; }

        public string Classe { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public int HP { get; set; } // Pontos de Vida do Jogador;
        public int EP { get; set; } // Pontos de Energia do Jogador (Quantos movimentos ele tem)  Calculo = Defesa + Mobilidade / 2;

        public int Ataque { get; set; } // Dano Causado pelo jogador;
        public int Defesa { get; set; } // Dano Rejeitado pelo jogador;
        public int Mobilidade { get; set; } // Capacidade do jogador de aceitar o golpe + facilmente; Calculo = RolarDado(Dado) + Mobilidade SE EP && HP >= 1; 

        public Inventario inventario{ get; set; }

        private static Jogador _instanciaJogador;

        private Jogador() { }

        public static Jogador GetInstancia()
        {
            if (_instanciaJogador == null)
            {
                _instanciaJogador = new Jogador();
            }
            return _instanciaJogador;
        }


        public void CriarPersonagem()
        {
            Console.WriteLine("Qual o nome de seu personagem?\n");
            Nome = Convert.ToString(Console.ReadLine());

            Console.WriteLine("\nQual a idade de seu personagem?\n");
            Idade = Convert.ToInt32(Console.ReadLine());

            inicioRaca:

            Console.WriteLine("\nSelecione a Raça de seu personagem:\n[1] Humano\n[2] Elfo\n[3] Orc\n");
            int escolhaRaca = Convert.ToInt32(Console.ReadLine());

            switch (escolhaRaca)
            {
                case 1:

                    Raca = "Humano";
                    Ataque = 10;
                    Defesa = 8;
                    Mobilidade = 6;

                    HP = 80;
                    EP = Defesa + Mobilidade * 2;

                    Console.WriteLine($"               -------------------------------               \n" +
                        $"\nSeu Ataque inicial é {Ataque}\nSua Defesa inicial é {Defesa}\nSua Mobilidade inicial é {Mobilidade}\n\n");
                    Console.WriteLine($"Sua vida inicial é {HP}\nSua energia inicial é {EP}\n\n" +
                                        $"               -------------------------------               \n");
                    break;

                case 2:
                    Raca = "Elfo";
                    Ataque = 8;
                    Defesa = 8;
                    Mobilidade = 12;

                    HP = 60;
                    EP = Defesa + Mobilidade * 2;

                    Console.WriteLine($"               -------------------------------               \n" +
                        $"\nSeu Ataque inicial é {Ataque}\nSua Defesa inicial é {Defesa}\nSua Mobilidade inicial é {Mobilidade}\n\n");
                    Console.WriteLine($"Sua vida inicial é {HP}\nSua energia inicial é {EP}\n\n" +
                                        $"               -------------------------------               \n");
                    break;

                case 3:
                    Raca = "Orc";
                    Ataque = 12;
                    Defesa = 12;
                    Mobilidade = 4;

                    HP = 100;
                    EP = Defesa + Mobilidade * 2;

                    Console.WriteLine($"               -------------------------------               \n" +
                        $"\nSeu Ataque inicial é {Ataque}\nSua Defesa inicial é {Defesa}\nSua Mobilidade inicial é {Mobilidade}\n\n");
                    Console.WriteLine($"Sua vida inicial é {HP}\nSua energia inicial é {EP}\n\n" +
                                        $"               -------------------------------               \n");
                    break;

                default:
                    Console.WriteLine("\nPor favor selecione uma raça valida");
                    goto inicioRaca;
            }

            inicioClasse:

            Inventario inventario = Inventario.GetInstancia();

            Console.WriteLine("\nSelecione a Classe de seu personagem:\n[1] Guerreiro\n[2] Arqueiro\n[3] Barbaro\n");
            int escolhaClasse = Convert.ToInt32(Console.ReadLine());

            switch (escolhaClasse)
            {
                case 1:
                    Classe = "Guerreiro";

                    inventario.ListaArmas.Add("Espada Longa", 8);

                    Console.WriteLine($"\nSeus itens iniciais são:\n");
                    foreach (var item in inventario.ListaArmas)
                    {
                        Console.WriteLine($"\n                -------------------------------               \n" +
                                          $"                Seu item é um {item.Key} com {item.Value} de dano               " +
                                          $"\n                -------------------------------               \n");
                    }
                    break;

                case 2:
                    Classe = "Arqueiro";

                    inventario.ListaArmas.Add("Arco", 6);

                    Console.WriteLine($"\nSeus itens iniciais são:\n");
                    foreach (var item in inventario.ListaArmas)
                    {
                        Console.WriteLine($"\n                -------------------------------               \n" +
                                          $"                Seu item é um {item.Key} com {item.Value} de dano              " +
                                          $"\n                -------------------------------               \n");
                    }
                    break;

                case 3:
                    Classe = "Barbaro";

                    inventario.ListaArmas.Add("Martelo", 12);

                    Console.WriteLine($"\nSeus itens iniciais são:\n");
                    foreach (var item in inventario.ListaArmas)
                    {
                        Console.WriteLine($"\n                -------------------------------               \n" +
                                          $"                Seu item é um {item.Key} com {item.Value} de dano              " +
                                          $"\n                -------------------------------               \n");
                    }
                    break;

                default: 
                    Console.WriteLine("\nSelecione uma clase viável");
                    goto inicioClasse;
            }

            Console.WriteLine("\n\nQual a história breve de seu personagem?\n");
            Lore = Console.ReadLine();
        }
    }
}
