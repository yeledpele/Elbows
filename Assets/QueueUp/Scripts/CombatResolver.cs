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

        public void ResolvePlayerCombat(CardView cardView)
        {
            this.LogMessage($"ResolvingPlayerCombat: npc={cardView.Data.DisplayName}");
            StartCoroutine(PerformPlayerCombat(cardView));
        }

        private IEnumerator PerformPlayerCombat(CardView cardView)
        {
            var player = PlayerManager.Instance;
            var npc = (CharacterCardData)cardView.Data;

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

            var defaultBlank = QueueManager.Instance.DefaultBlankCard;
            cardView.Initialize(defaultBlank);
            cardView.Reveal();
        }

        private IEnumerator ShowMessage(string message)
        {
            yield return _messagePanel.StartShow(message);
            yield return new WaitForSeconds(1.0f);
            yield return _messagePanel.StartHide();
        }
    }
}
