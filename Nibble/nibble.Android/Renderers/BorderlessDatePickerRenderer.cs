using System;
using nibble.Pages.Main;
using nibble.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Content;
using nibble.Controls;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRenderer))]
namespace nibble.Droid.Renderers
{
    public class BorderlessDatePickerRenderer:DatePickerRenderer
    {
        public BorderlessDatePickerRenderer(Context context) : base(context)
        {

        }

        protected override EditText CreateNativeControl()
        {
            var editText = base.CreateNativeControl();

            // Config editText
            // Remove Bottom Border Line
            editText.SetBackground(null);
            return editText;
        }
    }
}
