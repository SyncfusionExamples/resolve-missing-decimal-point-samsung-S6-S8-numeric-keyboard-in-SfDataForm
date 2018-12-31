using Syncfusion.SfNumericTextBox.XForms;
using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.DataForm.Editors;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NumKeyBoardDecimalPoint
{
    public class DataFormBehavior : Behavior<ContentPage>
    {

        SfDataForm dataForm = null;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);

            dataForm = bindable.FindByName<SfDataForm>("dataForm");
            dataForm.DataObject = new CompanyInfo();

            if (Device.RuntimePlatform == Device.Android)
            {
                dataForm.RegisterEditor("NumericTextBox", new CustomNumericTextEditor(dataForm));
                dataForm.RegisterEditor("Salary", "NumericTextBox");
            }
            else
            {
                dataForm.RegisterEditor("Salary", "Currency");
            }
        }
    }

    public class CompanyInfo
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Salary { get; set; }
    }

    public class CustomNumericTextEditor : DataFormEditor<CustomNumericTextBox>
    {
        public CustomNumericTextEditor(SfDataForm dataForm) : base(dataForm)
        {

        }
        protected override CustomNumericTextBox OnCreateEditorView(DataFormItem dataFormItem)
        {
            return new CustomNumericTextBox();
        }

    }

    public class CustomNumericTextBox : SfNumericTextBox
    {

    }
}
