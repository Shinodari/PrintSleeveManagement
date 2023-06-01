using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintSleeveManagement
{
    class DateInputDialog
    {
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            DateTimePicker dateTimePicke = new DateTimePicker();
            Button buttonOK = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;

            buttonOK.Text = "OK";
            buttonCancel.Text = "Cancel";

            label.SetBounds(9, 20, 372, 13);
            dateTimePicke.SetBounds(12, 36, 100, 20);
            buttonOK.SetBounds(124, 10, 75, 23);
            buttonCancel.SetBounds(124, 43, 75, 23);

            dateTimePicke.Format = DateTimePickerFormat.Short;
            dateTimePicke.Value = DateTime.Now;

            label.AutoSize = true;
            form.ClientSize = new System.Drawing.Size(211, 76);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            form.Controls.AddRange(new Control[] { label, dateTimePicke, buttonOK, buttonCancel });
            form.AcceptButton = buttonOK;
            form.CancelButton = buttonCancel;

            buttonOK.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            DialogResult dialogResult = form.ShowDialog();
            value = dateTimePicke.Text;
            return dialogResult;
        }
    }
}
