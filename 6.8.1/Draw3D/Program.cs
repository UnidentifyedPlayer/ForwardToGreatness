using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Draw3D
{
    static class Program
    {
        public static FormProperty formProperty;
        public static FormGraph formMain;
        public static FormMyDialog formMyDialog;
        public static FormTools formTools;
        public static FormMatrix formMatrix;
        public static FormListBox formListBox;
        public static FormMyCustomDialog formMyCustomDialog;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormGraph();
            formTools = new FormTools();
            formProperty = new FormProperty();
            formMatrix = new FormMatrix();
            formListBox = new FormListBox();
            formMyDialog = new FormMyDialog();
            formMyCustomDialog = new FormMyCustomDialog();
            formTools.Show();
            Application.Run(formMain);
        }
    }
}
