using System;

public class UpdateTick : Singleton<UpdateTick>
{
    public event Action OnUpdateTick;

    private void Update()
    {
        if(OnUpdateTick != null)
        {
            OnUpdateTick();
        }
    }

    public void AddToUpdateTick(IUpdateTick target)
    {
        OnUpdateTick += target.OnUpdateTick;
    }

    public void RemoveFromUpdateTick(IUpdateTick target)
    {
        OnUpdateTick -= target.OnUpdateTick;
    }
}

public interface IUpdateTick
{
    void OnUpdateTick();
}
