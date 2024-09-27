namespace BattleChess.Mathematics
{
    public static class Easing
    {
        private static float Square(float t)
        {
            return t * t;
        }

        private static float Flip(float t)
        {
            return 1 - t;
        }

        public static float Linear(float t)
        {
            return t;
        }

        public static float EaseIn(float t)
        {
            return Square(t);
        }

        public static float EaseOut(float t)
        {
            return Flip(Square(Flip(t)));
        }
    }
}