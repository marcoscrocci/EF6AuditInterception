using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAuditInterception.Models
{
    public class Parametro
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Nome { get; set; }

        public int Direcao { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(8000)]
        public string ValorText { get; set; }

        public double? ValorNumero { get; set; }

        // Retornar a descrição da Direcao
        private readonly string _direcaoDescricao;

        public string DirecaoDescricao
        {
            get
            {
                switch (Direcao)
                {
                    case 1:
                        return "Input";
                    case 2:
                        return "Output";
                    case 3:
                        return "InputOutput";
                    case 6:
                        return "ReturnValue";
                    default:
                        return "";
                }
            }
        }

        public virtual Comando ComandoInfo { get; set; }

    }
}