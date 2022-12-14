public class BossDragon_Green : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 180000;
        base.Awake();
        Speed = 2.7f;
    }
    private void Start()
    {
        Experience = 700;
        Money = 700;
    }
}