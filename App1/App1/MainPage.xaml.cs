using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Servico;
using App1.Servico.Modelo;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //logica do programa

            //validacoes
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {

                try
                {


                    Endereco end = ViaCepServico.BuscarEndercoViaCEP(cep);

                    if (end != null)
                    {

                        RESULTADO.Text = $"Endereço: {end.logradouro} de {end.bairro}, {end.localidade}, {end.uf}";
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado com cep informado: " + cep, "OK");
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");


                }

            }

        }
        private bool isValidCEP(string cep)
        {
            bool isValid = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! o CEP deve conter 8 caracteres.", "OK");
                //erro
                isValid = false;
            }

            int NovoCEP = 0;

            if (!int.TryParse(cep, out NovoCEP))
            {
                ///erro
                DisplayAlert("EãRRO", "CEP Inválido! O CEP deve ser composto apenas por numeros.", "OK");
                isValid = false;
            }
            return isValid;
        }

    }
}
