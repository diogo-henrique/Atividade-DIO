using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.IO;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private int id;
        private Genero genero;
        private string titulo;
        private string descricao;
        private int ano;
        private bool excluido;

        private List<Serie> listaSerie = new List<Serie>();
        private StreamReader sr;
        public SerieRepositorio()
        {
             // modifiquei a forma que esta classe funciona para ler o arquivo .txt //Diogo
            try
            {
                this.sr = new StreamReader("séries.txt");
                string line = sr.ReadLine();

                while (line != null)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        id = int.Parse(line);
                        line = sr.ReadLine();
                        genero = (Genero)Enum.Parse(typeof(Genero), line);
                        line = sr.ReadLine();
                        titulo = line;
                        line = sr.ReadLine();
                        descricao = line;
                        line = sr.ReadLine();
                        excluido = bool.Parse(line);
                        line = sr.ReadLine();
                        ano = int.Parse(line);
                        line = sr.ReadLine();
                        if (!id.Equals(null))
                        {
                            this.listaSerie.Add(new Serie(id, genero, titulo, descricao, ano, excluido));
                        }
                    }
                }
                this.sr.Close();
            }
            catch
            {
                this.sr.Close();
            }
        }

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return this.listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}

