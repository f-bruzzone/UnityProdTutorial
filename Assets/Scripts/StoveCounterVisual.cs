using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnVisual;
    [SerializeField] private GameObject particlesGameObject;
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        if ((e.state == StoveCounter.State.Frying) || (e.state == StoveCounter.State.Fried))
        {
            stoveOnVisual.SetActive(true);
            particlesGameObject.SetActive(true);
        }
        else
        {
            stoveOnVisual.SetActive(false);
            particlesGameObject.SetActive(false);
        }
    }
}
