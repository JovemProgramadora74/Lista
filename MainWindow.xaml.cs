using System.Collections.ObjectModel;
using System.Windows;

namespace Lista;

public partial class MainWindow : Window
{
    public ObservableCollection<string> nomes { get; set; } = new();
    
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
}