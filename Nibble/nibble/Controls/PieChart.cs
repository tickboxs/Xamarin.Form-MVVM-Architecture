using System;
using nibble.Interfaces;
using SkiaSharp.Views.Forms;
using nibble.Domains;
using System.Collections.Generic;
using SkiaSharp;
using System.Threading.Tasks;

namespace nibble.Controls
{
    public class PieChart:IChart
    {
        public IList<PieChartData> ChartDatas { private set; get; }
        private SKCanvasView Canvas { set; get; }

        // ZRotate and ZTranslate For Animation
        private float ZRotateAndTranslate { set; get; } = 0.0f;

        public PieChart(IList<PieChartData> chartDatas, SKCanvasView canvasView)
        {
            ChartDatas = chartDatas;
            Canvas = canvasView;
        }

        public override void Draw(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            int totalValues = 0;

            foreach (PieChartData pieChartData in ChartDatas)
            {
                totalValues += (int)pieChartData.Value;
            }

            SKPoint center = new SKPoint(info.Width / 2, info.Height / 2);

            // Assign ZRotateAndTranslate To Animate Offset
            float explodeOffset = 20 * ZRotateAndTranslate;
            float radius = Math.Min(info.Width / 2, info.Height / 2) - 2 * explodeOffset;
            SKRect rect = new SKRect(center.X - radius, center.Y - radius,
                                     center.X + radius, center.Y + radius);

            // Assign ZRotateAndTranslate To Rotation
            float startAngle = 0 + (30.0f * ZRotateAndTranslate);

            foreach (PieChartData pieChartData in ChartDatas)
            {
                // Get Index
                var pieChartDataIndex = ChartDatas.IndexOf(pieChartData);

                float sweepAngle = (float)(360f * pieChartData.Value / totalValues);

                using (SKPath path = new SKPath())
                using (SKPaint fillPaint = new SKPaint())
                using (SKPaint outlinePaint = new SKPaint())
                {
                    path.MoveTo(center);
                    path.ArcTo(rect, startAngle, sweepAngle, false);
                    path.Close();

                    fillPaint.Style = SKPaintStyle.Fill;
                    fillPaint.Color = GetColorByIndex(pieChartDataIndex);

                    outlinePaint.Style = SKPaintStyle.Stroke;
                    outlinePaint.StrokeWidth = 5;
                    outlinePaint.Color = SKColors.Black;

                    // Calculate "explode" transform
                    float angle = startAngle + 0.5f * sweepAngle;
                    float x = explodeOffset * (float)Math.Cos(Math.PI * angle / 180);
                    float y = explodeOffset * (float)Math.Sin(Math.PI * angle / 180);

                    canvas.Save();
                    canvas.Translate(x, y);

                    // Fill and stroke the path
                    canvas.DrawPath(path, fillPaint);
                    //canvas.DrawPath(path, outlinePaint);
                    canvas.Restore();
                }

                startAngle += sweepAngle;
            }
        }

        public async Task ZRotateAndTranslateAnimationLoop(float seconds = 0.25f)
        {
            ZRotateAndTranslate = 0.0f;
            const float ZRotateAndTranslate_Max = 1.0f;

            const short Frame_Rate = 60;
            float ZRotateAndTranslate_Step = (ZRotateAndTranslate_Max - ZRotateAndTranslate) / (seconds * Frame_Rate);

            while (ZRotateAndTranslate <= ZRotateAndTranslate_Max)
            {
                ZRotateAndTranslate += ZRotateAndTranslate_Step;
                Canvas.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(1.0f / Frame_Rate));
            }

        }
    }
}
