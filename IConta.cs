using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIOBanck.Classes
{
    interface IConta<T>
    {
        List<T> ListaContas();
        void Insere(T entidadeConta);
        void Atualiza(int numconta, T entidade);
        T RetornaporNumeroConta(int numconta);
        public int ProximoId();
    }
}
