using Microsoft.AspNetCore.Mvc.Rendering;
using mvc_web_app;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_web_app.Models
{
    public class DespesasDasUnidadesViewModel
    {
        public List<DespesaDaUnidade>? DespesasDasUnidades { get; set; }
        public SelectList? Vencimentos { get; set; }
        [DataType(DataType.Date)]
        public DateTime? vencimento { get; set; }
        public string? unidade { get; set; }
        public SelectList? Unidades { get; set; }
    }
}