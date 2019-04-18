using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppFinanceiro.Models;

namespace AppFinanceiro.Controller
{
    public class DBFinanca
    {
        SQLiteConnection conn;//representa o banco de dados
        
        public string StatusMessage { get; set; } //representa a mensagem da ultima operação
        public DBFinanca (string dbPath)
        {

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Financa>();//cria a tabela no banco se ela não existir 

        }
        public void  Inserir (Financa financa)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(financa.Descricao)) 
                throw new Exception("Descrição da finança em branco");
                if (string.IsNullOrEmpty(financa.TipoOperacao)) 
                throw new Exception("Tipo Operação em branco");
                if (financa.Data == null)
                    throw new Exception("Data da finança não informada");
                if (financa.Valor == 0)
                    throw new Exception("Valor da finança igual a zero. Informe um valor diferente");
                result = conn.Insert(financa);

                StatusMessage = string.Format("{0} registro(s) adcionado(s): [Descrição: {1}, Tipo: {2}, Valor: {3} ], ",
                    result, financa.Descricao, financa.TipoOperacao, financa.Valor);
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Erro ao adcionar  o registro. Error: {0}", ex.Message);
            }
        }
        public void Alterar (Financa financa)
        {

        }
        public void Excluir(int Id)
        {

        }
        public List<Financa> Localizar()
        {
            List<Financa> Lista = new List<Financa>();
            try
            {
                Lista = conn.Table<Financa>().ToList();

            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Erro ao recuperar dados. {0}", ex.Message);
            }
            return Lista;
        }
        //localizar
        //mais coisas
    }
}
