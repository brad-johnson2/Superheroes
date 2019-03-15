﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Superheroes.Models
{
    public class Superhero
    {


        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string PrimaryAbility { get; set; }

        public string SecondAbility { get; set; }

        public string Catchphrase { get; set; }

    }
}