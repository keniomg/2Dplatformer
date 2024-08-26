public class DiamondsSpawner : InteractiveObjectsSpawner<Diamond> 
{
    protected override void AccompanyGet(Diamond interactiveObject)
    {
        base.AccompanyGet(interactiveObject);
        interactiveObject.PickedUp += OnPickedUp;
    }

    protected override void AccompanyRelease(Diamond interactiveObject)
    {
        base.AccompanyRelease(interactiveObject);
        interactiveObject.PickedUp -= OnPickedUp;
    }
}