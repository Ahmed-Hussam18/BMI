using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI_CALCULATOR
{
     class Person
     {
        public double Weight { get; set; }
        public double HeightCm { get; set; }
        public double BMI;
        public BmiCategory Category;

        public virtual void CalculateBmI()
        {

            double heightM = HeightCm / 100;
            BMI = Weight / (heightM * heightM);


            if (BMI < 18.5)
            {
                Category = BmiCategory.UnderWeight;
            }
            else if (BMI >= 18.5 && BMI < 24.9)
            {
                Category = BmiCategory.Normal;
            }
            else if (BMI >= 25 && BMI < 29.9)
            {
                Category = BmiCategory.OverWeight;
            }
            else
            {
                Category = BmiCategory.obese;
            }
        }
        public enum BmiCategory
        {
            UnderWeight,
            Normal,
            OverWeight,
            obese,
        }
     }
}

