using System;

public class TaskModel
{
    public Guid id { get; set; }
    public FamilyMember member { get; set; }
    public string text { get; set; }
    public bool isDone { get; set; }

    protected virtual void OnClickCallbackDelete(Guid id)
    {
        EventHandler<Guid> handler = ClickCallbackDelete;
        if (handler != null)
        {
            handler(this, id);
        }
    }
    protected virtual void OnClickCallbackEdit(TaskModel e)
    {
        EventHandler<TaskModel> handler = ClickCallBackEdit;
        if (handler != null)
        {
            handler(this, e);
        }
    }
    public event EventHandler<Guid> ClickCallbackDelete;
    public event EventHandler<TaskModel> ClickCallBackEdit;
    public void InvokClickCallbackDelete(Guid id)
    {
        OnClickCallbackDelete(id);
    }
    public void InvokClickCallbackEdit(TaskModel e)
    {
        OnClickCallbackEdit(e);
    }
}
