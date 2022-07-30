using UnityEngine;

namespace Immersed.Data
{
    [CreateAssetMenu(fileName = "New Furniture", menuName = "Immersed/Data/New FurnitureData")]
    public class FurnitureData : ItemData
    {
        [SerializeField] private float _price;
        [SerializeField] private Color _color;
        [SerializeField] private string _assetLink;
    }
}