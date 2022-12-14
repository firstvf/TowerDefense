public class GreenGolem_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 2600;
        base.Awake();
        Speed = 5f;
    }

    void Start()
    {
        Experience = 15;
        Money = 15;
    }
}