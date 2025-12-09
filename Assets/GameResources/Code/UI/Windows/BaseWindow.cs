namespace Code.UI.Windows
{
  using Data;
  using UnityEngine;

  public abstract class BaseWindow : MonoBehaviour
  {
    public WindowId Id { get; protected set; }
    
    private void Start()
    {
      Initialize();
      SubscribeUpdates();
    }

    private void OnDestroy() =>
      UnsubscribeUpdates();

    protected virtual void Initialize()
    {
    }

    protected virtual void SubscribeUpdates()
    {
    }

    protected virtual void UnsubscribeUpdates()
    {
    }
  }
}
