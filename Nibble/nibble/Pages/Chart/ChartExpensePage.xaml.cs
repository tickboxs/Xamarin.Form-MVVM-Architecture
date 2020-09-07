using System;
using System.Collections.Generic;
using nibble.ViewModels.Chart;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using nibble.Domains;
using nibble.Controls;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Chart
{
    [Router(Path = "chart/expense")]
    public partial class ChartExpensePage : BaseContentPage<ChartExpensePageViewModel>
    {

        public ChartExpensePage(BaseViewModel vm) : base(vm)
        {

            InitializeComponent();
            canvas.PaintSurface += OnCanvasViewPaintSurface;
        }

        // OnDraw Callback
        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            if (VM.PieChart == null) return;
            VM.PieChart.Draw(args);

        }

        protected async override void OnAppearing()
        {

            // Load BarChartDatas Only Once
            if (VM.PieChart == null)
            {
                var pieChartDatas = (BindingContext as ChartExpensePageViewModel).LoadPieChartDatas();
                VM.PieChart = new PieChart(pieChartDatas,canvas);

                // Animate
                await VM.PieChart.ZRotateAndTranslateAnimationLoop();
            }
        }
    }
}
