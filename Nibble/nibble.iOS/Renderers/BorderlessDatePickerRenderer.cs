
using System;
using Xamarin.Forms.Platform.iOS;
using nibble.Controls;
using nibble.iOS.Renderers;
using Xamarin.Forms;
using UIKit;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRenderer))]
namespace nibble.iOS.Renderers
{
    public class BorderlessDatePickerRenderer: DatePickerRenderer
    {
        public BorderlessDatePickerRenderer()
        {
            
        }

        protected override UITextField CreateNativeControl()
        {
            var textField = base.CreateNativeControl();

            // Config textField
            // Remove Border
            textField.BorderStyle = UITextBorderStyle.None;
            return textField;
        }
    }
}
