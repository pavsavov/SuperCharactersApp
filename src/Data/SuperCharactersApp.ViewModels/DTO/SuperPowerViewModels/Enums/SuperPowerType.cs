namespace SuperCharacters.Models.Enums
{
    public enum SuperPowerType
    {
        Damage = 1, //damages the enemy with the 'Value' up to the base amount.
        Heal = 2, //self-healing with the 'Value' up to the base amount.
        Armour = 3, //will add to the user’s armour up to 100.
        DamageMultiplier = 4 //will multiply user’s damage by a given value for the next 2 attacks.
    }
}
