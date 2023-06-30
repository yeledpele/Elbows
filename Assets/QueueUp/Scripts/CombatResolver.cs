using System.Collections;
using BinaryEyes.Common;
using BinaryEyes.Common.Extensions;
using QueueUp.Components.UI;
using QueueUp.Data.CardsData;
using UnityEngine;
// ReSharper disable StringLiteralTypo

namespace QueueUp
{
    public class CombatResolver
        : SingletonComponent<CombatResolver>
    {
        [SerializeField] private MessagePanel _messagePanel;

        public void ResolvePlayerCombat(CharacterCardData npc)
        {
            this.LogMessage($"ResolvingPlayerCombat: npc={npc.DisplayName}");
            StartCoroutine(PerformPlayerCombat(npc));
        }

        private IEnumerator PerformPlayerCombat(CharacterCardData npc)
        {
            var player = PlayerManager.Instance;

            if (npc.Speed >= player.Speed)
            {
                this.LogMessage($"{npc.name} attack player for {npc.Strength} damage");
                yield return ShowMessage($"{npc.DisplayName} הכניס/ה לך מכות");
                player.ModifyHealth(-npc.Strength);
            }
            else
            {
                this.LogMessage($"Player attacks {npc.name} for {player.Strength} damage");
                yield return ShowMessage($"פצצת את {npc.DisplayName} במכות");
                player.ModifySpeed(-1);
            }


        }

        private IEnumerator ShowMessage(string message)
        {
            yield return _messagePanel.StartShow(message);
            yield return new WaitForSeconds(1.0f);
            yield return _messagePanel.StartHide();
        }
    }
}
