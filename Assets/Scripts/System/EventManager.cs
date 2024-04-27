
public delegate void ChooseUIObject(int instanceId);

public static class EventManager
{
    public static event ChooseUIObject ChooseUIObjectEvent;

    public static void InvokeChooseUIObjectEvent(int id)
    {
        ChooseUIObjectEvent(id);
    }
}