using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaCar_API.Entities
{
    public class CarModal
    {
        public CarModal()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public double EngineCapacity { get; set; }
        public Brand Brand { get; set; }
        public List<Car> Cars { get; set; }
    }
}
