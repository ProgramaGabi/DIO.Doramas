using System;
using System.Collections.Generic;
using DIO.Doramas.Interfaces;



namespace DIO.Doramas
{
    public class DoramasRepositorio : IRepositorio<Doramas>
    {
        private List<Doramas> listaDoramas = new List<Doramas>();        
        public void Atualiza( int id, Doramas objeto)
        {
            listaDoramas[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaDoramas[id].Excluir();
        }

        public void Insere(Doramas objeto)
        {
            listaDoramas.Add(objeto);
        }

        public List<Doramas> Lista()
        {
            return listaDoramas;
        }

        public int ProximoId()
        {
           return listaDoramas.Count;
        }

        public Doramas RetornaPorId(int id)
        {
           return listaDoramas[id];
        }
    }
}