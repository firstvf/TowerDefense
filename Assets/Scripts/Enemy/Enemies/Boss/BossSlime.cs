public class BossSlime : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 1500;
        base.Awake();
        Speed = 1f;
    }
    private void Start()
    {
        Experience = 25;
        Money = 25;
    }
}