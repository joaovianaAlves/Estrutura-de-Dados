using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDuplaObjeto
{
    class ListaDupla
    {
        public ListaDupla()   // Construtor
        {
            info = 0;
            next = prior = null;
        }

        public void Insere(int n, ref ListaDupla START, ref ListaDupla END)
        {
            this.info = n;
            if (START == null)
                START = END = this;
            else
            {
                END.next = this;
                this.prior = END;
                END = this;
            }
        }

        public void listarDoComeco()
        {
                ListaDupla ld = this;
                int c = 1;
                Console.WriteLine($"Item {c} da lista," + $" Valor:{ld.info}");
                
                while (ld.next != null){
                    c++;
                    ld = ld.next;
                    Console.WriteLine($"Item {c} da lista," + $" Valor:{ld.info}");
                } 
        }
        public void listarDoFinal()
        {
                ListaDupla ld = this;
                int c = 1;
                Console.WriteLine($"Item {c} da lista" + $" Valor:{ld.info}");

            while (ld.prior != null){
                    c++;
                    ld = ld.prior;
                    Console.WriteLine($"Item {c} da lista" + $" Valor:{ld.info}");
                }
        }
    

        public ListaDupla Pesquisar(int n)
        {
            Console.WriteLine("Pesquisando item solicitado...");
            ListaDupla ld = this;
            ListaDupla objeto = null;

            while (ld != null)
            {
                if (ld.info == n)
                {
                    objeto = ld;
                }

                ld = ld.next;
            }
            return objeto;
        }

        public void Remover(ref ListaDupla START, ref ListaDupla END)
        {
            if (START == END)
                START = END = null;
            else
                if (START == this)
            {
                (this.next).prior = null;
                START = this.next;
            }
            else
                    if (END == this)
            {
                (this.prior).next = null;
                END = this.prior;
            }
            else
            {
                (this.prior).next = this.next;
                (this.next).prior = this.prior;
            }
            Console.WriteLine("Item Removido com sucesso");
        }

        private int info;
        ListaDupla next;
        ListaDupla prior;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaDupla START = null;
            ListaDupla END = null;
            ListaDupla ld;
            int n, escolha, resultado;

            do
            {
                Console.Clear();
                Console.WriteLine(" Menu Principal");
                Console.WriteLine("(1) - Insere um elemento na Lista Dupla");
                Console.WriteLine("(2) - Deletar um elemento na Lista Dupla");
                Console.WriteLine("(3) - Imprimir na tela todos os elemendo da Lista dupla comecando pelo primeiro");
                Console.WriteLine("(4) - Imprimir na tela todos os elemendo da Lista dupla comecando pelo ultimo");
                Console.WriteLine("(5) - Para SAIR");
                escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1: // Insere um elemento na Lista Dupla
                        Console.Clear();
                        ld = new ListaDupla();
                        Console.Write("Entre com um numero : ");
                        n = int.Parse(Console.ReadLine());
                        ld.Insere(n, ref START, ref END);
                        Console.WriteLine("Numero inserido com sucesso");
                        Console.WriteLine("Pressione Enter para continuar");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Entre com um numero para Pesquisa: ");
                        n = int.Parse(Console.ReadLine());
                        if (START == null)
                        {
                            Console.WriteLine("Item não achado");
                        }
                        else
                        {
                            ld = START.Pesquisar(n);
                            if (ld != null) 
                                ld.Remover(ref START, ref END);
                            else
                                Console.WriteLine("Item não achado");
                        }
                        Console.WriteLine("Pressione Enter para continuar");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        if (START == null)
                        {
                            Console.WriteLine("Lista Vazia");
                        }
                        else
                        {
                            START.listarDoComeco();
                        }
                        Console.WriteLine("Pressione Enter para continuar");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        if (END == null)
                        {
                            Console.WriteLine("Lista Vazia");
                        }
                        else
                        {
                            END.listarDoFinal();
                        }
                        Console.WriteLine("Pressione Enter para continuar");
                        Console.ReadKey();
                        break;
                }

            } while (escolha != 7);

        }
    }
}
