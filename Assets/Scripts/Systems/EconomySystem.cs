using UnityEngine;

namespace ApexRush.Systems
{
    public class EconomySystem : MonoBehaviour
    {
        public int Credits { get; private set; } = 25000;

        public void AddCredits(int amount)
        {
            Credits += Mathf.Max(0, amount);
        }

        public bool SpendCredits(int amount)
        {
            if (amount <= 0 || Credits < amount) return false;
            Credits -= amount;
            return true;
        }

        public int CalculateRaceReward(int position, float cleanRaceBonus, float difficultyMultiplier)
        {
            int baseReward = Mathf.Max(1, 9 - position) * 1000;
            return Mathf.RoundToInt(baseReward * (1f + cleanRaceBonus) * difficultyMultiplier);
        }
    }
}
