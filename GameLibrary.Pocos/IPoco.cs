using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Pocos
{
    public interface IPoco
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
