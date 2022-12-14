public class Chest_Enemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 2300;
        base.Awake();
        Speed = 1.5f;
    }

    private void Start()
    {
        Experience = 11;
        Money = 11;
    }
}