using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dead_By_Daylight_Companion.helper {

    public class kb {
        public static void Register_Bind(KeyEventArgs e, ref int vk, ref TextBox tb) {
            vk = (int)e.KeyCode;
            tb.Text = e.KeyData.ToString().Length == 2
                && e.KeyData.ToString().Contains("D")
                ? e.KeyData.ToString().Remove(0, 1)
                : e.KeyData.ToString();
        }
    }
}
