using UnityEngine;
using CustomLibrary;

public class DropItems : MonoBehaviour
{
    [SerializeField] Transform _dropPosition = null;
    [SerializeField] string[] _itemNames = null;
    [SerializeField] string _dropSoundName = null;

    void OnDisable()
    {
        _DropItems();
    }

    void _DropItems()
    {
        _MakeSound(_dropSoundName);
        for (int i = 0; i < _itemNames.Length; i++)
            _MakeItem(_itemNames[i]);
    }

    void _MakeSound(string soundName)
    {
        if (Utility.IsNullOrEmptyOrWhiteSpace(soundName)) return;

        SoundManager.Instance.SfxAudio.Play(_dropSoundName);
    }
    void _MakeItem(string itemName)
    {
        if (Utility.IsNullOrEmptyOrWhiteSpace(itemName)) return;

        var item = PoolManager.Instance.Get(itemName);
        item.transform.position = _dropPosition.position;
        item.SetActive(true);
    }
}
