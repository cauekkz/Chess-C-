
namespace board
{
    internal class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public override string ToString()
        {
            return Row.ToString() + ", " + Col.ToString();
        }
    }
}
