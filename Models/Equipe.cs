
using System;
using System.Collections.Generic;
using System.IO;
using E_Players_ASPNETCore1.Interfaces;

namespace E_Players_ASPNETCore1.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH = "Database/equipe.csv";
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        public void Criar(Equipe e)
        {
            string[] linha = {PrepararLinha(e)};
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.Add(PrepararLinha(e) );
            linhas.RemoveAll(n => n.Split(";")[0] == e.IdEquipe.ToString());
        }

        public void Delete(int idEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(n => n.Split(";")[0] == IdEquipe.ToString());
        }
    }
}