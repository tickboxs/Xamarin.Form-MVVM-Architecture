using System;
using System.Collections.Generic;
using nibble.ViewModels.Chart;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using nibble.Domains;
using nibble.Controls;
using nibble.Interfaces;
using nibble.ViewModels;
using System.Diagnostics;
using nibble.Attributes;

namespace nibble.Pages.Chart
{
    [Router(Path = "chart")]
    public partial class ChartPage : BaseContentPage<ChartPageViewModel>
    {

        public ChartPage(BaseViewModel vm) : base(vm)
        {
            InitializeComponent();
            canvas.PaintSurface += OnCanvasViewPaintSurface;
        }


        // OnDraw Callback
        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            if (VM.BarChart == null) return;
            VM.BarChart.Draw(args);

        }

        protected async override void OnAppearing()
        { 
            // Load BarChartDatas Only Once
            if (VM.BarChart == null)
            {
                var barChartDatas = (BindingContext as ChartPageViewModel).LoadBarChartDatas();
                VM.BarChart = new BarChart(barChartDatas, canvas);

                await VM.BarChart.ScaleAnimationLoop();
            }
        }

    }
}
