public class BossGhost_B : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 20000;
        base.Awake();
        Speed = 2.5f;
    }

    private void Start()
    {
        Experience = 250;
        Money = 250;
    }
}