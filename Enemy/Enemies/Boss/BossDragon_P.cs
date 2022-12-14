public class BossDragon_P : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 100000;
        base.Awake();
        Speed = 0.5f;
    }

    private void Start()
    {
        Experience = 350;
        Money = 350;
    }
}