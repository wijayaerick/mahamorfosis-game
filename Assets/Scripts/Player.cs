public class Player : Creature {

    int level;
    int exp;

    public Player() : base()
    {
        level = 1;
        exp = 0;
    }

    public Player(int level, int exp, Status status) : base(status)
    {
        this.level = level;
        this.exp = exp;
    }

}
