namespace RestSharp.Portable.Google.Drive.Model
{
    /// <summary>
    /// Metadata about image media.
    /// </summary>
    public class ImageMediaMetadata
    {
        /// <summary>
        /// The width of the image in pixels.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// The height of the image in pixels.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// The rotation in clockwise degrees from the image's original orientation.
        /// </summary>
        public int? Rotation { get; set; }

        /// <summary>
        /// Geographic location information stored in the image.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// The date and time the photo was taken (EXIF format timestamp).
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// The make of the camera used to create the photo.
        /// </summary>
        public string CameraMake { get; set; }

        /// <summary>
        /// The model of the camera used to create the photo.
        /// </summary>
        public string CameraModel { get; set; }

        /// <summary>
        /// The length of the exposure, in seconds.
        /// </summary>
        public decimal? ExposureTime { get; set; }

        /// <summary>
        /// The aperture used to create the photo (f-number).
        /// </summary>
        public decimal? Aperture { get; set; }

        /// <summary>
        /// Whether a flash was used to create the photo.
        /// </summary>
        public bool? FlashUsed { get; set; }

        /// <summary>
        /// The focal length used to create the photo, in millimeters.
        /// </summary>
        public decimal? FocalLength { get; set; }

        /// <summary>
        /// The ISO speed used to create the photo.
        /// </summary>
        public int? IsoSpeed { get; set; }

        /// <summary>
        /// The metering mode used to create the photo.
        /// </summary>
        public string MeteringMode { get; set; }

        /// <summary>
        /// The type of sensor used to create the photo.
        /// </summary>
        public string Sensor { get; set; }

        /// <summary>
        /// The exposure mode used to create the photo.
        /// </summary>
        public string ExposureMode { get; set; }

        /// <summary>
        /// The color space of the photo.
        /// </summary>
        public string ColorSpace { get; set; }

        /// <summary>
        /// The white balance mode used to create the photo.
        /// </summary>
        public string WhiteBalance { get; set; }
        
        /// <summary>
        /// The exposure bias of the photo (APEX value).
        /// </summary>
        public decimal? ExposureBias { get; set; }

        /// <summary>
        /// The smallest f-number of the lens at the focal length used to create the photo (APEX value).
        /// </summary>
        public decimal? MaxApertureValue { get; set; }

        /// <summary>
        /// The distance to the subject of the photo, in meters.
        /// </summary>
        public int? SubjectDistance { get; set; }

        /// <summary>
        /// The lens used to create the photo.
        /// </summary>
        public string Lens { get; set; }
    }
}
