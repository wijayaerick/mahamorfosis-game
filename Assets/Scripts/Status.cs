public class Status {

    public float health;
    public float attack;
    public float defense;
    public float aspd; // seconds per attack
    public float speed;

    public Status()
    {
        health = 1000;
        attack = 100;
        defense = 100;
        aspd = 0.5f;
        speed = 6;
    }

    public Status(float health, float attack, float defense, float aspd, float speed)
    {
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.aspd = aspd;
        this.speed = speed;
    }
}
