using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GameDto
    {
        public int N1 { get; set; }
        public int N2 { get; set; }
    }
    public class GameDtoList
    {
        public List<GameDto> Pairs { get; set; }
    }
}
