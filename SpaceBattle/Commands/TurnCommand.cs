namespace SpaceBattle;
public class Turn : ICommand
{
    private Iturnable turnable;
    public Turn(Iturnable turnable)
    {
        this.turnable = turnable;
    }
    public void Execute()
    {
        if (turnable.angle.IsNan())
            throw new Exception("Wrong angle!");
        if (turnable.angle_velocity.IsNan())
            throw new Exception("Wrong angle velocity!");

        turnable.angle += turnable.angle_velocity;
    }
}
