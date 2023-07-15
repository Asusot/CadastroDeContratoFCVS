using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeContratoFCVS.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do cliente deve ter no mínimo 3 caracteres.")]
        public string NomeCliente { get; set; }
        [RegularExpression("^[1-9]+$", ErrorMessage = "O número do contrato deve conter apenas 9 dígitos.")]
        public int NumeroContrato { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = " O valor do contrato so pode conter numeros")]
        public double ValorContrato { get; set; }


        public class DataAnteriorOuIgualAgoraAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime data)
        {
            return data <= DateTime.Today;
        }
        
        return false;
    }
}

        [Display(Name = "Data de Assinatura")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataAnteriorOuIgualAgora(ErrorMessage = "A data de assinatura não pode ser uma data futura.")]
        public DateTime DataAssinatura { get; set; }
        public byte[] ArquivoPdf { get; set; }
    }
}
