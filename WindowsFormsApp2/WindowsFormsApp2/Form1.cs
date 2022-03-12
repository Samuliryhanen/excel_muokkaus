using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFile();
        }
        public void OpenFile()
        {
            
            Excel excel_p2 = new Excel(@"C:\C#_projects\xlc\harjoitus.xlsx", 2); // avataan sivu2
            string[,] read = excel_p2.ReadRange(10, 4, 15, 7); // parametreinä mistä solusta mihin soluun luetaan 
            excel_p2.Close();

            Former former = new Former(read, 4,6); //luokka, jolla muokataan data
            string[,] write = former.GetResult(); //Get-metodi muokatulle datalle

            Excel excel_p1 = new Excel(@"C:\C#_projects\xlc\harjoitus.xlsx", 1);//avataan sivu 1
            excel_p1.WriteRange(1, 1, 6, 2, write);
            excel_p1.SaveAs(@"C:\C#_projects\xlc\muokattu.xlsx");// ja tallennetaan erillisenä tiedostona
            excel_p1.Close();
        }
    }
}
