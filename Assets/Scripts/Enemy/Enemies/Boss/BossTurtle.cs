public class BossTurtle : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 7000;
        base.Awake();
        Speed = 1f;
    }

    void Start()
    {
        Experience = 50;
        Money = 50;
    }
}