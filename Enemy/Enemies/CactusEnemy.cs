public class CactusEnemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        Health = 340;
        base.Awake();
        Speed = 4.5f;
    }

    private void Start()
    {
        Experience = 4;
        Money = 4;
    }
}