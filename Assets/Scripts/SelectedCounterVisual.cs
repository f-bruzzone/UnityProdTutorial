using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private ClearCounter _clearCounter;
    [SerializeField] private GameObject _selectedVisual;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == _clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        _selectedVisual.SetActive(true);
    }

    private void Hide()
    {
        _selectedVisual.SetActive(false);
    }
}
