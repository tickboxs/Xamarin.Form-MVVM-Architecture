using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using nibble.ViewModels;
using Xamarin.Forms;
using nibble.Services;
using nibble.Pages.Home;
using nibble.Interfaces;
using nibble.Pages.Main;
using nibble.Pages.Chart;
using Autofac;
using nibble.Domains;
using System.Collections.Generic;
using nibble.Controls;

namespace nibble.ViewModels.Chart
{
    public class ChartPageViewModel:BaseViewModel
    {

        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();
        private IChartService _chartService = DIContainer.Current.Resolve<IChartService>();

        public BarChart BarChart { set; get; }

        public ChartPageViewModel()
        {
            GoChartIncomeCommand = new Command(GoChartIncome);
            GoChartExpenseCommand = new Command(GoChartExpense);
            ChoosePeriodCommand = new Command(ChoosePeriod);

        }

        public ICommand GoChartIncomeCommand { get; private set; }
        public ICommand GoChartExpenseCommand { get; private set; }
        public ICommand ChoosePeriodCommand { get; private set; }

        private async void GoChartIncome()
        {
            await Router.Navigate("chart/income", new ChartIncomePageViewModel());
        }

        private async void GoChartExpense()
        {
            await Router.Navigate("chart/expense", new ChartExpensePageViewModel());
        }

        private async void ChoosePeriod()
        {
            string[] period = { AppResources.Weekly, AppResources.Monthly, AppResources.Yearly, AppResources.AllTime };
            string result = Router.Action(
                "actionsheet",
                new object[] {
                    AppResources.ChoosePeriod,
                    AppResources.Cancel,
                    AppResources.Daily,
                    period }) as string;
            if (!result.Equals(AppResources.Cancel))
            {
                await BarChart.ScaleAnimationLoop();
            }
        }

        public IList<BarChartData> LoadBarChartDatas()
        {
            return _chartService.GetBarChartData();
        }

    }
}
