using UnityEngine;

namespace Immersed.Data
{
    [CreateAssetMenu(fileName = "New Furniture", menuName = "Immersed/Data/New FurnitureData")]
    public class FurnitureData : ItemData
    {
        public float Price => _price;
        public Color Color => _color;
        public string SpriteDownloadLink => _spriteLink;
        public string BundleName => _bundleName;

        [Header("Furniture Properties")]
        [SerializeField] private float _price;
        [SerializeField] private Color _color;
        [SerializeField] private string _spriteLink;
        [SerializeField] private string _bundleName;
    }
}