using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MichaelPavichFinal.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; }

        public string Url()
        {
            string imageBase64Data = Convert.ToBase64String(this.Data);
            string imageDataUrl = $"data:image/jpg;base64,{imageBase64Data}";
            return imageDataUrl;
        }
    }
}
