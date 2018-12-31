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
                dataForm.RegisterEditor("NumericTextBox", new CustomEntryEditor(dataForm));
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

    public class CustomEntryEditor : DataFormEditor<CustomEntry>
    {
        public CustomEntryEditor(SfDataForm dataForm) : base(dataForm)
        {

        }
        protected override CustomEntry OnCreateEditorView(DataFormItem dataFormItem)
        {
            return new CustomEntry();
        }

    }

    public class CustomEntry : SfNumericTextBox
    {

    }
}
