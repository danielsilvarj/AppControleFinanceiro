using System.Text;

namespace AppControleFinanceiro.Views;

public partial class TransactionAdd : ContentPage
{
	public TransactionAdd()
	{
		InitializeComponent();


        
	}

    private void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnButtonClicked_ToSave(System.Object sender, System.EventArgs e)
    {

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