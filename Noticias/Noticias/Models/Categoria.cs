﻿using System.ComponentModel.DataAnnotations;

namespace Noticias.Models
{
    public class Categoria : Base
    {
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
