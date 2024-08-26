public class CherrySpawner : InteractiveObjectsSpawner<Cherry> 
{
    protected override void AccompanyGet(Cherry interactiveObject)
    {
        base.AccompanyGet(interactiveObject);
        interactiveObject.PickedUp += OnPickedUp;
    }

    protected override void AccompanyRelease(Cherry interactiveObject)
    {
        base.AccompanyRelease(interactiveObject);
        interactiveObject.PickedUp -= OnPickedUp;
    }
}