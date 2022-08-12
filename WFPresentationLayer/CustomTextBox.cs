using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WFPresentationLayer
{
    internal class CustomTextBox : TextBox
    {
        public TypeText Type { get; set; }

        public CustomTextBox()
        {
            this.Leave += CustomTextBox_Leave;
            this.KeyPress += CustomTextBox_KeyPress;
            this.Enter += CustomTextBox_Enter;
            //this.TextChanged += CustomTextBox_TextChanges;
        }

        private void CustomTextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (this.Type == TypeText.Numero)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            
        }

        private void CustomTextBox_Enter(object? sender, EventArgs e)
        {
            this.TextAlign = HorizontalAlignment.Right;
            if (this.Type == TypeText.Dinheiro)
            {
                this.Text = "";
            }
        }


        private void CustomTextBox_Leave(object? sender, EventArgs e)
        {
            if (this.Type == TypeText.Dinheiro && double.TryParse(this.Text, out _))
            {
                this.Text = double.Parse(this.Text).ToString("C2");
            }
        }
    }

    public enum TypeText
    {
        Dinheiro, Numero
    }

}
