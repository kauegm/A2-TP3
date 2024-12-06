﻿using System.ComponentModel.DataAnnotations;

namespace TrabalhoA2.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Endereco { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}