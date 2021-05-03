using System;

namespace MichaelPavichFinal.Models
{
    /// <summary>
    ///     Defines the Image class.
    /// </summary>
    /// <author>
    ///     Michael Pavich
    /// </author>
    /// <date>
    ///     Started 5/3/2021
    /// </date>
    public class Image
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the image identifier.
        /// </summary>
        /// <value>
        ///     The image identifier.
        /// </value>
        public int ImageId { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public byte[] Data { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     URLs this instance.
        /// </summary>
        /// <returns>the image url</returns>
        public string Url()
        {
            var imageBase64Data = Convert.ToBase64String(this.Data);
            var imageDataUrl = $"data:image/jpg;base64,{imageBase64Data}";
            return imageDataUrl;
        }

        #endregion
    }
}