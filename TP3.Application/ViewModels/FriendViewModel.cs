using System.ComponentModel.DataAnnotations;

namespace TP3.Application.ViewModels
{
    public class FriendViewModel
    {

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public DateTime BirthDate { get; set; }
    }
}
