public class BossBat_Shadow_Green : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 115000;
        base.Awake();
        Speed = 3f;
    }
    private void Start()
    {
        Experience = 700;
        Money = 700;
    }
}