public class Dragon_P_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 1800;
        base.Awake();
        Speed = 2f;
    }

    private void Start()
    {
        Experience = 9;
        Money = 9;
    }
}