using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Strand7_Steel_Section_Sizing
{
    [Serializable]
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
        public string Name
        {
            get
            {
                if (SType == 2) return String.Format("CHS{0:0}x{1:0.0}", D1 * 1000, T1 * 1000);
                else return (D2 * 1000).ToString() + " x " + (D1 * 1000).ToString() + " x " + (T1 * 1000).ToString() + " x " + (T2 * 1000).ToString();
            } 
        }
        public int Group { get; set; }
        public int Number { get; set; }
        public Section()
        { }
        public Section(double d1, double d2, double d3, double t1, double t2, double t3, double a, double z11, double z22, int stype, double i11, double i22, int group)
        {
            D1 = d1; D2 = d2; D3 = d3; T1 = t1; T2 = t2; T3 = t3; A = a; Z11 = z11; Z22 = z22; SType = stype; I11 = i11; I22 = i22; Group = group;
            sectionDoubles = new double[] { D1, D2, D3, T1, T2, T3 };
        }

    }
    class SectionCompare : IComparer<Section>
    {
        public int Compare(Section x, Section y)
        {
            return x.A.CompareTo(y.A);
        }
    }

    [Serializable]
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
            while(sections.Count < group+1)
            { 
                sections.Add(new List<Section>()); 
            }
            int n = sections[group].Count;
            s.Number = n;
            sections[group].Add(s);
            nGroups = sections.Count;
        }
        public List<Section> GetGroup(int group)
        { return sections[group]; }
        public Section GetSection(int group, int sectionIndex)
        { return sections[group][sectionIndex]; }
    }

    [Serializable]
    class Beam
    {
        public int Number { get; set; }
        public int PropertyNum { get; set; }
        public double A_x_stress_max { get; set; }
        public double A_x_stress_min { get; set; }
        public double M_11_stress { get; set; }
        public double M_22_stress { get; set; }
        public double A_x_def { get; set; }
        public double M_11_def { get; set; }
        public double M_22_def { get; set; }
        public double d_freq { get; set; }
        public double d_freq_x { get; set; }
        public double d_freq_y { get; set; }
        public double d_freq_z { get; set; }
        public double Length { get; set; }
        //public string Name { get; set; }
        public bool isValid { get; set; }
        public Beam(int number)
        {
            Number = number;
            PropertyNum = 0;
            A_x_stress_max = 0;
            A_x_stress_min = 0;
            M_11_stress = 0;
            M_22_stress = 0;
            A_x_def = 0;
            M_11_def = 0;
            M_22_def = 0;
            d_freq = 0;
            Length = 0;
            isValid = true;
        }
        public double CalcDeflection(Section s)
        {
            double Deflection = (A_x_def / s.A + M_11_def / s.I11 + M_22_def / s.I22) * Length / (210*1e9); //A_x_def is the product of results from max case and virtual case
            return Deflection;
        }
        public double CalcFreq(Section s)
        {
            double Freq = (A_x_def * A_x_def / s.A + M_11_def * M_11_def / s.I11 + M_22_def * M_22_def / s.I22) * Length / (210*1e9); // / (s.A * d_freq* 0.00000787) ;
            return Freq;
        }
        public double CalcModalMass(Section s)
        {
            //double Mass = s.A * Length * (d_freq_x * d_freq_x + d_freq_y * d_freq_y + d_freq_z * d_freq_z) * 0.00000787 / 1000 / 2;
            double Mass = s.A * Length * d_freq * 7870.0 / 2;
            return Mass;
        }
        public double CalcMass(Section s)
        {
            double Mass = s.A * Length * 7870.0;// 0.00000785;
            return Mass;
        }
        public double CalcStress(Section s)
        {
            double stress;
            
            if (A_x_stress_min < 0)
            {
                double stress_min;
                double stress_max;

                //### Buckling Check ####
                double E_s = 210000E6; // N/m^2
                double f_y = 355E6; // N/m^2
                double alpha_c = 0.21;
                double lambda = Math.Sqrt(Math.Pow(Length, 2) * s.A / Math.Min(s.I11, s.I22));
                double N_cr = Math.Pow(Math.PI, 2) * E_s * s.A / Math.Pow(lambda, 2);
                double lambda_nd = Math.Max(0.2, Math.Sqrt(s.A * f_y / N_cr));
                double phi_m = 0.5 * (1 + alpha_c * (lambda_nd - 0.2) + Math.Pow(lambda_nd, 2));
                double chi_n = 1 / (phi_m + Math.Sqrt(Math.Pow(phi_m, 2) - Math.Pow(lambda_nd, 2)));

                stress_min = Math.Abs(A_x_stress_min) / s.A / chi_n + M_11_stress / s.Z11 + M_22_stress / s.Z22;
                stress_max = Math.Abs(A_x_stress_max) / s.A + M_11_stress / s.Z11 + M_22_stress / s.Z22;               
                stress = Math.Max(stress_min, stress_max);
            }
            else
            {
                stress = A_x_stress_max / s.A + M_11_stress / s.Z11 + M_22_stress / s.Z22;
            }
            return stress;
        }
    }

    [Serializable]
    class BeamProperty// : ICloneable
    {
        public bool DeflectionGoverned { get; set; }
        private int _currentSectionInt;
        public int CurrentSectionInt
        {
            get { return _currentSectionInt; }
            set 
            {
                _currentSectionInt = value;
                if (Optimise)
                { 
                    CurrentSection = _sectionLibrary.GetSection(Group, _currentSectionInt);
                    _name = CurrentSection.Name;
                }
            }
        }

        private Section _currentSection;
        public Section CurrentSection {
            get { return _currentSection; }
            set
            {
                _currentSection = value;
                //_currentSectionInt = value.Number;
                _name = value.Name;
            }
        }
        public int NewSectionInt { get; set; }
        public int Number { get; set; }
        public int Group { get; set; }
        public bool Optimise { get; set; }
        public bool Overstressed { get; set; }
        private string _name;
        public string Name { get { return _name; } }

        public List<Beam> Beams { get; set; }

        private SectionLibrary _sectionLibrary;
        
        public BeamProperty(int p,SectionLibrary sectionLibrary )
        {
            Number = p;
            Beams = new List<Beam>();
            _sectionLibrary = sectionLibrary;
            CurrentSectionInt = 0;
            _currentSection = new Section();
        }
        //public object Clone()
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        if (this.GetType().IsSerializable)
        //        {
        //            BinaryFormatter formatter = new BinaryFormatter();
        //            formatter.Serialize(stream, this);
        //            stream.Position = 0;
        //            return formatter.Deserialize(stream);
        //        }
        //        return null;
        //    }
        //}
    }
}
