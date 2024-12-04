using UnityEngine;
using UnityEngine.UI;
using CandyCoded.HapticFeedback;

public class ButtonVibrationHandler : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button multiplayerButton;
    [SerializeField] private Button multiplayerPlayButton;
    [SerializeField] private Button multiplayerBackButton;

    private void OnEnable()
    {
        playButton.onClick.AddListener(LightVibration);
        multiplayerButton.onClick.AddListener(LightVibration);
        multiplayerPlayButton.onClick.AddListener(LightVibration);
        multiplayerBackButton.onClick.AddListener(LightVibration);
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(LightVibration);
        multiplayerButton.onClick.RemoveListener(LightVibration);
        multiplayerPlayButton.onClick.RemoveListener(LightVibration);
        multiplayerBackButton.onClick.RemoveListener(LightVibration);
    }

    private void LightVibration()
    {
        HapticFeedback.LightFeedback();
    }
}
