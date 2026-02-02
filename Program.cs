using System.Text;
using System.Globalization;
using System.Linq;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
// Cultura padrão pt-BR (aceita vírgula como separador decimal)
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

// Estado da aplicação
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = null;     // nullable desabilitado no .csproj
Reserva reserva = null; // idem

while (true)
{
    Console.Clear();
    Console.WriteLine("=======================================");
    Console.WriteLine("      Sistema de Reservas (Console)    ");
    Console.WriteLine("=======================================\n");
    Console.WriteLine("[1] Cadastrar suíte");
    Console.WriteLine("[2] Cadastrar hóspedes");
    Console.WriteLine("[3] Criar/atualizar reserva");
    Console.WriteLine("[4] Mostrar resumo");
    Console.WriteLine("[5] Mostrar quantidade de hóspedes");
    Console.WriteLine("[6] Calcular valor da diária");
    Console.WriteLine("[0] Sair");
    Console.Write("\nEscolha uma opção: ");
    var opc = Console.ReadLine();

    try
    {
        switch (opc)
        {
            case "1": // Cadastrar suíte
            {
                string tipo = ConsoleUtils.ReadNonEmpty("Tipo da suíte: ");
                int capacidade = ConsoleUtils.ReadInt("Capacidade (nº de hóspedes): ", min: 1);
                decimal valor = ConsoleUtils.ReadDecimal("Valor da diária (ex.: 199,90): ", min: 0.01m);

                suite = new Suite { TipoSuite = tipo, Capacidade = capacidade, ValorDiaria = valor };

                Console.WriteLine("\n✅ Suíte cadastrada!");
                Console.WriteLine($"Tipo: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor: {suite.ValorDiaria:C}");
                ConsoleUtils.Pause();
                break;
            }

            case "2": // Cadastrar hóspedes
            {
                int qtd = ConsoleUtils.ReadInt("Quantos hóspedes deseja cadastrar? ", min: 1);
                hospedes.Clear();

                for (int i = 1; i <= qtd; i++)
                {
                    Console.WriteLine($"\nHóspede {i}:");
                    string nome = ConsoleUtils.ReadNonEmpty("Nome: ");
                    string sobrenome = ConsoleUtils.ReadOptional("Sobrenome (opcional): ");
                    hospedes.Add(new Pessoa { Nome = nome, Sobrenome = sobrenome });
                }

                Console.WriteLine("\n✅ Hóspedes cadastrados na lista local.");
                if (suite != null)
                    Console.WriteLine($"(Dica: sua suíte comporta {suite.Capacidade}. Você informou {hospedes.Count}.)");

                ConsoleUtils.Pause();
                break;
            }

            case "3": // Criar/atualizar reserva
            {
                int dias = ConsoleUtils.ReadInt("Dias reservados: ", min: 1);
                reserva = new Reserva(dias);

                if (suite == null)
                    throw new InvalidOperationException("Cadastre uma suíte primeiro (opção 1).");

                if (hospedes.Count == 0)
                    throw new InvalidOperationException("Cadastre os hóspedes (opção 2).");

                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);

                Console.WriteLine("\n✅ Reserva criada/atualizada com sucesso!");
                ConsoleUtils.Pause();
                break;
            }

            case "4": // Resumo
            {
                Console.WriteLine();

                if (suite == null)
                    Console.WriteLine("Suíte: (não cadastrada)");
                else
                    Console.WriteLine($"Suíte: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor diária: {suite.ValorDiaria:C}");

                Console.WriteLine($"Hóspedes adicionados: {hospedes.Count}");
                if (hospedes.Count > 0)
                {
                    var nomes = hospedes.Select(h =>
                        string.IsNullOrWhiteSpace(h.Sobrenome) ? h.Nome : $"{h.Nome} {h.Sobrenome}");
                    Console.WriteLine($"- {string.Join(", ", nomes)}");
                }

                if (reserva == null)
                    Console.WriteLine("Reserva: (não criada)");
                else
                {
                    Console.WriteLine($"Reserva: {reserva.DiasReservados} dia(s), {reserva.ObterQuantidadeHospedes()} hóspede(s).");
                    Console.WriteLine($"Valor total: {reserva.CalcularValorDiaria():C}");
                }

                ConsoleUtils.Pause();
                break;
            }

            case "5": // Quantidade de hóspedes
            {
                Console.WriteLine();
                if (reserva != null)
                    Console.WriteLine($"Quantidade de hóspedes na reserva: {reserva.ObterQuantidadeHospedes()}");
                else
                    Console.WriteLine($"Quantidade de hóspedes na lista atual: {hospedes.Count}");
                ConsoleUtils.Pause();
                break;
            }

            case "6": // Calcular valor diária
            {
                Console.WriteLine();
                if (reserva == null)
                    Console.WriteLine("Crie a reserva antes (opção 3).");
                else
                    Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria():C}");
                ConsoleUtils.Pause();
                break;
            }

            case "0":
            {
                Console.WriteLine("\nAté mais! 👋");
                return;
            }

            default:
            {
                Console.WriteLine("Opção inválida.");
                ConsoleUtils.Pause();
                break;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\n❌ Erro: {ex.Message}");
        ConsoleUtils.Pause();
    }
}


