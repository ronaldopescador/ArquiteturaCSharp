class Switch
{
    private Lamp lamp;
    public Switch(Lamp device)
    {
        this.lamp = device;
    }
    public void Press()
    {
        lamp.Operate();
    }
}