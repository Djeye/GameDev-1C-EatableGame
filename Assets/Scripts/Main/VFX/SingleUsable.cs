public class SingleUsable : Effect
{
    public override void EndAnimation()
    {
        Destroy(this.gameObject);
    }
}
