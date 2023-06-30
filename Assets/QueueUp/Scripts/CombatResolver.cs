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
                yield return _messagePanel.StartShow($"{npc.DisplayName} הכניס/ה לך מכות");
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                this.LogMessage($"Player attacks {npc.name} for {player.Strength} damage");
                yield return _messagePanel.StartShow($"פצצת את {npc.DisplayName} במכות");
            }
        }

        private IEnumerator ShowMessage(string message)
        {
            yield return _messagePanel.StartShow(message);
            yield return new WaitForSeconds(0.5f);
            yield return _messagePanel.StartHide();
        }
    }
}
