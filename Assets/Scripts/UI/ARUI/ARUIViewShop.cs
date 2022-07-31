using Immersed.Data;
using UnityEngine;

namespace Immersed.UI.ARUI
{
    public class ARUIViewShop : ARUIView
    {
        [Header("Shop Dependencies")]
        [SerializeField] private ARUIViewHorizontalList _menuHorizontalList;
        [SerializeField] private ARUIViewShopContent _shopContent;
        [SerializeField] private ARUIViewFooter _footer;

        [Header("Shop Data")]
        [SerializeField] private ItemContainerData _itemContainerData;

        private ItemCategoryData _currentSelectedCategory;
        private FurnitureData _currentSelectedItem;
        private int _currentIndex = 0;

        private void Awake()
        {
            LoadCategories();
        }

        public void SelectRight()
        {
            if (_currentIndex < _currentSelectedCategory.Items.Length - 1)
            {
                _currentIndex += 1;
            }

            SelectItem(_currentIndex);
        }

        public void SelectLeft()
        {
            if(_currentIndex > 0)
            {
                _currentIndex -= 1;
            }

            SelectItem(_currentIndex);
        }

        private void LoadCategories()
        {
            if(_itemContainerData != null)
            {
                _menuHorizontalList.CreateList(_itemContainerData, SelectCategory);
                SelectCategory(0);
            }
            else
            {
                Debug.LogWarning("Cannot laod categories because ItemContainerData reference is empty. Drag the reference inside the inspector to load data");
            }
        }

        private void SelectCategory(int index)
        {
            _currentSelectedCategory = _itemContainerData.Categories[index];
            _currentIndex = 0;
            SelectItem(0);
        }

        private void SelectItem(int index)
        {
            _currentSelectedItem = (FurnitureData)_currentSelectedCategory.Items[index];

            _shopContent.UpdateData(_currentSelectedItem.SpriteDownloadLink);
            _footer.UpdateData(_currentSelectedItem.name, _currentSelectedItem.Price);
        }
    }
}