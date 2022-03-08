using System;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            public int ISBN { get; set; }
            public string Title { get; set; }
            public int Year { get; set; }
            public Book Previous { get; set; }
            public Book(int iSBN, string title, int year)
            {
                ISBN = iSBN;
                Title = title;
                Year = year;
                Previous = null;
            }
            public override string ToString()
            {
                return $"==========  DADOS DO LIVRO ==========\nISBN: {ISBN}\t\t\nTitulo: {Title}\t\t\nPublicacao: {Year}\t";
            }
        }
    }
        internal class BookStack
        {
            public Book Top { get; set; }
            static int BookCount = 0;
            public BookStack()
            {
                Top = null;
            }
            public void Push()
            {
                Console.WriteLine("-- DIGITE OS DADOS DO LIVRO --");
                Console.Write("ISBN: ");
                int iSBN = int.Parse(Console.ReadLine());
                if (isBookOnStack(iSBN))
                {
                    Console.WriteLine("Já existe um livro com esse ISBN!!");
                }
                else
                {
                    Console.Write("Titulo: ");
                    string title = Console.ReadLine();
                    Console.Write("Ano de Publicacao: ");
                    int year = int.Parse(Console.ReadLine());
                    Book aux = new Book(iSBN, title, year);
                    aux.Previous = Top;
                    Top = aux;
                    Console.WriteLine($"\nLivro adicionado {Top.Title}!!");
                    BookCount++;
                }
            }
            private bool isBookOnStack(int iSBN)
            {
                Book aux = Top;
                bool isBookOnStack = false;
                do
                {
                    if (aux.ISBN == iSBN)
                    {
                        isBookOnStack = true;
                    }
                    else
                    {
                        aux = aux.Previous;
                    }
                } while (aux != null && isBookOnStack == false);
                return isBookOnStack;
            }
            public void Pop()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("=> A PILHA ESTA VAZIA");
                }
                else
                {
                    Console.WriteLine($"=> {Top.Title} foi removido");
                    Top = Top.Previous;
                    BookCount--;
                    Console.WriteLine($"\tAgora a pilha tem {GetBookCount()} livros");
                }
            }
            public void Print()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("--- PILHA VAZIA! ---");
                }
                else
                {
                    Console.WriteLine("--- ELEMENTOS DA PILHA ---");
                    Book aux = Top;
                    do
                    {
                        Console.WriteLine(aux);
                        aux = aux.Previous;
                    } while (aux != null);
                    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=");
                }
            }
            //Search by Title
            public Book GetBook(string bookSearch)
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Book book = Top;
                bool bookFound = false;
                do
                {
                    if (book.Title.Equals(bookSearch))
                    {
                        bookFound = true;
                    }
                    else
                    {
                        book = book.Previous;
                    }
                } while (book != null && bookFound == false);
                if (bookFound)
                {
                    Console.WriteLine($"O livro de Titulo {book.Title} foi encontrado!");
                }
                else
                {
                    Console.WriteLine($"O livro {bookSearch} não foi encontrado na pilha!");
                }
                return book;
            }
            //Search by ISBN
            public Book GetBook(int bookSearch)
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Book book = Top;
                bool bookFound = false;
                do
                {
                    if (book.ISBN == bookSearch)
                    {
                        bookFound = true;
                    }
                    else
                    {
                        book = book.Previous;
                    }
                } while (book != null && bookFound == false);
                if (bookFound)
                {
                    Console.WriteLine($"O livro de Titulo {book.Title} foi encontrado!");
                }
                else
                {
                    Console.WriteLine($"O livro {bookSearch} não foi encontrado na pilha!");
                }
                return book;
            }
            public bool IsEmpty()
            {
                return Top == null;
            }
            public int GetBookCount()
            {
                return BookCount;
            }
        }
                BookStack pilha = new BookStack();
                int opt = 6;
                while (opt != 0)
                {
                    Console.Clear();
                    Console.WriteLine("------- MENU -------\n 1. Inserir livro\n2. Remover livro\n3. Imprimir todos os livros na pilha\n4. Quantidade de livros na pilha\n5. Buscar livro por ISBN ou Titulo\n0. Sair\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.Write("->Opção: ");
                    opt = int.Parse(Console.ReadLine());
                    Console.Write("-=-=-=-=-=-=-=-=-=-=-=-=-");
                    Console.Clear();
                    switch (opt)
                    {
                        // --- INSERÇAO ---
                        case 1:
                            pilha.Push();
                            backToMenuMessage();
                            break;
                        // --- REMOÇAO ---
                        case 2:
                            pilha.Pop();
                            backToMenuMessage();
                            break;
                        // --- SELEÇAO ---
                        case 3:
                            pilha.Print();
                            backToMenuMessage();
                            break;
                        // --- CONTAGEM DE ITENS ---
                        case 4:
                            Console.WriteLine($"\n=> A pilha tem {pilha.GetBookCount()} livros!");
                            backToMenuMessage();
                            break;
                        // --- SELEÇAO ESPECIFICA ---
                        case 5:
                            if (!pilha.IsEmpty())
                            {
                                char choice;
                                Console.WriteLine("Deseja procurar por Titulo ou ISBN?");
                                Console.Write("(T - Titulo / I - ISBN)=>");
                                choice = char.ToLower(char.Parse(Console.ReadLine()));
                                if (choice == 't')
                                {
                                    Console.Write("Nome do Titulo: ");
                                    string search = Console.ReadLine();
                                    Console.WriteLine(pilha.GetBook(search));
                                    backToMenuMessage();
                                }
                                else
                                {
                                    Console.Write("Nome do ISBN: ");
                                    int search = int.Parse(Console.ReadLine());
                                    Console.WriteLine(pilha.GetBook(search));
                                    backToMenuMessage();
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Digite uma das opcoes do menu");
                            break;
                    }
                }
            }
            static void backToMenuMessage()
            {
                Console.WriteLine("\nPressione qualquer coisa para volar para o menu...");
                Console.ReadKey();
                Console.Clear();
            }
}
   















}
    }
}
