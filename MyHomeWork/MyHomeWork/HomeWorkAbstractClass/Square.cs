using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork.HomeWorkAbstractClass
{
    public class Square: Shape
    {
        private double _side;

        public Square(string name, double side) : base(name) {
            _side = side;
        }

        public override double Perimeter() {
            return 4 *_side;
        }

        public override double Area() {
            return _side * _side;
        }
    }
}
