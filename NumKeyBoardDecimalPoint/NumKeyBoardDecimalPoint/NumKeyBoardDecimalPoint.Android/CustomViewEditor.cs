using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NumKeyBoardDecimalPoint;
using NumKeyBoardDecimalPoint.Droid;
using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.SfNumericTextBox.XForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomViewEditor))]
namespace NumKeyBoardDecimalPoint.Droid
{
    public class CustomViewEditor : SfNumericTextBoxRenderer
    {
        public CustomViewEditor()
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<SfNumericTextBox> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.InputType = Android.Text.InputTypes.TextFlagCapWords;
                Control.KeyListener = Android.Text.Method.DigitsKeyListener.GetInstance("0123456789.");
            }
        }
    }
}