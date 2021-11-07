using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIOBanck.Classes
{
    class RepositoriodeContas : IConta<Conta>
    {
        private List<Conta> listaConta = new List<Conta>();

        public int ContaNumero { get; private set; }

        public void Atualiza(int numconta, Conta entidade)
        {
            listaConta[ContaNumero]=entidade;
        }

        public void Insere(Conta entidadeConta)
        {
            listaConta.Add(entidadeConta);
        }

        public List<Conta> ListaContas()
        {
            return listaConta;
        }

        public int ProximoId()
        {
            return listaConta.Count;
        }

        public Conta RetornaporNumeroConta(int numconta)
        {
            return listaConta[numconta];
        }
        public int RetornaContaNumero()
        {
            return this.ContaNumero;
        }
    }
}
