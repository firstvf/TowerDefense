public class DeathKnight_O_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 600;
        base.Awake();
        Speed = 3f;
    }

    private void Start()
    {
        Experience = 5;
        Money = 5;
    }
}