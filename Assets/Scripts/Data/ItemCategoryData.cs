using UnityEngine;

namespace Immersed.Data
{
    [CreateAssetMenu(fileName = "New Category", menuName = "Immersed/Data/New Category Data")]
    public class ItemCategoryData : ScriptableObject
    {
        public ItemData[] Items => _items;

        [Header("Item Data")]
        [SerializeField] private ItemData[] _items;
    }
}