using System.Text;
using AppControleFinanceiro.Models;
using AppControleFinanceiro.Repositories;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
    private ITransactionRepository _repository;

	public TransactionAdd(ITransactionRepository repository)
	{
		InitializeComponent();

        this._repository = repository;
        
	}

    private void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnButtonClicked_ToSave(System.Object sender, System.EventArgs e)
    {
        if (IsValidData() == false)
            return;
        SaveTransactionInDatabase();

        Navigation.PopAsync();
        var count = _repository.GetAll().Count();
        App.Current.MainPage.DisplayAlert("Mensagem!!!", $"Existem {count} registro(s) no banco!", "OK");

    }

    private void SaveTransactionInDatabase()
    {
        Transaction transaction = new Transaction()
        {
            Name = EntryName.Text,
            Type = RadioIncome.IsChecked ? TransactionType.Income : TransactionType.Expences,
            Date = DatePickerDate.Date,
            Value = double.Parse(EntryValue.Text)

        };

        _repository.Add(transaction);
    }

    private bool IsValidData()
    {
        bool valid = true;
        StringBuilder sb = new StringBuilder();

        if (string.IsNullOrEmpty(EntryName.Text) || string.IsNullOrWhiteSpace(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' deve ser preenchido");
            valid = false;
        }

        if (string.IsNullOrEmpty(EntryValue.Text) || string.IsNullOrWhiteSpace(EntryValue.Text))
        {
            sb.AppendLine("O campo 'Valor' deve ser preenchido");
            valid = false;
        }
            

        double result;
        if (string.IsNullOrEmpty(EntryValue.Text) && double.TryParse(EntryValue.Text, out result))
        {
            sb.AppendLine("O campo 'Valor' deve é invalido");
            valid = false;
        }

        if (valid==false)
        {
            LabelError.Text = sb.ToString();
        }
        else
        {
            LabelError.Text = string.Empty;
        }
        return valid;
    }
}