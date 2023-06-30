using System.Linq;
using BinaryEyes.Common;
using BinaryEyes.Common.Extensions;
using QueueUp.Data.CardsData;

namespace QueueUp
{
    public class CombatResolver
        : SingletonComponent<CombatResolver>
    {
        public void ResolvePlayerCombat(CharacterCardData npc)
        {
            this.LogMessage($"ResolvingPlayerCombat: npc={npc.DisplayName}");
            var player = PlayerManager.Instance;

            if (npc.Speed >= player.Speed)
            {
                this.LogMessage($"{npc.DisplayName.Reverse()} attack player for {npc.Strength} damage");
            }
            else
            {
                this.LogMessage($"Player attacks {npc.DisplayName.Reverse()} for {player.Strength} damage");
            }
        }
    }
}
