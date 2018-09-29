using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAuditInterception.Models
{
    public class Comando
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(8000)]
        public string Texto { get; set; }

        public int Tipo { get; set; }

        // Retornar a descrição do Tipo
        public string TipoDescricao
        {
            get
            {
                switch (Tipo)
                {
                    case 1:
                        return "Text";
                    case 4:
                        return "StoredProcedure";
                    case 512:
                        return "TableDirect";
                    default:
                        return "";
                }
            }
        }

        public ICollection<Parametro> Parametros { get; set; }


    }
}