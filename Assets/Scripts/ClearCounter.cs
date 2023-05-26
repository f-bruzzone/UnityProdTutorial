using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private Transform _counterTopPoint;

    public KitchenObject KitchenObject { get; set; }

    public void Interact()
    {
        if (KitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().ClearCounter = this;
        }
        else
        {
            Debug.Log(KitchenObject.ClearCounter);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return _counterTopPoint;
    }

    public bool HasKitchenObject()
    {
        return KitchenObject != null;
    }
}
