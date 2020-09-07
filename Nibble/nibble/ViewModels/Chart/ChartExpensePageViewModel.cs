using System;
using System.Windows.Input;
using nibble.Interfaces;
using nibble.Services;
using Xamarin.Forms;
using Autofac;
using System.Collections.Generic;
using nibble.Domains;
using nibble.Controls;

namespace nibble.ViewModels.Chart
{
    public class ChartExpensePageViewModel:BaseViewModel
    {

        private IPageService _pageService = DIContainer.Current.Resolve<IPageService>();
        private IChartService _chartService = DIContainer.Current.Resolve<IChartService>();

        public PieChart PieChart { set; get; }

        public ICommand ChoosePeriodCommand { get; private set; }

        public ChartExpensePageViewModel()
        {
            ChoosePeriodCommand = new Command(ChoosePeriod);
        }

        private async void ChoosePeriod()
        {
            string[] period = { AppResources.Weekly, AppResources.Monthly, AppResources.Yearly, AppResources.AllTime };
            string result = Router.Action(
                "actionsheet",
                new object[] {
                    AppResources.ChoosePeriod,
                    AppResources.Cancel,
                    AppResources.Daily, period }) as string;
            if (!result.Equals(AppResources.Cancel))
            {
                await PieChart.ZRotateAndTranslateAnimationLoop();
            }
        }

        public IList<PieChartData> LoadPieChartDatas()
        {
            return _chartService.GetPieChartData();
        }

    }
}
