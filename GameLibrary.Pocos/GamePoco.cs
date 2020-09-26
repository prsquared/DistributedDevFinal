using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameLibrary.Pocos
{
    public class GamePoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DeveloperId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual DeveloperPoco Developer { get; set; }
    }
}
