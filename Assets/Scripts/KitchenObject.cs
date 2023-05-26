using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    public ClearCounter ClearCounter
    {
        get { return ClearCounter; }
        set
        {
            if (ClearCounter != null)
            {
                ClearCounter.KitchenObject = null;
            }

            ClearCounter = value;
            if (value.HasKitchenObject())
            {
                Debug.LogError("Counter already has kitchenObject.");
            }
            value.KitchenObject = this;

            transform.parent = value.GetKitchenObjectFollowTransform();
            transform.localPosition = Vector3.zero;
        }
    }

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return _kitchenObjectSO;
    }
}
