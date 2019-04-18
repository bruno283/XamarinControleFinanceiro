using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppFinanceiro.Models;

namespace AppFinanceiro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            String caminhoDoBanco = App.dbPath;

            //criar uma finança

            Financa obj = new Financa();
            obj.Descricao = "1 teste";
            obj.TipoOperacao = "Credito";
            obj.Valor = 200;
            obj.Data = DateTime.Now;

            //criar o banco 
            App.TbFinanca.Inserir(obj);
            List<Financa> financas = App.TbFinanca.Localizar();
            Lista.ItemsSource = financas;


        }
    }
}
