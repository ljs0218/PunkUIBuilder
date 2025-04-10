
namespace Game.Scripts.Graphics
{
    [System.Serializable]
    public class RectOff
    {
        public int bottom { get; set; }
        public int left { get; set; }
        public int right { get; set; }
        public int top { get; set; }

        public RectOff(int bottom, int left, int right, int top)
        {
            this.bottom = bottom;
            this.left = left;
            this.right = right;
            this.top = top;
        }
    }
}