using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Strand7_Steel_Section_Sizing
{
    class Section
    {
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public double T1 { get; set; }
        public double T2 { get; set; }
        public double T3 { get; set; }
        public double A { get; set; }
        public double Z11 { get; set; }
        public double Z22 { get; set; }
        public int SType { get; set; }
        public double I11 { get; set; }
        public double I22 { get; set; }
        public double[] sectionDoubles { get; set; }
        public string sName { get; set; }
        public int group { get; set; }
        public int Number { get; set; }
        public Section(double d1, double d2, double d3, double t1, double t2, double t3, double a, double z11, double z22, int stype, double i11, double i22, int g)
        {
            D1 = d1; D2 = d2; D3 = d3; T1 = t1; T2 = t2; T3 = t3; A = a; Z11 = z11; Z22 = z22; SType = stype; I11 = i11; I22 = i22; group = g;
            sectionDoubles = new double[] { D1, D2, D3, T1, T2, T3 };
            sName = D1.ToString() + " x " + D2.ToString() + " x " + T1.ToString() + " x " + T2.ToString();
        }

    }
    class SectionLibrary
    {
        private List<List<Section>> sections { get; set; }
        public int nGroups {get;set;}
        public SectionLibrary()
        {
            sections = new List<List<Section>>();
        }
        public void AddSection(Section s, int group)
        {
            if(sections.Count <= group)
            { 
                sections.Add(new List<Section>()); 
            }
            int n = sections[group].Count;
            s.Number = n;
            sections[group].Add(s);
            nGroups = sections.Count;
        }
        public List<Section> Group(int group)
        {
            return sections[group];
        }
    }
    class Beam
    {
        public int Number { get; set; }
        public int PropertyNum { get; set; }
        public double A_x_stress { get; set; }
        public double M_11_stress { get; set; }
        public double M_22_stress { get; set; }
        public double A_x_def { get; set; }
        public double M_11_def { get; set; }
        public double M_22_def { get; set; }
        public double Length { get; set; }
        public Beam(int number)
        {
            Number = number;
            PropertyNum = 0;
            A_x_stress = 0;
            M_11_stress = 0;
            M_22_stress = 0;
            A_x_def = 0;
            M_11_def = 0;
            M_22_def = 0;
            Length = 0;
        }
        public double CalcDeflection(Section s)
        {
            double Deflection = (A_x_def / s.A + M_11_def / s.I11 + M_22_def / s.I22) * Length / 210000;
            return Deflection;
        }
        public double CalcMass(Section s)
        {
            double Mass = s.A * Length * 0.00000000785;
            return Mass;
        }
        public double CalcStress(Section s)
        {
            double Stress;
            if (A_x_stress < 0)
            {
                //### Buckling Check ####
                //double E_s = 210000;
                //double f_y = 355;
                //double alpha_c = 0.49;
                //double lambda = Math.Sqrt(Math.Pow(Length, 2) * s.A / Math.Min(s.I11, s.I22));
                //double N_cr = Math.Pow(Math.PI, 2) * E_s * s.A / Math.Pow(lambda, 2);
                //double lambda_nd = Math.Max(0.2, Math.Sqrt(s.A * f_y / N_cr));
                //double phi_m = 0.5 * (1 + alpha_c * (lambda_nd - 0.2) + Math.Pow(lambda_nd, 2));
                //double chi_n = 1 / (phi_m + Math.Sqrt(Math.Pow(phi_m, 2) - Math.Pow(lambda_nd, 2)));

                //Stress = Math.Abs(A_x_stress) / s.A / chi_n + M_11_stress / s.Z11 + M_22_stress / s.Z22;
                Stress = Math.Abs(A_x_stress) / s.A + M_11_stress / s.Z11 + M_22_stress / s.Z22;
            }
            else
            {
                Stress = A_x_stress / s.A + M_11_stress / s.Z11 + M_22_stress / s.Z22;
            }
            return Stress;
        }
    }
    class BeamProperty
    {
        public bool DeflectionGoverned { get; set; }
        public int CurrentSectionInt { get; set; }
        public int NewSectionInt { get; set; }
        public int Number { get; set; }
        public int Group { get; set; }
        public bool Optimise { get; set; }

        public BeamProperty(int p)
        {
            Number = p;
        }
        public BeamProperty(int p,int g)
        {
            Number = p;
            Group = g;
        }
    }
}
