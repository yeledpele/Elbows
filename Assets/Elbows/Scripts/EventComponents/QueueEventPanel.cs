﻿using System.Collections.Generic;
using BinaryEyes.Common.Attributes;
using BinaryEyes.Common.Extensions;
using Elbows.Data;
using Elbows.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Elbows.EventComponents
{
    /// <summary>
    /// The QueueEventPanel behaviour provides information and operations related
    /// to a single queue panel within a queue event.
    /// </summary>
    public class QueueEventPanel
        : MonoBehaviour
    {
        [SerializeField] [ReadOnlyField] private Image _background;
        [SerializeField] [ReadOnlyField] private CardView _cardView;
        [SerializeField] [ReadOnlyField] private List<CardView> _views;
        [SerializeField] private EventPanelType _type;
        public EventPanelType Type => _type;
        public IReadOnlyList<CardView> Views => _views;

        public void AddCard(QueueCardData cardData)
        {
            this.LogMessage($"AddingCard: {cardData.name}");
            var view = Instantiate(_cardView, _cardView.transform.parent).SetData(cardData);
            view.transform.SetAsFirstSibling();
            
            _views.Add(view);
        }

        public void SetBackground(Sprite image)
        {
            _background.sprite = image;
        }

        private void Awake()
        {
            _background = GetComponent<Image>();
            _background.enabled = false;
            _cardView = this.GetNameComponent<CardView>("CardView");
            _cardView.gameObject.SetActive(false);
        }
    }
}
