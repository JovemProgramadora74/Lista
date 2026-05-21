using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Lista;

public partial class MainWindow : Window
{
    public ObservableCollection<string> nomes { get; } = [];
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    private void BtnAdicionaNome_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }
        // Adicionar o tbNome.Text na lista de nomes
        nomes.Add(tbNome.Text);
    }


    private void BtnRemoveNome_OnClick(object sender, RoutedEventArgs e)
    {
        // Verificar se o nome existe dentro da Lista
        // Caso não, informar ao usuário que o nome não existe na lista e para a execução do metodo
        // Caso sim, remover o nome da lista
        
        if (!nomes.Contains(tbNome.Text, StringComparer.CurrentCultureIgnoreCase))
        {
            MessageBox.Show("Esse nome não existe");
            return;
        }

        var nomeEncontrado = nomes.FirstOrDefault(nomePessoa =>
            nomePessoa.Equals(tbNome.Text, StringComparison.CurrentCultureIgnoreCase));
        
        nomes.Remove(nomeEncontrado);
    }
    
    private void BtnEncontrarNomes_OnClick(object sender, RoutedEventArgs e)
    {
        // Valida se o campo está vazio
        if (string.IsNullOrWhiteSpace(tbNome.Text))
        {
            MessageBox.Show("Escreva um nome válido!");
            return;
        }
        
        // Limpa as seleções da busca anterior
        lbNomes.SelectedItems.Clear();
        
        // Guardamos o termo de busca em minúsculo para evitar repetir o .ToLower() no laço
        var termoBuscaMinusculo = tbNome.Text.ToLower();

        // Varre a sua ObservableList
        foreach (var nome in nomes)
        {
            // Verifica se o nome contém o termo pesquisado
            if (nome.Contains(termoBuscaMinusculo, StringComparison.CurrentCultureIgnoreCase))
            {
                // Adiciona diretamente à coleção de itens selecionados
                lbNomes.SelectedItems.Add(nome);
            }
            
        }
    }
}