namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                Validate(value, nameof(Length));
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                Validate(value, nameof(Width));
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                Validate(value, nameof(Height));
                height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return GetLateralSurfaceArea() + 2 * (Length * Width);
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * (Length * Height) + 2 * (Width * Height);
        }

        public double GetVolume()
        {
            return Length * Width * Height;
        }

        private void Validate(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }
    }
}
