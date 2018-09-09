using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHomeWork.HomeWorkAbstractClass
{
    /*1) Create abstract class Shape with field name and property Name. 
   Add constructor with 1 parameter  and abstract methods Area() and Perimeter(), which can return area 
   and perimeter of shape; 
   Create classes Circle, Square derived from Shape with field radius (for Circle) and side (for Square).  
   Add necessary constructors, properties to these classes, override methods from abstract class Shape. 
   a) In Main() create list of Shape, then ask user to enter data of 10 different shapes.  Write name, area 
   and perimeter of all shapes. 
   b) Find shape with the largest perimeter and print its name. 
   3) Sort shapes by area and print obtained list (Remember about IComparable)
*/
   public abstract class Shape
   {
       private string _name;

       public string Name
       {
           get { return _name; }
           set { _name = value; }
       }

       public Shape(string name) {
           _name = name;
       }
       public abstract double Perimeter();
       public abstract double Area();
    }
}
