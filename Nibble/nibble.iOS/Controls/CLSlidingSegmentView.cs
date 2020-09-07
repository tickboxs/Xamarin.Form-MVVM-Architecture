using System;
using UIKit;
using CoreGraphics;
using Xamarin.Forms.Platform.iOS;
using System.Collections.Generic;
using Xamarin.Forms;
using nibble.Controls;

namespace nibble.iOS.Controls
{
    public class CLSlidingSegmentView:UIView
    {
        private IList<UILabel> _labels = new List<UILabel>();
        private SlidingConfig[] _configs;
        private int _duration;
        private Color _unselectedTextColor;
        private UIView _slider;

        private int _selectedIndex = 0;
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
                    // Move Slider
                    SetNeedsLayout();
                }
                _selectedIndex = value;

            }
        }
        public CLSlidingSegmentView(SlidingConfig[] configs,Action<int> action,Color backgroundColor,Color unselectedTextColor,int duration)
        {
            _configs = configs;
            _duration = duration;
            _unselectedTextColor = unselectedTextColor;
            BackgroundColor = backgroundColor.ToUIColor();

            _slider = new UIView
            {
                
                BackgroundColor = _configs[SelectedIndex].SliderColor.ToUIColor()
            };

            AddSubview(_slider);

            for (int i = 0; i < _configs.Length; i++)
            {
                var config = _configs[i];
                var label = new UILabel
                {
                    Text = config.Title,
                    TextColor = config.TextColor.ToUIColor(),
                    TextAlignment = UITextAlignment.Center,
                    BackgroundColor = UIColor.Clear
                };

                _labels.Add(label);
                AddSubview(label);

                label.Tag = i;

                // Set Tap Event
                label.UserInteractionEnabled = true;
                var tapGesture = new UITapGestureRecognizer((UITapGestureRecognizer recognizer) =>
                {
                    SelectedIndex = (int)recognizer.View.Tag;
                    action(SelectedIndex);
                });

                label.AddGestureRecognizer(tapGesture);
            }

        }


        public override void LayoutSubviews()
        {
            // Set Corner Radius
            var mix_size = Frame.Height > Frame.Width ? Frame.Width : Frame.Height;
            Layer.CornerRadius = (nfloat)(mix_size * 0.5);
            Layer.MasksToBounds = true;

            // Set Slider Corner Radius
            _slider.Layer.CornerRadius = (nfloat)(mix_size * 0.5);
            _slider.Layer.MasksToBounds = true;
            

            var labelHeight = Frame.Height;
            var labelWidth = Frame.Width / _configs.Length;

            UIView.Animate((_duration/1000.0f), () =>
            {
                // Animate Slider BackgroundColor Change
                _slider.BackgroundColor = _configs[SelectedIndex].SliderColor.ToUIColor();

                // Animate Slider Translation
                _slider.Frame = new CGRect(SelectedIndex * labelWidth, 0, labelWidth, labelHeight);

                // Set Each Label Frame
                foreach (UILabel label in _labels)
                {
                    var index = _labels.IndexOf(label);
                    label.Frame = new CGRect(index * labelWidth, 0, labelWidth, labelHeight);

                    // Set Label TextColor
                    if (SelectedIndex == index)
                    {
                        label.TextColor = _configs[SelectedIndex].TextColor.ToUIColor();
                    }
                    else
                    {
                        label.TextColor = _unselectedTextColor.ToUIColor();
                    }
                }
            });

        }


    }
}
