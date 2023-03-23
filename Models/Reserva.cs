using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes {get; set;}
        public Suite Suite { get; set; }
        public int DiaReservados { get; set; }

        public Reserva () {}

        public Reserva (int diasReservados)
        {
            DiaReservados = diasReservados;
        }

        public void CadastrarHospedes (List<Pessoa> hospedes)
        {
            if (hospedes.Count <= ObterCapacidade()) 
            {
                Hospedes = hospedes;
            }
            else
            {
                 throw new Exception(
                    $"Número de hospedes {hospedes.Count} é maior que a capacidade {ObterCapacidade()} da suite.");
            }
        }

        public void CadastrarSuite (Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes ()
        {
            return Hospedes.Count;
        }

        public int ObterCapacidade ()
        {
            return Suite.Capacidade;
        }

        public decimal ObterValorDiaria()
        {
            return Suite.ValorDiaria;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiaReservados * ObterValorDiaria();
 
            if (DiaReservados >= 10) {
                 valor -= valor * 0.1M;
            }

            return valor;
        }

    }
}