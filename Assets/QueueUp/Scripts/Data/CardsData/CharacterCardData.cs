using UnityEngine;

namespace QueueUp.Data.CardsData
{
    [CreateAssetMenu(fileName = "New Character Card Data", menuName = "Card Data/Character Card Data")]
    public class CharacterCardData : ScriptableObject
    {
        public int Hp;
        public int Pat;
        public int Ass;
        public int Str;
        public int Spd;

        public string CharacterName;

        public Sprite FrontImage;
        public Sprite BackImage;

        public string QuoteEnter;
        public string QuoteExit;


        // Assuming the card has a color property

        // public Color cardColor;

        // Additional properties specific to the character card, if any

        // Add any other methods or variables as needed
    }
}
