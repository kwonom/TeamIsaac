using UnityEngine;
using UnityEngine.UI;

public class OptionInfo : MonoBehaviour
{
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _fxSlider;
    [SerializeField] Toggle _bgmToggle;
    [SerializeField] Toggle _fxToggle;
    
    void Start()
    {
        SoundController.instance.setBGMUI(_bgmSlider, _bgmToggle); // slider // toggle
        SoundController.instance.setSFXUI(_fxSlider, _fxToggle);

        _bgmSlider.onValueChanged.AddListener(SoundController.instance.OnBgmVolumeChange);
        _bgmToggle.onValueChanged.AddListener(SoundController.instance.BgmMute);
        _fxSlider.onValueChanged.AddListener(SoundController.instance.OnSfxVolumeChange);
        _fxToggle.onValueChanged.AddListener(SoundController.instance.FxMute);

    }
}
