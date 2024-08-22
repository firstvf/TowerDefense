public class BossGolem_Red : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 125000;
        base.Awake();
        Speed = 1.3f;
    }
    private void Start()
    {
        Experience = 600;
        Money = 600;
    }
}