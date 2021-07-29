using System.IO;
using System.Collections.Generic;
using System;

namespace AtividadeExtra.Models
{
    public class ClasseBase
    {
        Random random = new Random();
        public void CriarPasta(string _caminho)
        {
            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> LerTodasLinhasCSV(string _caminho)
        {
            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(_caminho))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                } 
            } 
            return linhas;
        }

        public void ReescreverCSV(string _caminho, List<string> linhas)
        {

            using (StreamWriter output = new StreamWriter(_caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }

        public int GerarId(List<int> ids)
        {
            int id;

            do
            {
                id = random.Next(1,10000);

                if (!ids.Contains(id))
                {
                    return id;
                }


            } while (ids.Contains(id));

            return id;

        }
    }
}