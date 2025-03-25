using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DataTransferObjects
{
    public class CreateDepartmentDto
    {


        [Required]
        public string Name { get; set; }=string.Empty;

        [Range(100, 1000)]
        public string Code { get; set; } = null!;
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }



    }
}
