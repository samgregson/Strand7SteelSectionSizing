using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Strand7_Steel_Section_Sizing
{
    class Optimisation
    {
        public static double Stress(double A_x,double M_11, double M_22, double A, double I11, double I22, double L)
        {
            double Stress = (A_x / A + M_11 / I11/2 + M_22 / I22/2);// / L;
            return Stress;
        }
        public static double Deflection(double A_x, double M_11, double M_22, double A, double I11, double I22, double L)
        {
            double Deflection = (A_x / A + M_11 / I11 + M_22 / I22) * L / 210000;
            return Deflection;
        }
        public static string CheckiErr(int iErr)
        {
            StringBuilder sb = new StringBuilder(St7.kMaxStrLen);
            string errorstring;
            St7.St7GetAPIErrorString(iErr, sb, sb.Capacity);
            errorstring = sb.ToString();
            if (errorstring == "")
            {
                St7.St7GetSolverErrorString(iErr, sb, sb.Capacity);
                errorstring = sb.ToString();
            }
            if (errorstring != "No error.")
            {
                //MessageBox.Show(errorstring);
                //Console.WriteLine("");
                //Console.WriteLine("Strand7 API error: " + errorstring);
                //Console.WriteLine("The program has terminated early.");

                string sFilePath = System.IO.Path.GetTempPath() + "API Error Log.txt";
                System.IO.File.WriteAllText(sFilePath, errorstring);

                Environment.Exit(0);

                return errorstring;
            }
            return "";
        }
    }
}
