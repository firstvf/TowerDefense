public class Ghost_B_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 450;
        base.Awake();
        Speed = 9.5f;
    }

    private void Start()
    {
        Experience = 7;
        Money = 7;
    }
}