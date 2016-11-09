namespace PicoTracer
{
    public struct ShaderInputInfo
    {
        public Vector3 position { get; set; }
        public Vector3 normal { get; set; }
        public Vector2 uv { get; set; }

        public double lightIntensity { get; set; }
        public Color lightColor { get; set; }
        public Vector3 lightDirection { get; set; }
        /// <summary>
        /// Determines whetever the lighting data is GI, if true then lightDirection is zero.
        /// </summary>
        public bool lightGI { get; set; }
    }
}