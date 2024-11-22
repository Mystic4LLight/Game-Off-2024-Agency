using TMPro;
using UnityEngine;
using UnityEngine.UI;

// This panel with Effect information. Planning to show as hint for small icon on Agent profile.
public class EffectPanel : MonoBehaviour
{
    private Effect _effect;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI TimeLeftToExpiration;
    public Image ProfileImage;

    public Effect Effect
    {
        get => _effect;
        set
        {
            _effect = value;
            if (_effect != null)
            {
                NameText.text = _effect.DisplayName;
                DescriptionText.text = _effect.Description;
                TimeLeftToExpiration.text = _effect.TimeLeftToExpiration.ToString();
                ProfileImage.sprite = _effect.ProfilePhoto;
            }
        }
    }

}
