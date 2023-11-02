﻿using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post : BaseDomain
    {
        public int AutorId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
