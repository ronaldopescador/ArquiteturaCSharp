enum State { On, Off }

class Lamp(State State)
{
    public void Operate()
    {
        State = State == State.On ? State.Off : State.On;
        Console.WriteLine("Lâmpada " + (State == State.On ? "On" : "Off"));
    }
}