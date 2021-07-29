using System;
using System.Collections.Generic;
using System.IO;

namespace AtividadeExtra.Models
{
    public class Usuario : ClasseBase
    {
        public string Nome { get; private set; }
        private string Email { get; set; }
        public int Peso { get; private set; }
        public int Altura { get; private set; }
        public int IdUsuario { get; private set; }
        private string Senha { get; set; }
        private const string CAMINHO = "Database/Usuario.csv";

        public void AtribuirEmail(string _email)
        {
            Email = _email;
        }

        public void AtribuirNome(string _nome)
        {
            Nome = _nome;
        }

        public void AtribuirPeso(int _peso)
        {
            Peso = _peso;
        }

        public void AtribuirSenha(string _senha)
        {
            Senha = _senha;
        }

        public void AtribuirAltura(int _altura)
        {
            Altura = _altura;
        }

        public Usuario()
        {
            CriarPasta(CAMINHO);
        }

        public string PreparaLinha(Usuario u)
        {
            return $"{u.Email};{u.Nome};{u.Peso};{u.Senha};{u.Altura};{u.IdUsuario}";
        }

        public void Criar(Usuario u)
        {
            string[] linha = {PreparaLinha(u)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Excluir(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[5] == id.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }

        public void Alterar(Usuario u) {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[5] == u.IdUsuario.ToString());
            linhas.Add(PreparaLinha(u));
            ReescreverCSV(CAMINHO,linhas);
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();


            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Usuario user = new Usuario();
                user.Email = linha[0];
                user.Nome = linha[1];
                user.Peso = Int32.Parse(linha[2]);
                user.Senha = linha[3];
                user.Altura = Int32.Parse(linha[4]);
                user.IdUsuario = Int32.Parse(linha[5]);

                usuarios.Add(user);
            }

            return usuarios;
        }

        public List<int> ReturnIds()
        {
            List<int> Ids = new List<int>();

            foreach (var item in Listar())
            {
                Ids.Add(item.IdUsuario);
            }

            return Ids;
        }

        public int RetornaId() {
            return IdUsuario;
        }

        public string RetornaEmail() {
            return Email;
        }

        public void AtribuirID()
        {
            IdUsuario = GerarId(ReturnIds());
        }

        public void AtribuirId(int id) {
            IdUsuario = id;
        }

    }
}