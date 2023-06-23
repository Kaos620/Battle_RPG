﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Minimundo
{
    public class Jogo
    {

        Jogador jogador = Jogador.GetInstancia();
        Inimigo inimigo = Inimigo.GetInstancia();
        Inventario inventario = Inventario.GetInstancia();
        Acao acao = new Acao();

        public void Decisao()
        {
            Turno:
            Console.WriteLine("\n-------------------------------------------------------\n");
            Console.WriteLine("Qual a sua proxima decisão? \n\n");
            Console.WriteLine("-------------------------------------------------------\n\n\n");
            Console.WriteLine("[1] Atacar\n[2] Desistir\n[3] Ver Minha Ficha\n[4] Ver Meus Status\n\n");

            int decisao = Convert.ToInt32(Console.ReadLine());

            if(decisao == 1)
            {
                acao.UsarAtaque();
            }
            else if(decisao == 2)
            {
                acao.UsarDesistir();
            }
            else if (decisao == 3)
            {
                VerFicha();
                Console.WriteLine("\n\n=============================================\n\n");
                Console.WriteLine("Selecione outra ação: \n");
                Decisao();
            }
            else if (decisao == 4)
            {
                Status();
                Console.WriteLine("\n\n=============================================\n\n");
                Console.WriteLine("Selecione outra ação: \n");
                Decisao();
            }
            else 
            {
                Console.WriteLine("Selecione uma das opções dadas");
                goto Turno;
            }
        }

        //public void DecisaoMaquina()
        //{
        //    Random random = new Random();

        //    Console.WriteLine("Rolando Dado...");

        //    int Decisao = random.Next(1, 20) + jogador.Mobilidade;
        //}
        bool turnoJogador = true;
        public void Turno()
        {

            if/*ou While*/ (jogador.HP > 0 && inimigo.HP > 0)
            {
                if (turnoJogador)
                {
                    Console.WriteLine("\n               Continuar?               \n[1] Sim\n[2] Não\n");
                    int Continuar = Convert.ToInt32(Console.ReadLine());

                    if (Continuar == 1)
                    {
                        Console.WriteLine("\nÉ a vez do jogador...\n\n");
                        Decisao();
                        turnoJogador = false;
                        Turno();
                    }
                    else 
                    { 
                      GameOver(); 
                    }
                }
                else
                {
                    Console.WriteLine("\nÉ a vez da máquina...\n\n");
                    acao.inimigoAtacar();
                    turnoJogador = true;

                    Turno();
                }

                // Alternar o turno
                
            }
            if (jogador.HP <= 0 ||  inimigo.HP <= 0)
            {
                GameOver();
            }
        }


        public void GameOver()
        {
            if (inimigo.HP <= 0)
            {
                Console.WriteLine("O inimigo foi derrotado... Você Venceu!");
                Console.Read();
            }
            else if (jogador.HP <= 0)
            {
                Console.WriteLine("Você Morreu...");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Houve um erro no código... Sinto Muito!");
                Console.Read();
            }
        }

        public void Status()
        {
            Console.WriteLine("-------------------------------------------\n\n");
            Console.WriteLine($"Vida: {jogador.HP}\nPontos de Energia: {jogador.EP}\nForça: {jogador.Ataque}\nDefesa: {jogador.Defesa}\n");
            Console.WriteLine("-------------------------------------------\n\n");

            Decisao();
        }

        public void VerFicha()
        {
            Console.WriteLine("-------------------------------------------\n\n");
            Console.WriteLine($"Nome: {jogador.Nome}\nRaça: {jogador.Raca}\nClasse: {jogador.Classe}\nVida: {jogador.HP}\nDefesa: {jogador.Defesa}\nPontos de Energia: {jogador.EP}\n\n");

            Console.WriteLine($"Sua história: \n{jogador.Lore}\n\n");
            Console.WriteLine("-------------------------------------------\n\n");

            Decisao();
        }

        public void Tutorial()
        {

        }


    }
}