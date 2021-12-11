using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_XPTO_OS.Models
{
    [Table("TB_XPTO_OS")]
    public class OS
    {
        [Key]
        public int NUM_OS { get; set; }
        [Required]
        public string TITULO_SERV { get; set; }
        [Required]
        public Int64 CNPJ_CLI { get; set; }
        [Required]
        public string NOME_CLI { get; set; }
        [Required]
        public Int64 CPF_PREST { get; set; }
        [Required]
        public string NOME_PREST { get; set; }
        [Required]
        public DateTime DATA_SERV { get; set; }
        [Required]
        public decimal VALOR_SERV { get; set; }

    }
}
