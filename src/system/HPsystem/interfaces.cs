namespace DoAnXNA2
{
    public interface IDamageable
    {
        int HP { get; set; }
        void TakeDamage(int damage);
    }
    public interface IDamager
    {
        int Damage { get; set; }
    }
}