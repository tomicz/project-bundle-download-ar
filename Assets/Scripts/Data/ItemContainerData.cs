using UnityEngine;

namespace Immersed.Data
{
    [CreateAssetMenu(fileName = "New Item Category Container", menuName = "Immersed/Data/New Item Category Container")]
    public class ItemContainerData : ScriptableObject
    {
        public ItemCategoryData[] Categories => _itemCategory;

        [Header("Categories")]
        [SerializeField] private ItemCategoryData[] _itemCategory;
    }
}