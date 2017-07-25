using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonGame.API.Models
{
    public class Pokemon
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public int BreedNumber { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        [ForeignKey("Move1")]
        public long Move1ID { get; set; }
        public Move Move1 { get; set; }

        [ForeignKey("Move2")]
        public long Move2ID { get; set; }
        public Move Move2 { get; set; }

        [ForeignKey("Move3")]
        public long Move3ID { get; set; }
        public Move Move3 { get; set; }

        [ForeignKey("Move4")]
        public long Move4ID { get; set; }
        public Move Move4 { get; set; }
    }
}
