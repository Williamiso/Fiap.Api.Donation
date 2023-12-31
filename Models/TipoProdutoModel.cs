﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Api.Donation.Models
{
    public class TipoProdutoModel
    {
        public int TipoProdutoId { get; set; }

        [Required(ErrorMessage = "O nome para o tipo do produto é obrigatório.")]
        [StringLength(55)]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(256)]
        public string? Descricao { get; set; }

        [NotMapped]
        public string? Token { get; set; }
    }
}