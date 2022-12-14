public class BossGolem_Green : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 90000;
        base.Awake();
        Speed = 2f;
    }
    private void Start()
    {
        Experience = 650;
        Money = 650;
    }
}