using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; } = new List<Pessoa>();
        public Suite Suite { get; private set; }
        public int DiasReservados { get; private set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            if (diasReservados <= 0)
                throw new ArgumentOutOfRangeException(nameof(diasReservados), "Dias reservados deve ser maior que zero.");

            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
                throw new ArgumentNullException(nameof(hospedes), "A lista de hóspedes não pode ser nula.");

            if (Suite == null)
                throw new InvalidOperationException("Cadastre uma suíte antes de cadastrar hóspedes.");

            if (hospedes.Count == 0)
                throw new ArgumentException("A reserva deve possuir pelo menos um hóspede.", nameof(hospedes));

            // Verifica capacidade
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException(
                    $"Capacidade insuficiente: a suíte comporta {Suite.Capacidade} " +
                    $"e foram informados {hospedes.Count} hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite ?? throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("Não é possível calcular diária sem uma suíte cadastrada.");

            if (DiasReservados <= 0)
                throw new InvalidOperationException("Dias reservados deve ser maior que zero para calcular a diária.");

            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Desconto de 10% para 10 dias ou mais
            if (DiasReservados >= 10)
            {
                valor *= 0.90m;
            }

            return valor;
        }
    }
}