using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameLibrary.Pocos
{
    public class DeveloperPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PublisherId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GamePoco> Games { get; set; }
        public virtual PublisherPoco Publisher { get; set; }
    }
}
