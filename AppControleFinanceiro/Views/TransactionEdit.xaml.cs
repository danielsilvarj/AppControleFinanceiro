namespace AppControleFinanceiro.Views;

public partial class TransactionEdit : ContentPage
{
	public TransactionEdit()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
		Navigation.PopAsync();
		//Navigation.PopModalAsync();
    }
}