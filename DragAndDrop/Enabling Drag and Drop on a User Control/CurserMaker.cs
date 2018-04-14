using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Enabling_Drag_and_Drop_on_a_User_Control {

    class CurserMaker {

        public static Cursor GetImageCursor(string path) {

            byte[] buff = System.IO.File.ReadAllBytes(path);
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buff);
            Cursor curser = new Cursor(ms, true);
            return curser;
        }
    }
}
