public class BossChest : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 110000;
        base.Awake();
        Speed = 0.5f;
    }

    private void Start()
    {
        Experience = 450;
        Money = 450;
    }
}