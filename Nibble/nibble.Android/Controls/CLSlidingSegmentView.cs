using System;
using Android.Content;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using nibble.Controls;
using Android.Graphics;
using Android.Widget;
using Java.Interop;
using System.Collections.Generic;
using Android.Views.Animations;
using Android.Animation;
using Android.Graphics.Drawables;

namespace nibble.Droid.Controls
{
    public class CLSlidingSegmentView : RelativeLayout, View.IOnClickListener
    {

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }

            set
            {
                if (_selectedIndex != value)
                {
                    MoveSlider(_selectedIndex, value);
                }
                _selectedIndex = value;

            }
        }

        private IList<TextView> _textViews = new List<TextView>();
        private View _slider;
        private SlidingConfig[] _configs;
        private Xamarin.Forms.Color _unselectedTextColor;
        private Xamarin.Forms.Color _backgroundColor;
        private int _duration;

        // Slider Move Step
        private int _step;

        [Obsolete]
        public CLSlidingSegmentView(Context context, SlidingConfig[] configs,Xamarin.Forms.Color backgroundColor, Xamarin.Forms.Color unselectedTextColor,int duration) : base(context)
        {

            Post(() =>
            {
                _configs = configs;
                _unselectedTextColor = unselectedTextColor;
                _backgroundColor = backgroundColor;
                _duration = duration;

                // BackgroundColor
                SetBackgroundColor(_backgroundColor.ToAndroid());

                // Corner Radius
                this.ClipToOutline = true;
                this.OutlineProvider = new SlidingSegmentOutlineProvider();

                // Add Slider
                _slider = new View(context);

                // Add Corner Radius to Slider
                _slider.ClipToOutline = true;
                _slider.OutlineProvider = new SlidingSegmentOutlineProvider();
                _slider.SetBackgroundColor(_configs[0].SliderColor.ToAndroid());

                _step = (int)(Width / (configs.Length));
                RelativeLayout.LayoutParams sliderLayoutParams = new RelativeLayout.LayoutParams(_step, LayoutParams.MatchParent);
                _slider.LayoutParameters = sliderLayoutParams;
                AddView(_slider);

                // Add LinearLayout
                var linearLayout = new LinearLayout(context);
                linearLayout.Orientation = Orientation.Horizontal;

                // Add TextViews
                for (int i = 0; i < configs.Length; i++)
                {
                    var config = configs[i];
                    var textView = new TextView(context)
                    {
                        Text = config.Title,
                        Clickable = true,
                        Gravity = GravityFlags.Center,
                        Tag = i
                    };

                    // TextView TextColor
                    if (i == 0)
                    {
                        textView.SetTextColor(config.TextColor.ToAndroid());
                    }
                    else
                    {
                        textView.SetTextColor(_unselectedTextColor.ToAndroid());
                    }
                    
                    LinearLayout.LayoutParams textViewLayoutParams = new LinearLayout.LayoutParams((int)(Width / configs.Length), LayoutParams.MatchParent)
                    {
                        Weight = 1,
                    };

                    // Click Event
                    textView.SetOnClickListener(this);
                    _textViews.Add(textView);
                    linearLayout.AddView(textView, textViewLayoutParams);
                }
                RelativeLayout.LayoutParams linearLayoutLayoutParams = new RelativeLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                AddView(linearLayout, linearLayoutLayoutParams);

            });
        }

        public void OnClick(View v)
        {
            SelectedIndex = (int)(v.Tag);
        }

        private void MoveSlider(int oldIndex,int newIndex)
        {
            foreach (TextView textView in _textViews)
            {

                // Change Tab Text Color
                if ((int)textView.Tag != newIndex)
                {
                    textView.SetTextColor(_unselectedTextColor.ToAndroid());
                }
                else
                {
                    textView.SetTextColor(_configs[newIndex].TextColor.ToAndroid());
                }
            }

            // Change Slider BackgroundColor
            _slider.SetBackgroundColor(_configs[newIndex].SliderColor.ToAndroid());

            // Translate Slider
            var currentX = oldIndex * _step;
            var futureX = newIndex * _step;
            TranslateAnimation translateAnimation = new TranslateAnimation(currentX, futureX, 0, 0);
            // Fill After has to be true for _slider Stay at the end
            translateAnimation.FillAfter = true;
            translateAnimation.Duration = _duration;
            _slider.StartAnimation(translateAnimation);

        }
    }

    // Implement Corner Radius
    class SlidingSegmentOutlineProvider : ViewOutlineProvider
    {

        public override void GetOutline(View view, Outline outline)
        {

            var min_size = view.Width > view.Height ? view.Height : view.Width;
            outline.SetRoundRect(0, 0, view.Width, view.Height, (float)(min_size * 0.5));
        }
    }
}
