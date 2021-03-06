﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameLibrary.Pocos
{
    public class PublisherPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DeveloperPoco> Developers { get; set; }
    }
}
