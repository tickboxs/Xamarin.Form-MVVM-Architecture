using System;
using nibble.Interfaces;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using nibble.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nibble.Controls
{
    public class BarChart:IChart
    {
        public IList<BarChartData> ChartDatas { private set; get; }
        private SKCanvasView Canvas { set; get; }

        public BarChart(IList<BarChartData> chartDatas, SKCanvasView canvasView)
        {
            ChartDatas = chartDatas;
            Canvas = canvasView;
        }

        // YScale For Animation
        private float YScale { set; get; } = 0.0f;

        public override void Draw(SKPaintSurfaceEventArgs args)
        {
            // Get Infos
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            // Leave Some Room For Axis X Y
            const float Axis_X = 100;
            const float Axis_Y = 100;

            // Clear Canvas Before Actual Draw
            canvas.Clear();

            // Bar Width
            var Bar_Width = (info.Width - Axis_X) / (ChartDatas.Count * 2);
            var Max_Value = ChartDatas.Max((chartData) => chartData.Value);

            // Draw Axis
            SKPaint axisPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.LightGray.ToSKColor(),
                StrokeWidth = 5,
                StrokeCap = SKStrokeCap.Square,
                PathEffect = SKPathEffect.CreateDash(new float[] { 0, 10 }, 10)
            };

            // Draw X Axis
            canvas.DrawLine(Axis_X - Bar_Width, info.Height - Axis_Y, info.Width, info.Height - Axis_Y, axisPaint);

            // Draw Y Axis
            canvas.DrawLine(Axis_X - Bar_Width, info.Height - Axis_Y, Axis_X - Bar_Width, 0, axisPaint);

            // Draw Label
            SKPaint textPaint = new SKPaint
            {
                Color = Color.Gray.ToSKColor(),
                TextSize = 25
            };

            const float Text_Offset_X = 10;
            const float Text_Offser_Y = 20;

            // Draw Y Label
            IList<float> yLabels = new List<float> { 0,100,200,300,400,500,600,700,800,900,1000};
            foreach (float yLabel in yLabels)
            {
                var index = yLabels.IndexOf(yLabel);
                canvas.DrawText(yLabel.ToString(), Text_Offset_X, (info.Height - Axis_Y) * (yLabels.Count - 1 - index) / (yLabels.Count - 1) + Text_Offser_Y, textPaint);
            }

            // Draw X Label
            foreach (BarChartData chartData in ChartDatas)
            {
                var index = ChartDatas.IndexOf(chartData);
                canvas.DrawText((index + 1).ToString(), index * (Bar_Width * 2) + Axis_X, (info.Height - Axis_Y) + (Text_Offser_Y * 2), textPaint);
            }


            // Draw Bar
            foreach (BarChartData chartData in ChartDatas)
            {
                // Get Index For Fill Color Determine
                var chartDataIndex = ChartDatas.IndexOf(chartData);

                // Begin Draw Each ChartData
                SKPaint barPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = GetColorByIndex(chartDataIndex)
                };

                // Get Height For Each BarChartData
                var Bar_Height = chartData.Value / Max_Value * (info.Height - Axis_Y);

                // Reverse Y Coordinate
                var Y = (info.Height - Axis_Y) - (float)Bar_Height * YScale;

                // Assign YScale To Height To Animate
                canvas.DrawRect(chartDataIndex*2* Bar_Width + Axis_X, (float)Y, Bar_Width, (float)Bar_Height*YScale, barPaint);

            }


        }

        public async Task ScaleAnimationLoop(float seconds = 0.25f)
        {
            YScale = 0.0f;
            const float YScale_Max = 1.0f;
            const short Frame_Rate = 60;
            float YScale_Step = (YScale_Max - YScale) / (seconds * Frame_Rate);

            while (YScale <= YScale_Max)
            {
                YScale += YScale_Step;
                Canvas.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0f/ Frame_Rate));
            }

        }
    }
}
