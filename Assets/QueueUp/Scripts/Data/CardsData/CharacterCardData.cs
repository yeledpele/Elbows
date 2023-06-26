using UnityEngine;

namespace QueueUp.Data.CardsData
{
    [CreateAssetMenu(menuName = "Queue Up/Card Data/Character")]
    public class CharacterCardData 
        : CardData
    {
        public override CardType Type => CardType.Character;

        [Header("Character")]
        public int Health;
        public int Patience;
        public int Assertiveness;
        public int Strength;
        public int Speed;

        [Header("Speech")]
        public string QuoteEnter;
        public string QuoteExit;
        // Assuming the card has a color property
        // public Color cardColor;
        // Additional properties specific to the character card, if any
        // Add any other methods or variables as needed
    }
}
