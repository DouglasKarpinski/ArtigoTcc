using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTcc.ViewModel.Emotion
{
    public class FaceRectangleViewModel
    {
        public Decimal Top { get; set; }
        public Decimal Left { get; set; }
        public Decimal Width { get; set; }
        public Decimal Height { get; set; }
    }
}
