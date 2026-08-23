using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ValidadorDeIntegridad
    {

        

        public int CalcularDV(IVerificable objeto)
        {
            int total = 0;
            int[] campos = objeto.ObtenerCamposParaDV();

            foreach (int valor in campos)
                total += valor;

            return total % 10;
        }


        

        public int CalcularDVV(List<IVerificable> objetos)
        {
            int suma = 0;
            foreach (var obj in objetos)
                suma += CalcularDV(obj);

            return suma % 10;
        }


      

        public bool VerificarDVHs(List<IVerificable> objetos, List<int> dvhsGuardados)
        {
            if (objetos.Count != dvhsGuardados.Count)
                return false;

            for (int i = 0; i < objetos.Count; i++)
            {
                if (CalcularDV(objetos[i]) != dvhsGuardados[i])
                    return false;
            }

            return true;
        }


        
 
        public bool VerificarIntegridad(List<IVerificable> objetos, List<int> dvhsGuardados, int dvvGuardado)
        {
            if (!VerificarDVHs(objetos, dvhsGuardados))
                return false; 

            if (CalcularDVV(objetos) != dvvGuardado)
                return false; 

            return true; 
        }
    }
}
