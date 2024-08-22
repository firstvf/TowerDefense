public class BossGhost_Green : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 70000;
        base.Awake();
        Speed = 2.5f;
    }
    private void Start()
    {
        Experience = 550;
        Money = 550;
    }
}