public class ExplosivePropItem : PropItem
{
    public override void Deactivate()
    {
        print("BA-BAH!");
        base.Deactivate();
    }
}