/// <summary>
/// g�re les objets cassables
/// </summary>
public class Breakable : Item
{
    public override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// appel� quand les hps de l'objet atteignent 0
    /// </summary>
    /// 
 public virtual void Break()
    {
        Destroy(gameObject);
    }
}
