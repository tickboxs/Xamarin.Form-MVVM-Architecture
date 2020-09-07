using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace nibble.Controls
{
    public struct SlidingConfig
    {
        public string Title;
        public Color TextColor;
        public Color SliderColor;
    }

    public class SlidingSegmentView : View
    {

        // Bindable Properties
        // Configs
        public static readonly BindableProperty ConfigsProperty = BindableProperty.Create(
          propertyName: "Configs",
          returnType: typeof(SlidingConfig[]),
          declaringType: typeof(SlidingSegmentView),
          defaultValue: new SlidingConfig[] {
              new SlidingConfig
              {

              } ,
              new SlidingConfig
              {

              }
          });

        public SlidingConfig[] Configs
        {
            get { return (SlidingConfig[])GetValue(ConfigsProperty); }
            set { SetValue(ConfigsProperty, value); }
        }

        // Bindable Properties
        // Duration
        // Animation Duration ms
        public static readonly BindableProperty DurationProperty = BindableProperty.Create(
          propertyName: "Duration",
          returnType: typeof(int),
          declaringType: typeof(SlidingSegmentView),
          defaultValue: 500);

        public int Duration
        {
            get { return (int)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        // Bindable Properties
        // UnselectedTextColor
        public static readonly BindableProperty UnselectedTextColorProperty = BindableProperty.Create(
          propertyName: "UnselectedTextColor",
          returnType: typeof(Color),
          declaringType: typeof(SlidingSegmentView),
          defaultValue: Color.Black);

        public Color UnselectedTextColor
        {
            get { return (Color)GetValue(UnselectedTextColorProperty); }
            set { SetValue(UnselectedTextColorProperty, value); }
        }

        public SlidingSegmentView()
        {

        }

        // Command
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
          propertyName: "Command",
          returnType: typeof(ICommand),
          declaringType: typeof(SlidingSegmentView));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
