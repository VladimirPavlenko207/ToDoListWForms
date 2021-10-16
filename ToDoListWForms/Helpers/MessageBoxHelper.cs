using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoListWForms.Helpers
{
    public static class MessageBoxHelper
    {
        public static bool SendOkCancelMessage(string question)
        {
            if (MessageBox.Show(question, "", MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
            return true;
        }

        public static void SendSimpleMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
