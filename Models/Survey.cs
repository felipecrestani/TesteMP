using System;
using System.ComponentModel.DataAnnotations;

namespace TesteMP.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? HTML { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? CSS { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? Javascript { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? Python { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? Django { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? iOS { get; set; }
        [Range(0, 10, ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public int? Android { get; set; }
    }
}
