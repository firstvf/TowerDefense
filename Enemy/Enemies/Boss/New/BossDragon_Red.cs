public class BossDragon_Red : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 170000;
        base.Awake();
        Speed = 2.3f;
    }
    private void Start()
    {
        Experience = 700;
        Money = 700;
    }
}