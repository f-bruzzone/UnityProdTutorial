using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private BaseCounter _baseCounter;
    [SerializeField] private GameObject[] _selectedVisualArray;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == _baseCounter)
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
        foreach (GameObject counter in _selectedVisualArray)
        {
            counter.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject counter in _selectedVisualArray)
        {
            counter.SetActive(false);
        }
    }
}
