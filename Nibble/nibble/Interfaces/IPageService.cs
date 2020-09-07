using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using nibble.ViewModels;
namespace nibble.Interfaces
{
	
	public enum Scene
    {
        Login,
        Chart,
        ChartExpense,
        ChartIncome,
        AssetBalance,
        AssetCreate,
        AssetName,
        Home,
        Items,
        Profile,
        TransactionAmount,
        TransactionName,
        Transaction,
        MainTabbed
    }

	public interface IPageService
	{
		Task PushAsync(Scene scene,BaseViewModel vm);
        Task PushAsync(Page page);
        Task PopAsync();
		void SwitchAsync(Scene scene,BaseViewModel vm);
        void SwitchAsync(Page page);
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
		Task<string> DisplaActionSheet(string title,string cancel, string destruction, string[] buttons);
		void PushDepthDescrease();
	}
}
