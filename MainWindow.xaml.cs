using Models;
using Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Pokedex
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiRequest _apiRequest = new ApiRequest();
        public MainWindow()
        {
            InitializeComponent();

        }

        public async void CarregarPokemon(string nome)
        {

            Pokemon pokemon = new Pokemon();
            try
            {
                pokemon = await _apiRequest.PokemonPorNome(nome);

                if (nome == "")
                {
                    dataPkm.Source = null;
                    txtName.Text = "";
                    txtHp.Text = "";
                    txtAtack.Text = "";
                    txtDefense.Text = "";
                    txtSpecialDef.Text = "";
                    txtSpecialAtack.Text = "";
                    txtSpeed.Text = "";
                    txbSearch.Clear();
                    MessageBox.Show("O campo está vazio.");
                    this.InitializeComponent();
                   

                }
                else
                {
                    txbSearch.Clear();
                    var dir = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + pokemon.Id + ".png";
                    Uri uri = new Uri(dir);

                    dataPkm.Source = new BitmapImage(uri);

                    txtName.Text = pokemon.PokemonName.ToUpper();
                    txtHp.Text = pokemon.Stats[0].BaseStat.ToString();
                    txtAtack.Text = pokemon.Stats[1].BaseStat.ToString();
                    txtDefense.Text = pokemon.Stats[2].BaseStat.ToString();
                    txtSpecialDef.Text = pokemon.Stats[3].BaseStat.ToString();
                    txtSpecialAtack.Text = pokemon.Stats[4].BaseStat.ToString();
                    txtSpeed.Text = pokemon.Stats[5].BaseStat.ToString();

                }
            }
            catch (Exception)
            {
                dataPkm.Source = null;
                txtName.Text = "";
                txtHp.Text = "";
                txtAtack.Text = "";
                txtDefense.Text = "";
                txtSpecialDef.Text = "";
                txtSpecialAtack.Text = "";
                txtSpeed.Text = "";
                txbSearch.Clear();
                MessageBox.Show("Pokemon não encontrado.");
                this.InitializeComponent();
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            CarregarPokemon(txbSearch.Text.ToLower());
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
