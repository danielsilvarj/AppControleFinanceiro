namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
	public TransactionList()
	{
		InitializeComponent();
	}

	private void OnButtonClicked_To_TransactionAdd(Object sender, EventArgs args)
	{
		Navigation.PushAsync(new TransactionAdd());
		
	}

    private void OnButtonClicked_To_TransactionEdit(object sender, EventArgs e)
    {
		
		Navigation.PushAsync(new TransactionEdit());
    }
}