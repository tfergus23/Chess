namespace Chess.Board
{
    public class Coordinate //Simple double class for holding board coordinates
    {
        public int x;
        public int y;

        public Coordinate(int x, int y)
        {
            if (x > 7 || x < 0)
            {
                throw new System.ArgumentException("X coordinate out of bounds: " + x);
            }
            if (y > 7 || y < 0){
                throw new System.ArgumentException("Y coordinate out of bounds: " + y);
            }
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj.GetType() == this.GetType())) return false;
            Coordinate that = (Coordinate) obj;
            return this.x == that.x && this.y == that.y;

        }

        public override int GetHashCode()
        {
            int result = 17;
            int xCode = x;
            int yCode = y;
            result = 37 * result + xCode;
            result = 37 * result + yCode;
            return result;
        }
    }
}
