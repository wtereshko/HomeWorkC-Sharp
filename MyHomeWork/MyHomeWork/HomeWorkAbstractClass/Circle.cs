using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork.HomeWorkAbstractClass
{
   public class Circle: Shape
    {
        private const double _pi = 3.14159;
        private double _radius;

        public Circle(string name, double radius) : base(name) {
            _radius = radius;
        }

        public override double Perimeter() {
            return (2* _pi * _radius);
        }

        public override double Area() {
            return _pi * (_radius * _radius);
        }
    }
}
