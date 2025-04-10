namespace Game.Scripts.Graphics
{
    [System.Serializable]
    public class Color
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public int a { get; set; }

        public Color(int r, int g, int b, int a = 255)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }
}