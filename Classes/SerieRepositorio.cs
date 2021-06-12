using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : iRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public List<Serie> lista(){
            return listaSerie;
        }    

        public void insere(Serie objeto){
            listaSerie.Add(objeto);
        }

        public void exclui(int id){
            listaSerie[id].indisponivel();
        }

        public void atualiza(int id, Serie objeto){
            listaSerie[id] = objeto;
        }

        public int proximoId(){
            return listaSerie.Count;
        }

        public Serie retornaPorId(int id){
            return listaSerie[id];
        } 

    }
}