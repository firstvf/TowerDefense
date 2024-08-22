public class RedGolem_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 3300;
        base.Awake();
        Speed = 3f;
    }

    void Start()
    {
        Experience = 14;
        Money = 14;
    }
}