using UnityEngine;

public class DropItems : MonoBehaviour
{
    [SerializeField] Transform _dropTransform = null;
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
        if (Algorithm.IsNullOrEmptyOrWhiteSpace(soundName)) return;

        SoundManager.instance.sfxPlayer.Play(_dropSoundName);
    }
    void _MakeItem(string itemName)
    {
        if (Algorithm.IsNullOrEmptyOrWhiteSpace(itemName)) return;

        var item = PoolManager.instance.Get(itemName);
        item.transform.position = _dropTransform.position;
        item.SetActive(true);
    }
}
