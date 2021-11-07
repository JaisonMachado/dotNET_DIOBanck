using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIOBanck.Enums;

namespace DIOBanck.Classes
{
    class Conta : EBase
    {


        private string NomeCliente { get; set; }
        private double Saldo { get; set; }
        private double Limite { get; set; }
        private string Lancamentos { get; set; }
        private ContaTipo ContaTipo { get; set; }

        public Conta(int contanumero, string nomecliente, double limite, string lancamentos,
                       ContaTipo contaTipo, double saldoConta)
        {
            this.NomeCliente = nomecliente;
            this.Saldo = saldoConta;
            this.Limite = limite;
            this.Lancamentos = "Abertura da conta";
            this.ContaNumero = contanumero;
            this.ContaTipo = contaTipo;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Conta: " + this.ContaNumero + Environment.NewLine;
            retorno += "Cliente: " + this.NomeCliente + Environment.NewLine;
            retorno += "Saldo: " + this.Saldo + Environment.NewLine;
            retorno += "Limite: " + this.Limite + Environment.NewLine;
            retorno += "Ultimos lancamentos: " + Environment.NewLine + this.Lancamentos;

            return retorno;
        }
        public int retornaContaNumero()
        {
            return this.ContaNumero;
        }
        public double retornaSaldo()
        {
            return this.Saldo;
        }
        public double retornaLimite()
        {
            return this.Limite;
        }
        public string retornaLancamentos()
        {
            return this.Lancamentos;
        }
        public string retornaCliente()
        {
            return this.NomeCliente;
        }
        public ContaTipo retornaTipo()
        {
            return this.ContaTipo;
        }
        public bool Sacar(double valorSaque)

        {
            // Validação de saldo suficiente

            if (this.Saldo - valorSaque < (this.Limite * -1))
            {

                Console.WriteLine("Saldo insuficiente!");

                return false;

            }

            this.Saldo -= valorSaque;
            this.Lancamentos += Environment.NewLine + " Saque: " + valorSaque.ToString();

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.NomeCliente, this.Saldo);
            return true;
        }
        public bool Depositar (double valorDeposito)

        {
            double saldo = this.Saldo;         
            this.Saldo += valorDeposito;
            if ((saldo + valorDeposito)==this.Saldo) 
            { 
                this.Lancamentos += Environment.NewLine + "Deposito  " + valorDeposito.ToString();
                return true; 
            }
            else { return false; }

        }

    }
}