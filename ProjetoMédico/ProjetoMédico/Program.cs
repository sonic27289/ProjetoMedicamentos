using System;

namespace ProjetoMédico
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sair = false;
            int opcao;
            Medicamentos lista = new Medicamentos();
            string escolha;

            while (!sair)
            {
                Console.WriteLine(" 0. Finalizar processo \n 1. Cadastrar medicamento \n 2. Consultar medicamento (sintético) \n 3. Consultar medicamento (analítico) \n 4. Comprar medicamento \n 5. Vender medicamento \n 6. Listar medicamentos \n");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        sair = true;
                        break;
                    case 1:
                        cadastrarMedicamento();
                        break;
                    case 2:
                        consultarMedicamentoSintetico();
                        break;
                    case 3:
                        consultarMedicamentoAnalitico();
                        break;
                    case 4:
                        comprarMedicamento();
                        break;
                    case 5:
                        venderMedicamento();
                        break;
                    case 6:
                        listarMedicamentos();
                        break;
                    default:
                        Console.WriteLine("Digite uma opção válida !");
                        break;
                }
            }
            void cadastrarMedicamento()
            {
                int id;
                string nome, laboratorio, escolha;

                do
                {
                    Console.WriteLine("Digite o ID do Medicamento: ");
                    escolha = Console.ReadLine();
                } while (!Int32.TryParse(escolha, out id));

                Console.WriteLine("Digite o Nome do Medicamento: ");
                nome = Console.ReadLine();
                Console.WriteLine("Digite o Nome do Laboratório: ");
                laboratorio = Console.ReadLine();

                Medicamento medicamento = new Medicamento(id, nome, laboratorio);
                lista.addMedicamento(medicamento);
                Console.WriteLine("Medicamento registrado com sucesso! ");
            }
            void consultarMedicamentoSintetico()
            {
                int id;
                string escolha;

                do
                {
                    Console.WriteLine("Digite o ID do Medicamento: ");
                    escolha = Console.ReadLine();
                } while (!Int32.TryParse(escolha, out id));

                Medicamento medicamentopr = new Medicamento(id, "", "");
                Medicamento medicamentoen = lista.Pesquisar(medicamentopr);

                if (medicamentoen.Id == 0)
                {
                    Console.WriteLine("Não foi possível localizar o Medicamento.");
                }
                else
                {
                    Console.WriteLine("Medicamento: " + medicamentoen.ToString());
                }
            }
            void consultarMedicamentoAnalitico()
            {
                int id;
                string escolha;

                do
                {
                    Console.WriteLine("Digite o ID do Medicamento: ");
                    escolha = Console.ReadLine();
                } while (!Int32.TryParse(escolha, out id));

                Medicamento medicamentopr = new Medicamento(id, "", "");
                Medicamento medicamentoen = lista.Pesquisar(medicamentopr);

                if (medicamentoen.Id == 0)
                {
                    Console.WriteLine("Não foi possível localizar o Medicamento.");
                }
                else
                {
                    Console.WriteLine("Medicamento: " + medicamentoen.ToString());
                    Console.WriteLine("Lotes disponíveis: ");
                    foreach (Lote l in medicamentoen.Lotes)
                    {
                        Console.WriteLine(l.ToString());
                    }
                }
            }
            void comprarMedicamento()
            {
                int id, id2, qtde, dia, mes, ano;
                DateTime venc;

                do
                {
                    Console.WriteLine("Digite o ID do Medicamento que deseja comprar um lote: ");
                    escolha = Console.ReadLine();
                } while (!Int32.TryParse(escolha, out id2));

                Medicamento medicamentopr = new Medicamento(id2, "", "");
                Medicamento medicamentoen = lista.Pesquisar(medicamentopr);

                if (medicamentoen.Id == 0)
                {
                    Console.WriteLine("Não foi possível localizar o Medicamento.");
                }
                else
                {
                    Console.WriteLine("Medicamento: " + medicamentoen.ToString());

                    do
                    {
                        Console.WriteLine("Digite o ID do Lote: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out id));

                    do
                    {
                        Console.WriteLine("Digite a quantidade de medicamentos que estão no Lote: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out qtde));

                    do
                    {
                        Console.WriteLine("Digite o dia de vencimento: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out dia) || dia > 31);

                    do
                    {
                        Console.WriteLine("Digite o mês de vencimento: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out mes) || mes > 12);

                    do
                    {
                        Console.WriteLine("Digite o ano de vencimento: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out ano) || ano < 2021);

                    venc = new DateTime(ano, mes, dia);
                    Lote lote = new Lote(id, qtde, venc);

                    int achado = lista.ListaMedicamentos.FindIndex(x => x == medicamentoen);
                    lista.ListaMedicamentos[achado].Comprar(lote);
                    Console.WriteLine("Lote registrado !");
                }
            }
            void venderMedicamento()
            {
                int id, qtde;

                do
                {
                    Console.WriteLine("Digite o ID do Medicamento: ");
                    escolha = Console.ReadLine();
                } while (!Int32.TryParse(escolha, out id));

                Medicamento medicamentopr = new Medicamento(id, "", "");
                Medicamento medicamentoen = lista.Pesquisar(medicamentopr);

                if (medicamentoen.Id == 0)
                {
                    Console.WriteLine("Não foi possível localizar o Medicamento.");
                }
                else
                {
                    Console.WriteLine("Medicamento: " + medicamentoen.ToString());

                    do
                    {
                        Console.WriteLine("Digite a quantidade que será vendida: ");
                        escolha = Console.ReadLine();
                    } while (!Int32.TryParse(escolha, out qtde) || id < 0);

                    int achado = lista.ListaMedicamentos.FindIndex(x => x == medicamentoen);
                    Console.WriteLine(lista.ListaMedicamentos[achado].Vender(qtde) ? "Venda efetuada." : "Venda não foi efetuada.   ");

                }
            }
            void listarMedicamentos()
            {
                Console.WriteLine("Listagem de todos os Medicamentos: ");
                foreach (Medicamento m in lista.ListaMedicamentos)
                {
                    Console.WriteLine(m.ToString());
                }
            }
        }
    }
}
