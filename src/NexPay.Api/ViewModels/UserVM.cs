using System.ComponentModel.DataAnnotations;

namespace NexPay.Api.ViewModels
{
    public class UserVM
    {
        public int Id { get; }

        /// <summary>
        /// Name of the user
        /// </summary>
        /// <value></value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Cnpj of the user
        /// </summary>
        /// <value></value>
        [Required]
        public string Cnpj { get; set; }
    }
}