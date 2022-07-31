using System;
using Immersed.Data;
using UnityEngine;

namespace Immersed.UI.ARUI
{
    public class ARUIViewHorizontalList : ARUIView
    {
        [SerializeField] private UIButtonCategory _listItemPlaceholder;

        public void CreateList(ItemContainerData data, Action<int> clickHandler)
        {
            for (int i = 0; i < data.Categories.Length; i++)
            {
                var listItem = CreateListItem();
                listItem.SetCategoryName(data.Categories[i].name);
                listItem.SetIndex(i);
                listItem.OnButtonClickedEvent += clickHandler;
            }
        }

        private UIButtonCategory CreateListItem() => Instantiate(_listItemPlaceholder, transform);
    }
}