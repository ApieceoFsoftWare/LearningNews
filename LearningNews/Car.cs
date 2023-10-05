using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningNews
{
    public class Car
    {
        private string numberPlate;

        public string NumberPlate
        {
            get
            {
                return this.numberPlate;
            }
            set
            {
                this.numberPlate = value;
            }
        }

        public string brand { get; /*private*/ set; }   // kapsülleme yapmayacaksak bu şekilde hızlı bir property tanımı yapabiliriz...
                                                        // Auto Property ile gelen bir yenilik
                                                        // Aynı zamanda private ile de hızlı bir şekilde işaretleyebiliriz
        public Car()
        {
            
        }
    }
}
