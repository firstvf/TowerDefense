public class BatEnemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 180;
        base.Awake();
        Speed = 3.5f;
    }

    void Start()
    {
        Experience = 3;
        Money = 3;
    }
}