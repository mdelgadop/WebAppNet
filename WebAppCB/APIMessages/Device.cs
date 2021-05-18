using System.ComponentModel.DataAnnotations;

namespace WebAppCB.APIMessages
{
    public class Device : GenericAPIMessage
    {
        public string id { get; set; }

        [Required]
        public string locality { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string device_location { get; set; }

        [Required]
        public string postal_code { get; set; }

        [Required]
        public int lat { get; set; }

        [Required]
        public int lon { get; set; }

    }
}